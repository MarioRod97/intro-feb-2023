namespace Banking.UnitTest;

public class DummyBonusCalculator : ICanCalculateAccountBonuses
{
    public decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit)
    {
        return 0;
    }
}
