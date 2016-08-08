namespace EuclidianPoint
{
    using System.Collections.Generic;
    using CustomAttributes;

    [Version(1, 0)]
    public class Path
    {
        // fields
        private List<Point3D> sequenceOfPoints;

        // constructors
        public Path()
        {
            this.sequenceOfPoints = new List<Point3D>();
        }

        // methods
        public void AddPoint(Point3D point)
        {
            this.sequenceOfPoints.Add(point);
        }

        public void RemovePoint(Point3D point)
        {
            this.sequenceOfPoints.Remove(point);
        }

        public void ClearList(Point3D point)
        {
            this.sequenceOfPoints.Clear();
        }

        public override string ToString()
        {
            return string.Join("; ", this.sequenceOfPoints);
        }
    }
}