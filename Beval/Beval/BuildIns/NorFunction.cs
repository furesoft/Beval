using Beval.ValueTypes;
using Loyc;
using System.Linq;

namespace Beval.BuildIns
{
    internal class NOrFunction : BevalFunction
    {
        public NOrFunction() : base((Symbol)"nor")
        {
        }

        public override BevalBool Invoke(params BevalBool[] args)
        {
            if (args.Length == 2)
            {
                var first = args.First();
                var second = args.ElementAt(1);
                bool result = false;

                if (first || second)
                {
                    result = true;
                }
                else if (first && second)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

                return !result;
            }

            return null;
        }
    }
}