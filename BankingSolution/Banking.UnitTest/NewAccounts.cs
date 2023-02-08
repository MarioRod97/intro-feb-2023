using Banking.Domain;
namespace Banking.UnitTest;

public class NewAccounts
{
    [Fact]
    public void NewAccountsHaveTheCorrectOpeningBalance()
    {
        // Given: brand new account exists
        var newAccount = new BankAccount();

        // Ask account for balance
        decimal accountBalance = newAccount.GetBalance();

        // Check balance is $5,000
        Assert.Equal(5000, accountBalance);
    }
}
