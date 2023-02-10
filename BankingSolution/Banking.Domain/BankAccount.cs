namespace Banking.Domain;

public class BankAccount
{
    // State - "Fields" variable.
    // Private is only visibel within this class
    private decimal _balance = 5000M;
    private ICanCalculateAccountBonuses _bonusCalculator;

    // Constructors are for REQUIRED DEPENDENCIES when creating a class.
    public BankAccount(ICanCalculateAccountBonuses bonusCalculator)
    {
        _bonusCalculator = bonusCalculator;
    }

    public void Deposit(decimal amountToDeposit)
    {
        decimal bonus = _bonusCalculator.GetDepositBonusFor(_balance, amountToDeposit);
        _balance += amountToDeposit + bonus;
    }

    private static void GuardNoNegativeAmountsForTransactions(decimal amountToDeposit)
    {
        if (amountToDeposit < 0)
        {
            throw new NoNegativeNumbersException();
        }
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        if (NotOverdraft(amountToWithdraw))
            _balance -= amountToWithdraw;
        else
            throw new AccountOverdraftException();
    }

    private bool NotOverdraft(decimal amountToWithdraw)
    {
        return _balance >= amountToWithdraw;
    }
}