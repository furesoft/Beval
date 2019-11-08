using PipelineNet.Middleware;
using System;
using System.IO;

namespace Beval.MiddleWare
{
    internal class ParsingMiddleware : IMiddleware<PipelineContext>
    {
        public void Run(PipelineContext parameter, Action<PipelineContext> next)
        {
            var p = new BevalParser();
            var ast = p.Parse(File.ReadAllText(parameter.Cmd.Input));
            parameter.AST = ast;

            next(parameter);
        }
    }
}