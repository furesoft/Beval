using Beval.ValueTypes;
using Loyc;
using System.Linq;

namespace Beval.BuildIns
{
    internal class NandFunction : BevalFunction
    {
        public NandFunction() : base((Symbol)"nand")
        {
        }

        public override BevalBool Invoke(params BevalBool[] args)
        {
            if (args.Length == 2)
            {
                var first = args.First();
                var second = args.ElementAt(1);

                return !(first && second);
            }

            return null;
        }
    }
}