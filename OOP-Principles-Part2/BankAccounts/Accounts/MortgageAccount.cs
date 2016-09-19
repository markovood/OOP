namespace BankAccounts.Accounts
{
    using System;
    using Customers;

    public class MortgageAccount : Account
    {
        private readonly decimal payment;

        private decimal returnAmount;

        private decimal mortgageAmount;

        public MortgageAccount(Customer customer, decimal mortgageValue, double interestRate, byte mortgagePeriod)
            : base(customer, mortgagePeriod, interestRate)
        {
            this.MortgageAmount = mortgageValue;
            this.returnAmount = this.DefineReturnAmount(mortgageValue, mortgagePeriod);
            this.payment = this.ReturnAmount / this.PeriodInMonths;
        }

        public decimal ReturnAmount
        {
            get
            {
                return this.returnAmount;
            }
        }

        public decimal MortgageAmount
        {
            get
            {
                return this.mortgageAmount;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ApplicationException("Negative loan amount is impossible".ToUpper());
                }

                this.mortgageAmount = value;
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
            // Mortgage accounts have ½ interest for the first 12 months for companies and no interest for the first 6 months
            // for individuals.
            const byte OFFER_PERIOD_FOR_INDIVIDUALS = 6;
            const byte OFFER_PERIOD_FOR_COMPANIES = 12;

            if (this.Customer is Individual)
            {
                if (period <= OFFER_PERIOD_FOR_INDIVIDUALS)
                {
                    return 0m;
                }
                else
                {
                    period -= OFFER_PERIOD_FOR_INDIVIDUALS;
                    return this.MortgageAmount * (decimal)(this.InterestRate / 100 / 12) * period;
                }
            }
            else
            {
                if (period <= OFFER_PERIOD_FOR_COMPANIES)
                {
                    return (this.MortgageAmount * (decimal)(this.InterestRate / 100 / 12) * period) / 2;
                }
                else
                {
                    decimal interestForTheOfferPeriod = (this.MortgageAmount * (decimal)(this.InterestRate / 100 / 12) * OFFER_PERIOD_FOR_COMPANIES) / 2;
                    period -= OFFER_PERIOD_FOR_COMPANIES;
                    return interestForTheOfferPeriod + (this.MortgageAmount * (decimal)(this.InterestRate / 100 / 12) * period);
                }
            }
        }

        private decimal DefineReturnAmount(decimal amountGranted, byte period)
        {
            return amountGranted + this.CalculateInterestAmount(period);
        }
    }
}
