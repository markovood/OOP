namespace BankAccounts.Customers
{
    using System;

    public class Individual : Customer
    {
        private ulong egn;

        public Individual(string name)
            : base(name)
        {
        }

        public Individual(string name, string tel)
            : base(name, tel)
        {
        }

        public Individual(string name, string address, string tel)
            : base(name, address, tel)
        {
        }

        public ulong EGN
        {
            get
            {
                return this.egn;
            }

            set
            {
                if (value.ToString().Length > 10)
                {
                    throw new ArgumentOutOfRangeException("EGN", "Must have exactly 10 numbers");
                }

                this.egn = value;
            }
        }
    }
}
