namespace BankAccounts.Accounts
{
    using System;
    using Customers;

    public abstract class Account
    {
        private readonly DateTime dateCreated;

        private decimal balance;

        private double interestRate; // in % for a year

        protected Account(Customer customer, byte periodInMonths, double interestRate)
        {
            this.Customer = customer;
            this.InterestRate = interestRate;
            this.Balance = 0;
            this.dateCreated = DateTime.Now;
            this.PeriodInMonths = periodInMonths;
        }

        protected Account(Customer customer, decimal balance)
        {
            this.Customer = customer;
            this.InterestRate = 0;
            this.Balance = balance;
            this.dateCreated = DateTime.Now;
            this.PeriodInMonths = 0;
        }

        protected Account(Customer customer, decimal balance, double interestRate, byte periodInMonths)
        {
            this.Customer = customer;
            this.InterestRate = interestRate;
            this.Balance = balance;
            this.dateCreated = DateTime.Now;
            this.PeriodInMonths = periodInMonths;
        }

        protected Account(Customer customer, decimal balance, double interestRate)
        {
            this.Customer = customer;
            this.InterestRate = interestRate;
            this.Balance = balance;
            this.dateCreated = DateTime.Now;
            this.PeriodInMonths = 0;
        }

        public Customer Customer { get; set; }

        public double InterestRate
        {
            get
            {
                return this.interestRate;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.interestRate = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            set
            {
                if (value < 0)
                {
                    throw new ApplicationException("Cannot have negative balance!!!".ToUpper());
                }

                this.balance = value;
            }
        }

        public DateTime DateCreated
        {
            get
            {
                return this.dateCreated;
            }
        }

        public byte PeriodInMonths { get; private set; }

        public virtual void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ApplicationException("You are trying to deposit negative amount!!!".ToUpper());
            }

            Console.WriteLine("depositing funds...");
            this.Balance += amount;
        }

        public virtual decimal CalculateInterestAmount(byte period)
        {
            // interest rate is % that's why it's / 100 and because it's for a year that's why it's / 12
            return this.Balance * (decimal)(this.InterestRate / 100 / 12) * period;
        }
    }
}
