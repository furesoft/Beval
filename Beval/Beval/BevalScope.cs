using Loyc;
using System.Collections.Generic;

namespace Beval
{
    internal class BevalScope
    {
        public Dictionary<Symbol, BevalValue> Variables { get; set; }

        public BevalScope(Dictionary<Symbol, BevalValue> variables)
        {
            Variables = variables;
        }

        public static BevalScope Create()
        {
            return new BevalScope(new Dictionary<Symbol, BevalValue>());
        }

        public static BevalScope Create(Dictionary<Symbol, BevalValue> variables)
        {
            return new BevalScope(variables);
        }
    }
}