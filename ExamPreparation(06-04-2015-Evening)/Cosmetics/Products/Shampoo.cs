namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Common;
    using Contracts;

    public class Shampoo : Product, IShampoo
    {
        private uint milliliters; 

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage) :
            base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        public uint Milliliters
        {
            get
            {
                return this.milliliters;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot set quantity with negative or 0!");
                }

                this.milliliters = value;
            }
        }
        
        public UsageType Usage { get; private set; }

        public override decimal Price
        {
            get
            {
                return base.Price * this.Milliliters;
            }
        }

        public override string Print()
        {
            string description = string.Format(
                "{1}  * Quantity: {0} ml{1}  * Usage: {2}",
                this.Milliliters,
                Environment.NewLine,
                this.Usage);

            return base.Print() + description;
        }
    }
}
