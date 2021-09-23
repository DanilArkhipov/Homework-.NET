using System;
using hw1;
using Xunit;

namespace Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(2, Operation.Plus, 2, 4)]
        [InlineData(3, Operation.Minus, 1, 2)]
        [InlineData(4, Operation.Multiply, 5, 20)]
        [InlineData(36, Operation.Divide, 4, 9)]
        public void Tests(int val1, Operation operation, int val2, int expectedResult)
        {
            Assert.Equal(expectedResult, Calculator.Calculate(val1, operation, val2));
        }

        [Fact]
        public void WhenOperationIncorrect()
        {
            Assert.Throws<ArgumentException>(() => Calculator.Calculate(5, Operation.IncorrectOperation, 4));
        }
    }
}