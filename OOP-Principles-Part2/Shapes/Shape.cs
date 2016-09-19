namespace Shapes
{
    using System;

    public abstract class Shape
    {
        private double width;

        private double heigth;

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("WIDTH CANNOT BE LESS THAN OR EQUAL TO 0!");
                }

                this.width = value;
            }
        }

        public double Heigth
        {
            get
            {
                return this.heigth;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("HEIGTH CANNOT BE SET TO NEGATIVE OR 0!");
                }

                this.heigth = value;
            }
        }

        public abstract double CalculateSurface();
    }
}