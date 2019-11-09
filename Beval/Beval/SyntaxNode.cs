using Loyc.Syntax;
using System.Collections.Generic;

namespace Beval
{
    public static class SyntaxNode
    {
        public static LNodeFactory F = new LNodeFactory(EmptySourceFile.Default);

        public static LNode Combine(LNode f, LNode s)
        {
            if (s.IsCall && s.Name == CodeSymbols.AltList)
            {
                var res = new List<LNode>();
                res.Add(f);
                res.AddRange(s.Args);

                return F.List(res.ToArray());
            }

            return F.List(f, s);
        }

        public static LNode Combine(LNode f, IEnumerable<LNode> s)
        {
            var r = new List<LNode>();
            r.Add(f);
            r.AddRange(s);

            return F.List(r);
        }

        public static IEnumerable<LNode> Combine(LNode v)
        {
            return F.List(v);
        }

        public static LNode CreateAlias(LNode aliasname, LNode value)
        {
            return F.Call(CodeSymbols.Alias, aliasname, value);
        }

        public static LNode CreateBinaryExpression(LNode f, LNode op, LNode s)
        {
            return F.Call(op, f, s);
        }

        public static LNode CreateBlock(IEnumerable<LNode> body)
        {
            return F.List(body);
        }

        public static LNode CreateFunction(LNode name, LNode inputs, LNode outputs, LNode body)
        {
            return F.Fn(outputs, name, inputs, body);
        }

        public static LNode CreateFunction(LNode name, LNode inputs, LNode body)
        {
            return F.Fn(F.Void, name, inputs, body);
        }

        public static LNode CreateFunction(LNode name, LNode body)
        {
            return F.Fn(F.Void, name, body);
        }

        public static LNode CreateID(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return F.Id(id);
            }

            return LNode.Missing;
        }

        public static LNode CreateInclude(LNode filename)
        {
            return LNode.Call(CodeSymbols.Import, LNode.List(filename));
        }

        public static LNode CreateString(string val)
        {
            return F.Literal(val);
        }

        public static LNode CreateUnaryExpression(LNode op, LNode arg)
        {
            return F.Call(op, arg);
        }

        public static LNode CreateValue(string src)
        {
            return F.Literal(bool.Parse(src));
        }

        public static LNode InBrackets(LNode node)
        {
            return F.InParens(node);
        }
    }
}