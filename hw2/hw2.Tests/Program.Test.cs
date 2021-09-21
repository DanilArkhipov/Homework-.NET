using Xunit;

namespace hw2.Tests
{
    public class ProgramTest
    {
        [Fact]
        public void WhenArgsIncorrect()
        {
            Assert.False(Program.Program.Main(new[]{"1", "+"}) == 0);
        }

        [Fact]
        public void WhenArgsCorrect()
        {
            Assert.True(Program.Program.Main(new[]{"1", "+", "2"}) == 0);
        }
    }
}