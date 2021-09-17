using System;

namespace hw1
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            var argsAreCorrect = Parser.TryParseArgs(
                args,
                out var val1,
                out var operation,
                out var val2,
                out var codeOfParsing);
            if (argsAreCorrect)
            {
                var result = Calculator.Calculate(val1, operation, val2);
                Console.WriteLine($"Result is {result}");
            }

            return codeOfParsing;
        }
    }
}