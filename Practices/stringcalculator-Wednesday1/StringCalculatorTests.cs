
namespace StringCalculator;

public class StringCalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    public void StringWithOneNumberReturnsOne(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("2,3", 5)]
    public void StringWithTwoNumberReturnsSum(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }
}
