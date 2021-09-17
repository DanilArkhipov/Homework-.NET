using System;

namespace hw1
{
    public static class Parser
    {
        public const int AllCorrect = 0;
        public const int WrongArgsLength = 1;
        public const int WrongArgFormat = 2;
        public const int WrongOperation = 3;

        private static bool CheckArgsLength(string[] args)
        {
            if (args.Length == 3)
            {
                return true;
            }

            Console.WriteLine($"The program requires 3 CLI arguments but {args.Length} provided");
            return false;
        }

        public static int TryParseArgs(string[] args, out int val1, out Operation operation, out int val2)
        {
            operation = default;
            val1 = default;
            val2 = default;

            if (!CheckArgsLength(args))
            {
                return WrongArgsLength;
            }

            if (!TryParseOperation(args[1], out operation))
            {
                return WrongOperation;
            }

            if (!TryParseValue(args[0], out val1) || !TryParseValue(args[2], out val2))
            {
                return WrongArgFormat;
            }

            return AllCorrect;
        }

        private static bool TryParseOperation(string arg, out Operation operation)
        {
            operation = arg switch
            {
                "+" => Operation.Plus,
                "-" => Operation.Minus,
                "*" => Operation.Multiply,
                "/" => Operation.Divide,
                _ => Operation.IncorrectOperation
            };
            var isOperation = operation is not Operation.IncorrectOperation;
            if (!isOperation)
            {
                Console.WriteLine($"Unsupported operation received: {arg}");
            }

            return isOperation;
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