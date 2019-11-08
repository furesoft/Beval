using Loyc;
using Loyc.Syntax;
using System;
using System.Collections.Generic;

namespace Beval
{
    internal class Evaluator
    {
        public Dictionary<Symbol, Symbol> Aliases { get; set; } = new Dictionary<Symbol, Symbol>();

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