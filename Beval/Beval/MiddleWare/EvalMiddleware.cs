using PipelineNet.Middleware;
using System;
using System.Linq;

namespace Beval.MiddleWare
{
    internal class EvalMiddleware : IMiddleware<PipelineContext>
    {
        public void Run(PipelineContext parameter, Action<PipelineContext> next)
        {
            var eval = new Evaluator(parameter.Cmd.Input);
            eval.FindMetadata(parameter.AST);

            if (eval.Errors.Any())
            {
                foreach (var err in eval.Errors)
                {
                    Console.WriteLine(err);
                }
            }

            next(parameter);
        }
    }
}