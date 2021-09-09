using System;

namespace hw1
{
    internal class Program
    {
        private static void Main (string[] args)
        {
            var val1 = int.Parse(args[0]);
            var operation = args[1];
            var val2 = int.Parse(args[2]);

            var result = 0;
            switch (operation)
            {
                case "+":
                    result = val1 + val2;
                    break;

                case "-":
                    result = val1 - val2;
                    break;

                case "*":
                    result = val1 * val2;
                    break;

                case "/":
                    result = val1 / val2;
                    break;
            }
            Console.WriteLine($"Result is {result}");
        }
    }
}