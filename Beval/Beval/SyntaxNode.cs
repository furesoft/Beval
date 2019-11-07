using Loyc.Syntax;
using System.Collections.Generic;

namespace Beval
{
    public static class SyntaxNode
    {
        public static LNodeFactory F = new LNodeFactory(EmptySourceFile.Default);

        public static LNode CreateBlock(IEnumerable<LNode> body)
        {
            return F.List(body);
        }

        public static LNode CreateID(string id)
        {
            return F.Id(id);
        }

        public static LNode CreateInclude(LNode filename)
        {
            return LNode.Call(CodeSymbols.Import, LNode.List(filename));
        }

        public static LNode CreateString(string val)
        {
            return F.String.WithValue(val);
        }
    }
}