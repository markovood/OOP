namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Cosmetics.Contracts;
    using Common;

    public class Category : ICategory
    {
        private string name;
        private List<IProduct> products;

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                    string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Name"));

                int minLength = 2;
                int maxLength = 15;
                Validator.CheckIfStringLengthIsValid(
                    value,
                    maxLength,
                    minLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Category name", minLength, maxLength));

                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(
                cosmetics,
                string.Format(GlobalErrorMessages.ObjectCannotBeNull, "cosmetics"));

            this.products.Add(cosmetics);
        }

        public string Print()
        {
            SortProducts();
            StringBuilder currentCategory = new StringBuilder();
            currentCategory.Append(string.Format(
                "{0} category - {1} {2} in total",
                this.Name,
                this.products.Count,
                this.products.Count == 1 ? "product" : "products"));

            for (int i = 0; i < this.products.Count; i++)
            {
                currentCategory.Append(Environment.NewLine + products[i].Print());
            }

            return currentCategory.ToString();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            bool isSuccessful = this.products.Remove(cosmetics);
            if (!isSuccessful)
            {
                throw new ArgumentException(string.Format("Product {0} does not exist in category {1}!", cosmetics.Name, this.Name));
            }
        }

        private void SortProducts()
        {
            this.products = this.products.OrderBy(p => p.Brand).ThenByDescending(p => p.Price).ToList();
        }
    }
}
