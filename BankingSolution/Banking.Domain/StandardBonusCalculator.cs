namespace Banking.Domain
{
    public class StandardBonusCalculator : ICanCalculateAccountBonuses
    {
        private IProvideTheBusinessClock _businessClock;

        public StandardBonusCalculator(IProvideTheBusinessClock businessClock)
        {
            _businessClock = businessClock;
        }
        
        public decimal GetDepositBonusFor(decimal _balance, decimal amountToDeposit)
        {
            return EligibleForBonus(_balance) ? amountToDeposit * .10m : 0;
        }

        private bool EligibleForBonus(decimal _balance)
        {
            return _balance >= 5000 && _businessClock.IsDuringBusinessHours();
        }
    }
}