using CommandLine;
using System.Runtime.InteropServices;
using static ConsoleCli.Program;

namespace ConsoleCli
{
    class Program
    {
        public class Options
        {
            [Option('n', "name", Required = true, HelpText = "Your name.")]
            public string Name { get; set; }
        }

        static void Main(string[] args)
        {
            // Parse command-line args and handle errors
            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(RunOptions).WithNotParsed(HandleParseError);
        }

        private static void HandleParseError(IEnumerable<Error> obj)
        {
            Console.WriteLine("Invalid Parameters.");
            Environment.Exit(-1);
        }

        private static void RunOptions(Options options)
        {
            Console.WriteLine("Hello {0}", options.Name);
            Environment.Exit(0);
        }
    }
}