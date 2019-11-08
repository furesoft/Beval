using CommandLine;

namespace Beval
{
    public class CmdOptions
    {
        [Option('i', "input", HelpText = "Input file to Run", Required = true)]
        public string Input { get; set; }

        [Option("update")]
        public bool Update { get; set; }
    }
}