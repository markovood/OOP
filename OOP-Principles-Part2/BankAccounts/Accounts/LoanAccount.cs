namespace BankAccounts.Accounts
{
    using System;
    using Customers;

    public class LoanAccount : Account
    {
        private readonly decimal payment;

        private decimal returnAmount;

        private decimal loanAmount;

        public LoanAccount(Customer customer, decimal loanAmount, double interestRate, byte loanPeriod)
            : base(customer, loanPeriod, interestRate)
        {
            this.LoanAmount = loanAmount;
            this.returnAmount = this.DefineReturnAmount(this.LoanAmount, loanPeriod);
            this.payment = this.ReturnAmount / this.PeriodInMonths;
        }

        public decimal ReturnAmount
        {
            get
            {
                return this.returnAmount;
            }
        }

        public decimal LoanAmount
        {
            get
            {
                return this.loanAmount;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ApplicationException("Negative loan amount is impossible".ToUpper());
                }

                this.loanAmount = value;
            }
        }

        public void MakePayment()
        {
            if (this.payment < 0)
            {
                throw new ApplicationException("Cannot make payment with negative amount!!!".ToUpper());
            }

            if (this.Balance < this.payment)
            {
                throw new ApplicationException("Not enough cash in the account".ToUpper());
            }

            Console.WriteLine("processing funds...");
            this.returnAmount -= this.payment;
            this.Balance -= this.payment;
        }

        public override decimal CalculateInterestAmount(byte period)
        {
            // Loan accounts have no interest for the first 3 months if are held by individuals and for the first 2 months if are
            // held by a company.
            const byte FREE_PERIOD_FOR_INDIVIDUALS = 3;
            const byte FREE_PERIOD_FOR_COMPANIES = 2;

            if (this.Customer is Individual)
            {
                if (period <= FREE_PERIOD_FOR_INDIVIDUALS)
                {
                    return 0m;
                }
                else
                {
                    period -= FREE_PERIOD_FOR_INDIVIDUALS;
                    return this.LoanAmount * (decimal)(this.InterestRate / 100 / 12) * period;
                }
            }
            else
            {
                if (period <= FREE_PERIOD_FOR_COMPANIES)
                {
                    return 0m;
                }
                else
                {
                    period -= FREE_PERIOD_FOR_COMPANIES;
                    return this.LoanAmount * (decimal)(this.InterestRate / 100 / 12) * period;
                }
            }
        }

        private decimal DefineReturnAmount(decimal amountGranted, byte loanPeriod)
        {
            return amountGranted + this.CalculateInterestAmount(loanPeriod);
        }
    }
}
