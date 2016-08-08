namespace EuclidianPoint
{
    using System;
    using System.Text;
    using CustomAttributes;

    [Version(1, 0)]
    public struct Point3D : IComparable
    {
        // fields
        private static readonly Point3D pointO = new Point3D(0, 0, 0);

        private int pointX;
        private int pointY;
        private int pointZ;

        // constructors
        public Point3D(int x, int y, int z)
        {
            this.pointX = x;
            this.pointY = y;
            this.pointZ = z;
        }

        // properties
        public static Point3D PointO
        {
            get
            {
                return pointO;
            }
        }

        public int PointX
        {
            get { return this.pointX; }
            set { this.pointX = value; }
        }

        public int PointY
        {
            get { return this.pointY; }
            set { this.pointY = value; }
        }

        public int PointZ
        {
            get { return this.pointZ; }
            set { this.pointZ = value; }
        }

        // methods
        public static Point3D Parse(string someText)
        {
            //// Point(x0,y0,z0)

            StringBuilder coordinateX = new StringBuilder();
            int coordXIndex = someText.IndexOf('x') + 1;
            //// when coordinate is more than one digit
            while (char.IsDigit(someText[coordXIndex]))
            {
                coordinateX.Append(someText[coordXIndex]);
                coordXIndex++;
            }

            StringBuilder coordinateY = new StringBuilder();
            int coordYIndex = someText.IndexOf('y') + 1;
            //// when coordinate is more than one digit
            while (char.IsDigit(someText[coordYIndex]))
            {
                coordinateY.Append(someText[coordYIndex]);
                coordYIndex++;
            }

            StringBuilder coordinateZ = new StringBuilder();
            int coordZIndex = someText.IndexOf('z') + 1;
            //// when coordinate is more than one digit
            while (char.IsDigit(someText[coordZIndex]))
            {
                coordinateZ.Append(someText[coordZIndex]);
                coordZIndex++;
            }

            var point = new Point3D(
                int.Parse(coordinateX.ToString()),
                int.Parse(coordinateY.ToString()),
                int.Parse(coordinateZ.ToString()));

            return point;
        }

        public override string ToString()
        {
            return string.Format("Point(x{0},y{1},z{2})", this.PointX, this.PointY, this.PointZ);
        }

        // interface implementation
        public int CompareTo(object obj)
        {
            // implementation is needed in order to make GenericList list accept Point3D as element type
            var objToCompare = (Point3D)obj;
            if (this.pointX > objToCompare.pointX)
            {
                return 1;
            }
            else if (this.pointX < objToCompare.pointX)
            {
                return -1;
            }
            else
            {
                // coordsX are equal
                if (this.pointY > objToCompare.pointY)
                {
                    return 1;
                }
                else if (this.pointY < objToCompare.pointY)
                {
                    return -1;
                }
                else
                {
                    // coordsY are equal
                    if (this.pointZ > objToCompare.pointZ)
                    {
                        return 1;
                    }
                    else if (this.pointZ < objToCompare.pointZ)
                    {
                        return -1;
                    }
                    else
                    {
                        // coordsZ are equal, so the points are equal
                        return 0;
                    }
                }
            }

        }
    }
}