using PipelineNet.Middleware;
using System;

namespace Beval.MiddleWare
{
    internal class EvalMiddleware : IMiddleware<PipelineContext>
    {
        public void Run(PipelineContext parameter, Action<PipelineContext> next)
        {
            var eval = new Evaluator();
            eval.FindMetadata(parameter.AST);

            next(parameter);
        }
    }
}