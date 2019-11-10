using Beval.BuildIns;
using Beval.ValueTypes;
using Loyc;
using Loyc.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Beval
{
    internal class Evaluator
    {
        public Dictionary<Symbol, Symbol> Aliases { get; set; } = new Dictionary<Symbol, Symbol>();
        public List<string> Errors { get; set; } = new List<string>();
        public string Filename { get; set; }
        public Dictionary<Symbol, BevalFunction> Functions { get; set; } = new Dictionary<Symbol, BevalFunction>();

        public Evaluator(string filename)
        {
            Filename = filename;
        }

        public void FindMetadata(LNode ast)
        {
            var lines = ast.Args;

            foreach (var line in lines)
            {
                var lineargs = line.Args;

                if (line.Name == CodeSymbols.Alias)
                {
                    Aliases.Add(lineargs.First().Name, lineargs.ElementAt(1).Name);
                }
                else if (line.Name == CodeSymbols.Fn)
                {
                    var outs = lineargs.ElementAt(0);
                    var name = lineargs.ElementAt(1);
                    var ins = lineargs.ElementAt(2);

                    var func = new BevalFunction(name.Name);
                    if (outs.Args.Any())
                    {
                        foreach (var outputs in outs.Args)
                        {
                            func.Outputs.Add(outputs.Name, new BevalBool(false));
                        }
                    }
                    else if (outs.Name == CodeSymbols.Void)
                    {
                        //ToDo: when output is void add x to output and transform body to set x output
                    }
                    else
                    {
                        func.Outputs.Add(outs.Name, new BevalBool(false));
                    }

                    Functions.Add(name.Name, func);
                }
                else if (line.Name == CodeSymbols.Import)
                {
                    var name = lineargs.First();

                    if (name.Name == (Symbol)"core")
                    {
                        Functions.Add((Symbol)"not", new NotFunction());
                        Functions.Add((Symbol)"and", new AndFunction());
                        Functions.Add((Symbol)"or", new OrFunction());
                        Functions.Add((Symbol)"xor", new XOrFunction());

                        Functions.Add((Symbol)"nand", new NandFunction());
                        Functions.Add((Symbol)"nor", new NOrFunction());

                        //ToDo: add default aliases if core is imported
                        AddAlias("not", "!");
                        AddAlias("or", "v");
                        AddAlias("and", "^");
                    }
                    else
                    {
                        //ToDo: Parse file and add all stuff to current evaluator
                        var parser = new BevalParser();
                        var content = File.ReadAllText(FindFile(name.Name, Filename));
                        var evaluator = new Evaluator(Filename);
                        evaluator.FindMetadata(parser.Parse(content));

                        Errors.AddRange(evaluator.Errors);

                        foreach (var alias in evaluator.Aliases)
                        {
                            if (!Aliases.ContainsKey(alias.Key))
                            {
                                Aliases.Add(alias.Key, alias.Value);
                            }
                            else
                            {
                                Errors.Add($"Alias '{alias.Key.Name}' already exists in File '{Filename}'");
                            }
                        }
                        foreach (var func in evaluator.Functions)
                        {
                            if (!Functions.ContainsKey(func.Key))
                            {
                                Functions.Add(func.Key, func.Value);
                            }
                            else
                            {
                                Errors.Add($"Function '{func.Key.Name}' already exists in File '{Filename}'");
                            }
                        }
                    }
                }
            }
        }

        public bool InvokeFunc(string name, params BevalBool[] args)
        {
            var sym = (Symbol)name;

            if (Functions.ContainsKey(sym))
            {
                return Functions[sym].Invoke(args);
            }
            else
            {
                throw new Exception("Function not found");
            }
        }

        private void AddAlias(string name, string value)
        {
            Aliases.Add((Symbol)name, (Symbol)value);
        }

        private string FindFile(Symbol name, string currentfilename)
        {
            var fi = new FileInfo(currentfilename);
            var di = fi.Directory;

            var files = di.GetFiles(name.Name + ".*");

            return files.First().FullName;
        }
    }
}