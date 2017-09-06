namespace FurnitureManufacturer.Models
{
    using Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal ConvertedHeight = 0.10m;
        private readonly decimal normalHeight;
        private bool isConverted;

        public ConvertibleChair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs) : 
            base(model, material, price, height, numberOfLegs)
        {
            this.normalHeight = this.Height;
            this.isConverted = false;
        }

        public bool IsConverted
        {
            get
            {
                return this.isConverted;
            }
        }

        public void Convert()
        {
            if (!this.IsConverted)
            {
                this.Height = ConvertedHeight;
                this.isConverted = true;
            }
            else
            {
                this.Height = this.normalHeight;
                this.isConverted = false;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}, State: {6}",
                this.GetType().Name,
                this.Model,
                this.Material,
                this.Price,
                this.Height, 
                this.NumberOfLegs,
                this.IsConverted ? "Converted" : "Normal");
        }
    }
}
