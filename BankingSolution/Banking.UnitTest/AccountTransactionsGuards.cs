using Banking.Domain;

namespace Banking.UnitTest;

public class AccountTransactionsGuards
{
    // We have a defect (there will usually be some ID associated with it)     // Step 1: Recreate the defect. Write a test that passes because it demonstrates the bad behavior.
    [Fact]
    public void AllowNegativeNumbers()
    {
        var stubbedBonusCalculator = new Mock<ICanCalculateAccountBonuses>();
        var account = new BankAccount(stubbedBonusCalculator.Object);
        var openingBalance = account.GetBalance();
        account.Deposit(-1000); Assert.Equal(openingBalance - 1000, account.GetBalance());
    }     // Step 2: Write another test that demonstrates how it SHOULD work if the defect is fixed. It should fail.
    
    [Fact]
    public void NegativeNumbertsNotAllowed()
    {
        var stubbedBonusCalculator = new Mock<ICanCalculateAccountBonuses>();
        var account = new BankAccount(stubbedBonusCalculator.Object);
        var openingBalance = account.GetBalance();
        
        Assert.Throws<NoNegativeNumbersException>(() => account.Deposit(-1000)); Assert.Equal(openingBalance, account.GetBalance());
    }
}
