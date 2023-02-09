namespace Banking.UnitTest;

public class GoldCustomersGetBonusOnDeposits
{
    [Fact]
    public void BonusAppliedToDeposit()
    {
        var account = new BankAccount();
        account.Level = LoyaltyLevel.Gold;
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100m;

        account.Deposit(amountToDeposit);

        Assert.Equal(openingBalance + amountToDeposit + 10m, account.GetBalance());
    }
}
