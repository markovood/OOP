namespace GSMClass
{
    using System;

    public class Display
    {
        // fields
        private double size;
        private int numOfColors;

        // constructors
        public Display()
        {
            this.Size = 2.4;
            this.NumberOfColors = 2;
        }

        public Display(double _size)
        {
            this.Size = _size;
            this.NumberOfColors = 2;
        }

        public Display(int _numberOfColors)
        {
            this.Size = 2.4;
            this.NumberOfColors = _numberOfColors;
        }

        public Display(double _size, int _numberOfColors)
        {
            this.Size = _size;
            this.NumberOfColors = _numberOfColors;
        }

        // properties
        public double Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value > 0)
                {
                    this.size = value;
                }
                else
                {
                    throw new ArgumentException("size cannot be negative or zero");
                }
            }
        }

        public int NumberOfColors
        {
            get
            {
                return this.numOfColors;
            }

            set
            {
                if (value > 0)
                {
                    this.numOfColors = value;
                }
                else
                {
                    throw new ArgumentException("colors cannot be less than one");
                }
            }
        }

        // methods
        public override string ToString()
        {
            string summary = "*DISPLAY CHARACTERISTICS*\r\nSize: {0} inches,\r\nColors: {1}\r\n\r\n";
            string descripion = string.Format(summary, this.Size, this.NumberOfColors);
            return descripion;
        }
    }
}