namespace BankAccounts.Customers
{
    using System;

    public class Company : Customer
    {
        private string taxNumber;

        private string owner;

        public Company(string name)
            : base(name)
        {
            this.Owner = "Unknown";
            this.TaxNumber = "Not registered";
        }

        public Company(string name, string tel)
            : base(name, tel)
        {
            this.Owner = "Unknown";
            this.TaxNumber = "Not registered";
        }

        public Company(string name, string address, string tel)
            : base(name, address, tel)
        {
            this.Owner = "Unknown";
            this.TaxNumber = "Not registered";
        }

        public string TaxNumber
        {
            get
            {
                return this.taxNumber;
            }

            set
            {
                if (false)
                {
                    // some validation for tax numbers
                    throw new NotImplementedException();
                }

                this.taxNumber = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Owner cannot assign null or empty!");
                }

                this.owner = value;
            }
        }
    }
}
