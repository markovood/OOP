namespace BankAccounts.Customers
{
    using System;

    public abstract class Customer : IContact
    {
        private string name;

        protected Customer(string name)
        {
            this.Name = name;
            this.Address = "Unknown";
            this.Tel = "Unspecified";
        }

        protected Customer(string name, string tel)
        {
            this.Name = name;
            this.Address = "Unknown";
            this.Tel = tel;
        }

        protected Customer(string name, string address, string tel)
        {
            this.Name = name;
            this.Address = address;
            this.Tel = tel;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public string Address { get; set; }

        public string Tel { get; set; }
    }
}
