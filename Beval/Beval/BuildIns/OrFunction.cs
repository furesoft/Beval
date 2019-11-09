using Beval.ValueTypes;
using Loyc;
using System.Linq;

namespace Beval.BuildIns
{
    internal class OrFunction : BevalFunction
    {
        public OrFunction() : base((Symbol)"or")
        {
        }

        public override BevalBool Invoke(params BevalBool[] args)
        {
            if (args.Length == 2)
            {
                var first = args.First();
                var second = args.ElementAt(1);

                if (first || second)
                {
                    return true;
                }
                else if (first && second)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return null;
        }
    }
}