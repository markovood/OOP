namespace EuclidianPoint
{
    using System;
    using CustomAttributes;

    [Version(1, 1)]
    public static class PointCalculations
    {
        public static double CalcDistance(Point3D somePoint, Point3D anotherpoint)
        {
            double result = Math.Sqrt(Math.Pow(anotherpoint.PointX - somePoint.PointX, 2) + Math.Pow(anotherpoint.PointY - somePoint.PointY, 2) + Math.Pow(anotherpoint.PointZ - somePoint.PointZ, 2));
            return result;
        }
    }
}