using Beval.MiddleWare;
using CommandLine;
using nUpdate.Updating;
using PipelineNet.MiddlewareResolver;
using PipelineNet.Pipelines;
using System;
using System.Globalization;

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
            if (!opts.Update)
            {
                UpdateManager manager = new UpdateManager(new Uri("http://furesoft.ml/updates/Beval/updates.json"), "<RSAKeyValue><Modulus>uG9hu7pVTsrYHWcdaO8q4204TDES2OQvQg2w9AS6H7b8oS27i4j9eaYmaUcdZu23qfmCJkSp49K7paCBtex5TLVb2uJ2QH4Rv3r++xf7wv+IEreZiQQUmEq7zm1yF6iqWd3dF78WCakwaUHh9Q+XaxrC1bpHcJSzq55N1XRf/aiS0toM3Cpu/gMekjWuqYYSAFmLy7smyC2gB/wXIwknl7I27MCQ1r8ckeXvM1dJjyJRNxAqzoeoK7IaSiNQVuok1HyMrmcUaJCrNeaUMQ4gXRF+2+NnkPLjHALznMA+FyxfloOqYj9F59bVXhXpSr4ZxoOgxNgOTD24XgstaAlscM2VAa5AdjKUxnvC1PIWITO08UYBKiAQqrYfWIVqcmvLufVYPszkmwxxRpWhFKOhEPcCS8ggaJbsNPc8wgSkX2LKy8cD/ij0K4H7e0PNApRVouY7JXxWKnMqtIrm2CHRfHB5QCpnquP/6VnXlO09WEbqSHflQ0NxiV8gAK4ZVmf+5cK7RpcTDcKvRiFlo4H766cP8Ja9w/x2EybO/xIuV3lU5PsXz+E+BDYb/9GBP9oLNTKInO+5PwtZY/NUT1a0vvFYRGsWCzbi7kvVGXox9KpAj/3uZitB98JOMw8v3gjTm+nwOostw0WDCttqhgoWbvX9feUe3Oley4tGwpTI4xtcsmOD9x0AlSwxQDmiTvNU6BaBef6ERc1EhHj2lr3CZlZPGdPlhMnRsoJflnG9Nj+kvsCf3t3FlwgwsmUIqmpuW2Nj72B5ihcVsXBHMQGcmFwnjUoJwu4EHCPNNb3biftkrR38JE/P6gDx0ydA3vr7b4FRfMz/gSG1QX7DYqrjlkxqdyogikyCk/JcVoNz9U5zFiv5LebRC7FYIQvAm5H2ckDPj1mocPNMpboa/HG3P1nngtRt3ZV2omFSLl9CvzvI2MI8hvIQEWzQn+rHiadz57cEoR1Rl1J6ky7GLD2XXCuQKANJeF5zsqeyIQ9AlDsiZP2MvktlLjb5NuBieWrG6zVRF4Xj/KUhvrCk+dw1WKOtwEVoTk4IWta4vxVyYdLGub/1qal+1pvp/lmWugAeoxVGDmZZxyWgBP9SHjxrMEHWobZZBT/ZkrGCwuwXCa5piNfCc5shRIULNWTpbn9mWbZebXiQ8nJ+9ERCyZFhJBI7wKP8U4FcPlu3evFzoeQfCZH2bby4tGeZOo7n8T2o6Brhu9WC+SW7TbeZqk5+KzVZzjtxpuOi23bwN3vNJN+Iek2IGyffr1gsrkXwfgcUR9o8No+vBfavyRx/r3dBrZrxKP1Wf6dOdRoE6GCtI9+d9nVamiQ9WYDpghhj8dUfCuj/U6vrk55YQSqBs/maVQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>", new CultureInfo("en"));
                if (manager.SearchForUpdates())
                {
                    manager.DownloadPackagesAsync();
                    manager.ValidatePackages();
                    manager.InstallPackage();
                }
            }

            var pipeline = new Pipeline<PipelineContext>(new ActivatorMiddlewareResolver());
            var context = new PipelineContext();
            context.Cmd = opts;

            pipeline.Add<ParsingMiddleware>();
            pipeline.Add<EvalMiddleware>();

            pipeline.Execute(context);
        }
    }
}