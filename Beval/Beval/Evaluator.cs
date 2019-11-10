﻿using Beval.BuildIns;
using Beval.ValueTypes;
using Loyc;
using Loyc.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Beval
{
    internal class Evaluator
    {
        public Dictionary<Symbol, Symbol> Aliases { get; set; } = new Dictionary<Symbol, Symbol>();

        public Dictionary<Symbol, BevalFunction> Functions { get; set; } = new Dictionary<Symbol, BevalFunction>();

        public Evaluator()
        {
            Functions.Add((Symbol)"not", new NotFunction());
            Functions.Add((Symbol)"and", new AndFunction());
            Functions.Add((Symbol)"or", new OrFunction());
            Functions.Add((Symbol)"xor", new XOrFunction());

            Functions.Add((Symbol)"nand", new NandFunction());
            Functions.Add((Symbol)"nor", new NOrFunction());
        }

        public void FindMetadata(LNode ast)
        {
            FindAliases(ast);
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

        private void FindAliases(LNode ast)
        {
            var lines = ast.Args;

            foreach (var line in lines)
            {
                if (line.Name == CodeSymbols.Alias)
                {
                    Aliases.Add(line.Args.First().Name, line.Args.ElementAt(1).Name);
                }
            }
        }
    }
}