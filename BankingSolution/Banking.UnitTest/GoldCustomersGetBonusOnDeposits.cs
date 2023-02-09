namespace Banking.UnitTest;

public class GoldCustomersGetBonusOnDeposits
{
    [Fact]
    public void BonusAppliedToDeposit()
    {
        // Given
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100m;

        // Then
        // This is the system under test
        account.Deposit(amountToDeposit);

        // When
        Assert.Equal(openingBalance + amountToDeposit + 10m, account.GetBalance());
    }
}
