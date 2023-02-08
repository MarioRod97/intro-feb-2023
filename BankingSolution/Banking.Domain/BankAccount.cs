namespace Banking.Domain;

public class BankAccount
{
    decimal _balance = 5000m;

    public void Deposit(decimal amountToDeposit)
    {
        _balance += amountToDeposit;
        return;
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        if (NotOverdraft(amountToWithdraw))
        {
            _balance -= amountToWithdraw;
        } else
        {
            throw new AccountOverdraftException();
        }
    }


    // "Never type private, always refactor to it" - Corey Haines.
    private bool NotOverdraft(decimal amountToWithdraw)
    {
        return _balance >= amountToWithdraw;
    }
}