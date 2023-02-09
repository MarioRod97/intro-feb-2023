namespace Banking.Domain;

public class BankAccount
{
    private decimal _balance = 5000M; // State - "Fields" variable.
    private ICanCalculateAccountBonuses _bonusCalculator;

    // Constructors are for REQUIRED DEPENDENCIES when creating a class.
    public BankAccount(ICanCalculateAccountBonuses bonusCalculator)
    {
        _bonusCalculator = bonusCalculator;
    }

    public void Deposit(decimal amountToDeposit)
    {
        // Write the code you wish you had. (WTCYWYH)
        decimal bonus = _bonusCalculator.GetDepositBonusFor(_balance, amountToDeposit);
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
            // Write the code you wish you had
            //  _notifier.CheckForRequiredNotification(this, amountToWithdraw);
        }
        else
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