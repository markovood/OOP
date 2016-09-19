namespace BankAccounts.Accounts
{
    using System;
    using Customers;

    public class DepositAccount : Account
    {
        public DepositAccount(Customer customer, decimal depositAmount, double interestRate, byte depositPeriod)
            : base(customer, depositAmount, interestRate, depositPeriod)
        {
        }

        public DepositAccount(Customer customer, decimal depositAmount, double interestRate)
            : base(customer, depositAmount, interestRate)
        {
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ApplicationException("Withdrawing negative amount is impossible!!!".ToUpper());    
            }

            if (this.Balance < amount)
            {
                throw new ApplicationException("Not enough cash in the account!!!".ToUpper());
            }

            Console.WriteLine("withdrawing funds...");
            this.Balance -= amount;
        }

        public override decimal CalculateInterestAmount(byte period)
        {
            return this.Balance < 1000 ? 0m : base.CalculateInterestAmount(period);
        }
    }
}
