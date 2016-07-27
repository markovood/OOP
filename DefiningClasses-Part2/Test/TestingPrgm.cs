using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuclidianPoint;

namespace Test
{
    class TestingPrgm
    {
        static void Main(string[] args)
        {
            var point = new Point3D(1, 3, 5);
            var point2 = new Point3D(2, 6, 1);

            Console.WriteLine(point);
            Console.WriteLine(point2);

            var coordinateSysStartPt = Point3D.PointO;
            Console.WriteLine("The coordinate System starts at: {0}", coordinateSysStartPt);

            double distance = PointCalculations.CalcDistance(point, point2);
            Console.WriteLine(distance);

            var pointsCollection = new Path();
            pointsCollection.AddPoint(point);
            pointsCollection.AddPoint(point2);
            pointsCollection.AddPoint(point);
            pointsCollection.AddPoint(point2);
            pointsCollection.AddPoint(point);
            pointsCollection.AddPoint(point2);
            pointsCollection.AddPoint(point);
            pointsCollection.AddPoint(point2);

            PathStorage.SavePath(pointsCollection, @"../../result.txt");
            var somePath = PathStorage.LoadPath(@"../../pointsList.txt"); ;

        }
    }
}
