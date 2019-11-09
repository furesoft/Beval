using Beval.BuildIns;
using Beval.ValueTypes;
using Loyc;
using Loyc.Syntax;
using System;
using System.Collections.Generic;

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

        private void FindAliases(LNode ast)
        {
            var lines = ast.Args;
        }
    }
}