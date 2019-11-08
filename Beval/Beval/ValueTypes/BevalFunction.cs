using Loyc;
using System.Collections.Generic;

namespace Beval.ValueTypes
{
    internal class BevalFunction : BevalValue
    {
        public Symbol Name { get; set; }
        public Dictionary<Symbol, BevalValue> Outputs { get; set; }
        public BevalScope Scope { get; set; }

        public BevalFunction()
        {
            Outputs = new Dictionary<Symbol, BevalValue>();
            Scope = BevalScope.Create();
        }
    }
}