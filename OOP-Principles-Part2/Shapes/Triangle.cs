namespace Shapes
{
    public class Triangle : Shape
    {
        public Triangle(double hipotenuse, double heigth)
        {
            this.Width = hipotenuse;
            this.Heigth = heigth;
        }

        public override double CalculateSurface()
        {
            return this.Heigth * this.Width / 2;
        }
    }
}