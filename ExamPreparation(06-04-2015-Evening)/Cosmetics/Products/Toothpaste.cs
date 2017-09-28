namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Contracts;
    using Common;

    public class Toothpaste : Product, IToothpaste
    {
        private IList<string> toothpasteIngredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients) :
            base(name, brand, price, gender)
        {
            this.toothpasteIngredients = ingredients;
            this.Ingredients = SetIngredients(toothpasteIngredients);
        }

        public string Ingredients { get; private set; }

        public override string Print()
        {
            string description = string.Format(
                "{0}  * Ingredients: {1}",
                Environment.NewLine,
                this.Ingredients);

            return base.Print() + description;
        }

        private string SetIngredients(IList<string> ingredients)
        {
            int minLength = 4;
            int maxLength = 12;
            foreach (var ingredient in ingredients)
            {
                Validator.CheckIfStringLengthIsValid(
                    ingredient,
                    maxLength,
                    minLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Each ingredient", minLength, maxLength));
            }

            return string.Join(", ", ingredients);
        }
    }
}
