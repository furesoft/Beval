using Beval.ValueTypes;
using Loyc;
using System.Linq;

namespace Beval.BuildIns
{
    internal class NotFunction : BevalFunction
    {
        public NotFunction() : base((Symbol)"not")
        {
        }

        public override BevalBool Invoke(params BevalBool[] args)
        {
            if (args.Length == 1)
            {
                return args.First().Value ? false : true;
            }

            return null;
        }
    }
}