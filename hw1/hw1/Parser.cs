using System;

namespace hw1
{
    internal static class Parser
    {
        private const int WrongArgsLength = 1;
        private const int WrongArgFormat = 2;
        private const int WrongOperation = 3;

        private static bool CheckArgsLength(string[] args)
        {
            if (args.Length == 3)
            {
                return true;
            }

            Console.WriteLine($"The program requires 3 CLI arguments but {args.Length} provided");
            return false;
        }

        internal static int TryParseArgs(string[] args, out Operation operation, out int val1, out int val2)
        {
            operation = default;
            val1 = default;
            val2 = default;

            if (!CheckArgsLength(args))
            {
                return WrongArgsLength;
            }

            var isOperation = TryParseOperation(args[1], out operation);
            if (!isOperation)
            {
                return WrongOperation;
            }

            if (!TryParseValue(args[0], out val1) || !TryParseValue(args[2], out val2))
            {
                return WrongArgFormat;
            }

            return 0;
        }

        private static bool TryParseOperation(string arg, out Operation operation)
        {
            var numOperation = arg switch
            {
                "+" => 0,
                "-" => 1,
                "*" => 2,
                "/" => 3,
                _ => 4
            };
            var isOperation = numOperation < 4;
            if (!isOperation)
            {
                Console.WriteLine($"Unsupported operation received: {arg}");
                operation = default;
                return false;
            }

            operation = (Operation) numOperation;
            return true;
        }

        private static bool TryParseValue(string arg, out int val)
        {
            var isVal = int.TryParse(arg, out val);
            if (!isVal)
            {
                Console.WriteLine($"Value is not int: {arg}");
            }

            return isVal;
        }
    }
}