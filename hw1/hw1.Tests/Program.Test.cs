using hw1;
using Xunit;

namespace Tests
{
    public class ProgramTest
    {
        [Fact]
        public void WhenArgsIncorrect()
        {
            Assert.False(Program.Main(new[]{"1", "+"}) == Parser.AllCorrect);
        }

        [Fact]
        public void WhenArgsCorrect()
        {
            Assert.True(Program.Main(new[]{"1", "+", "2"}) == Parser.AllCorrect);
        }
    }
}