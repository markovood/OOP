namespace BankAccounts
{
    using System;
    using System.Collections.Generic;
    using Accounts;
    using Customers;

    public class Bank : IContact
    {
        private readonly List<Customer> customers;

        private readonly List<Account> accounts;
        
        private string name;
        
        public Bank(string name)
        {
            this.Name = name;
            this.Address = "Unknown";
            this.Tel = "Unspecified";
            this.customers = new List<Customer>();
            this.accounts = new List<Account>();
        }

        public Bank(string name, string tel)
        {
            this.Name = name;
            this.Address = "Unknown";
            this.Tel = tel;
            this.customers = new List<Customer>();
            this.accounts = new List<Account>();
        }

        public Bank(string name, string address, string tel)
        {
            this.Name = name;
            this.Address = address;
            this.Tel = tel;
            this.customers = new List<Customer>();
            this.accounts = new List<Account>();
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
                    throw new ArgumentException("Name of the bank cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public string Address { get; set; }

        public string Tel { get; set; }

        public List<Customer> Customers
        {
            get { return new List<Customer>(this.customers); }
        }

        public List<Account> Accounts
        {
            get { return new List<Account>(this.accounts); }
        }

        public void AddCustomer(Customer someCustomer)
        {
            this.customers.Add(someCustomer);
        }

        public void AddRangeOfCustomers(Customer[] customers)
        {
            this.customers.AddRange(customers);
        }

        public void RemoveCustomer(Customer someCustomer)
        {
            this.customers.Remove(someCustomer);
        }

        public void AddAccount(Account someAccount)
        {
            this.accounts.Add(someAccount);
        }

        public void AddRangeOfAccount(Account[] accounts)
        {
            this.accounts.AddRange(accounts);
        }

        public void RemoveAccount(Account someAccount)
        {
            this.accounts.Remove(someAccount);
        }

        public override string ToString()
        {
            return string.Format("{0}\r\n{1}\r\n{2}\r\n", this.Name, this.Address, this.Tel);
        }
    }
}
