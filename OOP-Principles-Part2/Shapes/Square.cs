namespace Shapes
{
    public class Square : Shape
    {
        public Square(double side)
        {
            this.Width = side;
            this.Heigth = side;
        }

        public override double CalculateSurface()
        {
            return this.Width * this.Heigth;
        }
    }
}