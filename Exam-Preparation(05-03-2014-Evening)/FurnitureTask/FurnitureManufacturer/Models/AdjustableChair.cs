namespace FurnitureManufacturer.Models
{
    using Interfaces;

    public class AdjustableChair : Chair, IAdjustableChair
    {
        public AdjustableChair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs) : 
            base(model, material, price, height, numberOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            this.Height = height;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
