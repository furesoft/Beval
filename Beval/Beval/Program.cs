using Beval.MiddleWare;
using CommandLine;
using PipelineNet.MiddlewareResolver;
using PipelineNet.Pipelines;
using System;

namespace Beval
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CmdOptions>(args).WithParsed(runParsed);
        }

        private static void runParsed(CmdOptions opts)
        {
            var pipeline = new Pipeline<PipelineContext>(new ActivatorMiddlewareResolver());
            var context = new PipelineContext();
            context.Cmd = opts;

            pipeline.Add<ParsingMiddleware>();

            pipeline.Execute(context);
        }
    }
}