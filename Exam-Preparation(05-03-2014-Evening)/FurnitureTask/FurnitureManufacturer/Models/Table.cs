namespace FurnitureManufacturer.Models
{
    using System;

    using Interfaces;

    public class Table : Furniture, ITable
    {
        private decimal length;
        private decimal width;

        public Table(string model, MaterialType material, decimal price, decimal height, decimal length, decimal width) : 
            base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Area
        {
            get
            {
                return this.length * this.width;
            }
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot set negative or 0 for length!");
                }

                this.length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot set negative or 0 for width!");
                }

                this.width = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Length: {5}, Width: {6}, Area: {7}",
                this.GetType().Name, 
                this.Model,
                this.Material,
                this.Price,
                this.Height,
                this.Length,
                this.Width, 
                this.Area);
        }
    }
}
