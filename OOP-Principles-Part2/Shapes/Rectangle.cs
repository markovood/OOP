namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double width, double heigth)
        {
            this.Width = width;
            this.Heigth = heigth;
        }

        public override double CalculateSurface()
        {
            return this.Width * this.Heigth;
        }
    }
}