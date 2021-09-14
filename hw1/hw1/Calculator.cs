namespace hw1
{
    public enum Operation
    {
        Plus,
        Minus,
        Multiply,
        Divide
    }

    public static class Calculator
    {
        public static int Calculate(int val1, Operation operation, int val2)
        {
            var result = operation switch
            {
                Operation.Plus => val1 + val2,
                Operation.Minus => val1 - val2,
                Operation.Multiply => val1 * val2,
                Operation.Divide => val1 / val2,
            };
            return result;
        }
    }
}