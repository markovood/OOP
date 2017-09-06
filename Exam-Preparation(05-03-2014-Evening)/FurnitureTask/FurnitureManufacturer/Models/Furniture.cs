namespace FurnitureManufacturer.Models
{
    using System;

    using Interfaces;

    public class Furniture : IFurniture
    {
        private string model;
        private MaterialType material;
        private decimal price;
        private decimal height;

        public Furniture(string model, MaterialType material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = height;
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot set height with negative or 0 value!");
                }

                this.height = value;
            }
        }

        public MaterialType Material
        {
            get
            {
                return this.material;
            }

            set
            {
                this.material = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("model", "Cannot set model with null!");
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException("Cannot set model with empty string!");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Cannot set model with less than 3 chars!");
                }

                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot set price with negative or 0 value!");
                }

                this.price = value;
            }
        }
    }
}
