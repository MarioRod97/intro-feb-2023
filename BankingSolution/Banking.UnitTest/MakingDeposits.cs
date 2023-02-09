using Banking.Domain;

namespace Banking.UnitTest;

public class MakingDeposits
{
    [Fact]
    public void DepositingMoneyIncreasesTheBalance()
    {
        var bankAccount = new BankAccount(new DummyBonusCalculator());
        var openingBalance = bankAccount.GetBalance();
        decimal amountToDeposit = 1000m;

        bankAccount.Deposit(amountToDeposit);

        Assert.Equal(openingBalance + amountToDeposit, bankAccount.GetBalance());
    }
}
