using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuclidianPoint;
using GenericClass;

namespace Test
{
    class TestingPrgm
    {
        static void Main(string[] args)
        {
            // tasks 1-4
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
            var somePath = PathStorage.LoadPath(@"../../pointsList.txt");

            // tasks 5-7
            var list = new GenericList<Point3D>(16);
            list.Add(new Point3D(3, 2, 1));
            list.Add(new Point3D(6, 2, 0));
            list.Add(new Point3D(9, 4, 1));
            list.Add(new Point3D(12, 2, 11));
            list.Add(new Point3D(11, 1, 90));
            list.Add(new Point3D(8, 3, 100));
            // testing validations uncomment to see result
            // var element = list[-1];
            // var element = list[9];
            // list[-1] = Point3D.PointO;
            // list[9] = Point3D.PointO;
            var elementToRemove = list[2];
            int listCount = list.Count;
            // testing validations uncomment to see result
            // list.RemoveAt(-1);
            // list.RemoveAt(9);
            list.RemoveAt(2);
            listCount = list.Count;
            list.Add(elementToRemove);
            listCount = list.Count;
            var elementToInsert = new Point3D(3, 3, 3);
            list.Insert(2, elementToInsert);
            // testing validations uncomment to see result
            // list.Insert(8, elementToInsert);
            list.Insert(7, elementToInsert);
            // testing Clear() uncomment to see result
            // list.Clear();
            int elementToInsIndex = list.IndexOf(elementToInsert);  // will return -1 always cause we've cleared the list the previous step
            Console.WriteLine(list);

            list.Add(new Point3D(3, 2, 1));
            list.Add(new Point3D(1, 1, 1));
            list.Add(new Point3D(2, 2, 2));
            list.Add(new Point3D(33, 33, 33));
            list.Add(new Point3D(44, 55, 66));
            list.Add(new Point3D(100, 101, 102));
            list.Add(new Point3D(22, 22, 22));
            list.Add(new Point3D(77, 33, 77));
            // testing EnsureCapacity() in .Add() and in .Insert()
            list.Add(new Point3D(99, 55, 88));
            // list.Insert(16, new Point3D(99, 55, 88));

        }
    }
}
