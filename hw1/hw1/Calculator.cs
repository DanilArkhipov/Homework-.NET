using System;

namespace hw1
{
    public enum Operation
    {
        Plus,
        Minus,
        Multiply,
        Divide,
        IncorrectOperation
    }

    public static class Calculator
    {
        public static double Calculate(int val1, Operation operation, int val2)
        {
            return operation switch
            {
                Operation.Plus => val1 + val2,
                Operation.Minus => val1 - val2,
                Operation.Multiply => val1 * val2,
                Operation.Divide => (double)val1 / (double)val2,
                Operation.IncorrectOperation => throw new ArgumentException("Incorrect operation")
            };
        }
    }
}