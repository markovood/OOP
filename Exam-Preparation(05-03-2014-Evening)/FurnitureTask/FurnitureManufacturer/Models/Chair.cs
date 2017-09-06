namespace FurnitureManufacturer.Models
{
    using Interfaces;

    public class Chair : Furniture, IChair
    {
        private int numberOfLegs;

        public Chair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs) : 
            base(model, material, price, height)
        {
            this.numberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }
        }

        public override string ToString()
        {
            return string.Format(
                            "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}",
                            this.GetType().Name,
                            this.Model,
                            this.Material,
                            this.Price,
                            this.Height,
                            this.NumberOfLegs);
        }
    }
}
