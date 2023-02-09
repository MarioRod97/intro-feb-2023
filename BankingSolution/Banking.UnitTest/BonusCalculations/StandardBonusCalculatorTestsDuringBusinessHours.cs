namespace Banking.UnitTest.BonusCalculations;

public class StandardBonusCalculatorOutsideBusinessHours
{
    private StandardBonusCalculator _calculator;

    public StandardBonusCalculatorOutsideBusinessHours()
    {
        var stubbedClock = new Mock<IProvideTheBusinessClock() >;
        stubbedClock.Setup(c => c.IsDuringBusinessHours()).Returns(true);
        _calculator = new StandardBonusCalculator(stubbedClock.Object);
    }
    
    [Fact]
    public void UnderCutoffGetNoBonus()
    {
        var bonus = calculator.GetDepositBonusFor(4999.99M, 100); 
        Assert.Equal(0, bonus);
    }

    [Fact]
    public void AtCutOffGetsNoBonus()
    {
        var bonus = calculator.GetDepositBonusFor(5000M, 100);
        Assert.Equal(10, bonus);
    }
}
