namespace Banking.Domain;

public interface ICanCalculateAccountBonuses
{
    decimal GetDepositBonusFor(decimal _balance, decimal amountToDeposit);
}