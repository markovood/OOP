using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuclidianPoint;
using GenericClass;
using Matrix;
using CustomAttributes;

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
            Console.WriteLine("The coordinate system starts at: {0}", coordinateSysStartPt);

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
            list.Clear();
            int elementToInsIndex = list.IndexOf(elementToInsert);  // will return -1 always cause we've cleared the list the previous line
            Console.WriteLine(list);

            list.Add(new Point3D(3, 2, 1));
            list.Add(new Point3D(1, 1, 1));
            list.Add(new Point3D(2, 2, 2));
            list.Add(new Point3D(33, 33, 33));
            list.Add(new Point3D(44, 55, 66));
            list.Add(new Point3D(100, 101, 102));
            list.Add(new Point3D(22, 22, 22));
            list.Add(new Point3D(77, 33, 77));
            list.Add(new Point3D(1, 1, 1));
            list.Add(new Point3D(1, 33, 77));
            list.Add(new Point3D(1, 1, 77));
            // testing EnsureCapacity() in .Add() and in .Insert()
            list.Add(new Point3D(99, 55, 88));
            // list.Insert(16, new Point3D(99, 55, 88));
            var minPoint = list.Min();
            var maxPoint = list.Max();

            // testing GenericList with different types
            var anotherNewList = new GenericList<int>(7);
            anotherNewList.Add(1);
            anotherNewList.Add(20);
            anotherNewList.Add(-2);
            anotherNewList.Add(0);
            anotherNewList.Add(-11);
            anotherNewList.Add(300);
            anotherNewList.Add(-100);
            anotherNewList.Add(1985);
            var minInt = anotherNewList.Min();
            var maxInt = anotherNewList.Max();

            var newList = new GenericList<string>(7);
            newList.Add("abc");
            newList.Add("a");
            newList.Add("bca");
            newList.Add("ABC");
            newList.Add("cBa");
            newList.Add("A");
            newList.Add("fuck");
            var minString = newList.Min();
            var maxString = newList.Max();

            var otherList = new GenericList<bool>(7);
            otherList.Add(true);
            otherList.Add(false);
            otherList.Add(false);
            otherList.Add(true);
            otherList.Add(true);
            otherList.Add(false);
            otherList.Add(true);
            otherList.Add(false);
            var minBool = otherList.Min();
            var maxBool = otherList.Max();

            var someOtherList = new GenericList<float>(7);
            someOtherList.Add(1.1f);
            someOtherList.Add(2.2f);
            someOtherList.Add(-8.5f);
            someOtherList.Add(-100f);
            someOtherList.Add(1000f);
            someOtherList.Add(12.1f);
            someOtherList.Add(-12.5f);
            someOtherList.Add(4.35f);
            someOtherList.Add(10.1f);
            var minFloat = someOtherList.Min();
            var maxFloat = someOtherList.Max();

            // tasks 8-10
            var firstMatrix = new Matrix<float>(3, 4);
            firstMatrix[0, 0] = 0.123456f;
            firstMatrix[1, 1] = 1.5f;
            firstMatrix[2, 2] = 3f;
            // testing validations
            // firstMatrix[3, 3] = 8.5f;
            // firstMatrix[-1, 0] = -0.1f;
            // float number = firstMatrix[-1, 0];
            // float number = firstMatrix[0, -1];
            var secondMatrix = new Matrix<float>(3, 4);
            secondMatrix[0, 0] = 0.876544f;
            secondMatrix[1, 1] = 1.5f;
            secondMatrix[2, 2] = 0.3f;
            // otherMatrix[3, 2] = 1.23f;

            var sum = firstMatrix + secondMatrix;
            var difference = firstMatrix - secondMatrix;
            Console.WriteLine(firstMatrix);
            Console.WriteLine(secondMatrix);
            Console.WriteLine(sum);
            Console.WriteLine(difference);

            var twoX3 = new Matrix<int>(2, 3);
            int count = 1;
            for (int i = 0; i < twoX3.Rows; i++)
            {
                for (int j = 0; j < twoX3.Cols; j++)
                {
                    twoX3[i, j] = count;
                    count++;
                }
            }

            Console.WriteLine(twoX3);

            var threeX2 = new Matrix<int>(3, 2);
            for (int i = 0; i < threeX2.Rows; i++)
            {
                for (int j = 0; j < threeX2.Cols; j++)
                {
                    threeX2[i, j] = count;
                    count++;
                }
            }

            Console.WriteLine(threeX2);

            var product = twoX3 * threeX2;
            Console.WriteLine(product);

            // testing operators true/false
            if (twoX3) // if (firstMatrix)
            {
                Console.WriteLine("There are some zero elements in this matrix!!!");
                Console.WriteLine(firstMatrix);
            }
            else
            {
                Console.WriteLine("There are no zero elements in this matrix");
                Console.WriteLine(twoX3);
            }

            // task 10
            var attributes = typeof(Matrix<int>).GetCustomAttributes(typeof(VersionAttribute), false);
            string className = "Matrix<T>";
            foreach (var attribute in attributes)
            {
                Console.WriteLine("class {0} current version: {1}", className, attribute);
            }
        }
    }
}
