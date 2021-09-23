using hw1;
using Xunit;

namespace Tests
{
    public class ParserTests
    {
        [Fact]
        public void WhenArgsLengthIncorrect()
        {
            Check(new[]{"1", "+"}, false, Parser.WrongArgsLength);
            Check(new[]{"1", "+", "2", "="}, false, Parser.WrongArgsLength);
        }

        [Fact]
        public void WhenOperationIncorrect()
        {
            Check(new[]{"1", "%", "2"}, false, Parser.WrongOperation);
        }

        [Fact]
        public void WhenArgsIncorrect()
        {
            Check(new[]{"x", "+", "1"}, false, Parser.WrongArgFormat);
            Check(new[]{"1", "+", "x"}, false, Parser.WrongArgFormat);
        }

        [Fact]
        public void WhenAllCorrect()
        {
            Check(new[]{"1", "+", "2"}, true, Parser.AllCorrect, 1, Operation.Plus, 2);
            Check(new[]{"1", "-", "2"}, true, Parser.AllCorrect, 1, Operation.Minus, 2);
            Check(new[]{"1", "*", "2"}, true, Parser.AllCorrect, 1, Operation.Multiply, 2);
            Check(new[]{"1", "/", "2"}, true, Parser.AllCorrect, 1, Operation.Divide, 2);
        }

        private void Check(string[] args, bool expectedResult, int expectedCode, int expectedVal1, Operation expectedOperation, int expectedVal2)
        {
            var result = Parser.TryParseArgs(args, out var val1, out var operation, out var val2, out var code);
            Assert.Equal(expectedResult, result);
            Assert.Equal(expectedCode, code);
            Assert.Equal(expectedVal1, val1);
            Assert.Equal(expectedOperation, operation);
            Assert.Equal(expectedVal2, val2);
        }

        private void Check(string[] args, bool expectedResult, int expectedCode)
        {
            var result = Parser.TryParseArgs(args, out _, out _, out _, out var code);
            Assert.Equal(expectedResult, result);
            Assert.Equal(expectedCode, code);
        }
    }
}