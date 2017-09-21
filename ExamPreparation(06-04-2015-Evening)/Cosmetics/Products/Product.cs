namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Common;
    using Contracts;

    public abstract class Product : IProduct
    {
        private string name;
        private string brand;
        private decimal price;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                    string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Brand"));

                int minLength = 2;
                int maxLength = 10;
                Validator.CheckIfStringLengthIsValid(
                    value,
                    maxLength,
                    minLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Product brand", minLength, maxLength));

                this.brand = value;
            }
        }

        public GenderType Gender { get; private set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                    string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Name"));

                int minLength = 3;
                int maxLength = 10;
                Validator.CheckIfStringLengthIsValid(
                    value,
                    maxLength,
                    minLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Product name", minLength, maxLength));

                this.name = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be negative or 0!");
                }

                this.price = value;
            }
        }

        public virtual string Print()
        {
            string description = string.Format(
                "- {0} - {1}:{2}  * Price: ${3}{2}  * For gender: {4}",
                this.Brand,
                this.Name,
                Environment.NewLine,
                this.Price,
                this.Gender);

            return description;
        }
    }
}
