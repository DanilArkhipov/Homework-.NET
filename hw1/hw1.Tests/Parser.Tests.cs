using hw1;
using Xunit;

namespace Tests
{
    public class ParserTests
    {
        [Fact]
        public void WhenArgsLengthIncorrect()
        {
            Check(new[]{"1", "+"}, Parser.WrongArgsLength);
            Check(new[]{"1", "+", "2", "="}, Parser.WrongArgsLength);
        }

        [Fact]
        public void WhenOperationIncorrect()
        {
            Check(new[]{"1", "%", "2"}, Parser.WrongOperation);
        }

        [Fact]
        public void WhenArgsIncorrect()
        {
            Check(new[]{"x", "+", "1"}, Parser.WrongArgFormat);
            Check(new[]{"1", "+", "x"}, Parser.WrongArgFormat);
        }

        [Fact]
        public void WhenAllCorrect()
        {
            Check(new[]{"1", "+", "2"}, Parser.AllCorrect, 1, Operation.Plus, 2);
            Check(new[]{"1", "-", "2"}, Parser.AllCorrect, 1, Operation.Minus, 2);
            Check(new[]{"1", "*", "2"}, Parser.AllCorrect, 1, Operation.Multiply, 2);
            Check(new[]{"1", "/", "2"}, Parser.AllCorrect, 1, Operation.Divide, 2);
        }

        private void Check(string[] args, int expectedCode, int expectedVal1, Operation expectedOperation, int expectedVal2)
        {
            var code = Parser.TryParseArgs(args, out var val1, out var operation, out var val2);
            Assert.Equal(expectedCode, code);
            Assert.Equal(expectedVal1, val1);
            Assert.Equal(expectedOperation, operation);
            Assert.Equal(expectedVal2, val2);
        }

        private void Check(string[] args, int expectedCode)
        {
            var code = Parser.TryParseArgs(args, out _, out _, out _);
            Assert.Equal(expectedCode, code);
        }
    }
}