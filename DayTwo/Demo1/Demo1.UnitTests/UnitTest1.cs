namespace Demo1.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            
        }

        [Fact]
        public void AddingTwoNumbers()
        {
            // Given (range)
            int a = 10, b = 20, c;
            // When (act)
            // This is the thing you are actually testing
            c = a + b;
            // Then (assert)
            Assert.Equal(30, c);
        }

        [Theory]
        [InlineData(2, 2, 4)]
        public void AddTwoNumbersTheory(int a, int b, int expected)
        {
            int answer = a + b;
            Assert.Equal(expected, answer);
        }
    }
}