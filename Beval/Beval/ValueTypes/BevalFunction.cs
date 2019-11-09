using Loyc;
using System.Collections.Generic;

namespace Beval.ValueTypes
{
    internal class BevalFunction : BevalValue
    {
        public Symbol Name { get; set; }
        public Dictionary<Symbol, BevalValue> Outputs { get; set; }
        public int Precedence { get; set; }
        public BevalScope Scope { get; set; }

        public BevalFunction(Symbol name)
        {
            Name = name;
            Outputs = new Dictionary<Symbol, BevalValue>();
            Scope = BevalScope.Create();
        }

        public virtual BevalBool Invoke(params BevalBool[] args)
        {
            //ToDo: implement invoke bevalfunction

            return new BevalBool(false);
        }
    }
}