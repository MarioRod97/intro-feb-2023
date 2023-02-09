namespace Banking.Domain;

public enum LoyaltyLevel { Standard, Gold };

public class BankAccount
{
    decimal _balance = 5000m;
    public LoyaltyLevel Level;

    public void Deposit(decimal amountToDeposit)
    {
        decimal bonus = 0m;
        
        if (Level== LoyaltyLevel.Gold) { 
            bonus = amountToDeposit * .10m;
        }

        _balance += amountToDeposit + bonus;
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