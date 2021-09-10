using System;

namespace hw1
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            var codeOfParsing = Parser.TryParseArgs(args, out var operation, out var val1, out var val2);
            if (codeOfParsing != 0)
            {
                return codeOfParsing;
            }

            var result = Calculator.Calculate(val1, operation, val2);
            Console.WriteLine($"Result is {result}");
            return 0;
        }
    }
}