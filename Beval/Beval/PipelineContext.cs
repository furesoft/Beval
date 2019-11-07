using Loyc.Syntax;

namespace Beval
{
    internal class PipelineContext
    {
        public LNode AST { get; set; }
        public CmdOptions Cmd { get; set; }
    }
}