using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beval
{
    public class CmdOptions
    {
        [Option('i', "input", HelpText = "Input file to Run", Required = true)]
        public string Input { get; set; }
    }
}