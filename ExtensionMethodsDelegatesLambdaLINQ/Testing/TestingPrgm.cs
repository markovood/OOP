namespace Testing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Group;
    using MyExtensions;
    using MyTimer;
    using Student;

    public class TestingPrgm
    {
        public static void Main()
        {
            // task 1
            var strB = new StringBuilder("Bate Goiko e velik!!!");
            var resultTask1 = strB.Substring(11, 10);

            // task 2
            var arr = new List<string>();
            arr.Add("abc");
            arr.Add("cba");
            arr.Add("a");
            arr.Add("ABC");
            arr.Add("A");
            var sumOfAll = arr.MySum();
            // var productOfAll = arr.MyProduct(); // not working on strings
            var minElement = arr.MyMin();
            var maxElement = arr.MyMax();
            // var average = arr.MyAverage(); // not working on strings

            var arr1 = new List<float>();
            arr1.Add(1.1f);
            arr1.Add(2.2f);
            arr1.Add(3.3f);
            arr1.Add(4.4f);
            arr1.Add(5.5f);
            var sumFloat = arr1.MySum();
            var productFloat = arr1.MyProduct();
            var minFloat = arr1.MyMin();
            var maxFloat = arr1.MyMax();
            var averageFloat = arr1.MyAverage();

            var arr2 = new List<int>();
            arr2.Add(1);
            arr2.Add(2);
            arr2.Add(3);
            arr2.Add(4);
            arr2.Add(5);
            var sumInt = arr2.MySum();
            var productInt = arr2.MyProduct();
            var minInt = arr2.MyMin();
            var maxInt = arr2.MyMax();
            var averageInt = arr2.MyAverage();

            var arr3 = new List<decimal>();
            arr3.Add(1.1m);
            arr3.Add(2.2m);
            arr3.Add(3.3m);
            arr3.Add(4.4m);
            arr3.Add(5.5m);
            var sumDecimal = arr3.MySum();
            var productDecimal = arr3.MyProduct();
            var minDecimal = arr3.MyMin();
            var maxDecimal = arr3.MyMax();
            var averageDecimal = arr3.MyAverage();

            // tasks 3-5
            var students = new Student[]
            {
                new Student("Gosho" , "Goshev" , 31),
                new Student("Pesho" , "Kotev" , 17),
                new Student("Razvan" , "Sima" , 19),
                new Student("Damian" , "Adamczik" , 18),
                new Student("Marto" , "Stoichkov" , 23),
                new Student("Gosho" , "Mishov" , 19),
                new Student("Marian" , "Peshev" , 23),
            };

            // task 3 - Write a method that from a given array of students finds all students whose first name is before its last
            // name alphabetically.
            var resultTask3 = Student.FirstNameBeforeLast(students);

            // task 4 - Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
            var resultTask4 =
                from student in students
                where student.Age > 18 && student.Age < 24
                select student.FullName;

            // task 5 - Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name
            // and last name in descending order.
            var resultTask5 = students.OrderByDescending(n => n.FirstName).ThenByDescending(n => n.LastName);

            // Rewrite the same with LINQ.
            var _resultTask5 =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;

            // task 6 - Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. Use the
            // built-in extension methods and lambda expressions.
            int[] arrOfInts = { 1, 17, 21, 3, 7, 11, 12, 49, 42 };
            var intsDivisable = arrOfInts
                                .Where(x => (x % 7 == 0) && (x % 3 == 0))
                                .ToArray();

            // Rewrite the same with LINQ.
            var _intsDivisible =
                from num in arrOfInts
                where (num % 7 == 0) && (num % 3 == 0)
                select num;

            // task 7 - Using delegates write a class Timer that can execute certain method at each t seconds.
            var timer = new MyTimer(1, 5);
            Action action = SomeMethod;
            action += OtherMethod;
            // timer.Execute(action);

            Action<string> otherAction = SomeOtherMethod;
            otherAction += AnotherOtherMethod;
            // timer.Execute(otherAction, "Zdrasti");

            // task 9 - Create a class Student with properties FirstName, LastName, FN, Tel, Email, Marks (a List), GroupNumber.
            // Create a List<Student> with sample students. Select only the students that are from group number 2. Use LINQ query.
            // Order the students by FirstName.

            var otherStudents = new List<Student>()
            {
                new Student("Gosho","Georgiev","123406A","0893484096","gosho@abv.bg",1),
                new Student("Misho","Georgiev","213456B","0878878878","misho@batkata.bg",1),
                new Student("Dragomira","Angelova","1597067","0888988988","mirka@abv.bg",3),
                new Student("Martin","Stoilov","1234065","+3592789789","marto@mezdra.com.pot",2),
                new Student("Razvan","Sima","9874561","0989132123","dembi@debelia.ro",2),
                new Student("Damian","Adamczik","1201201","02123123","damiancho@polqka.pl",2),
                new Student("Mitio","Pishtova","1515151","0788777888","golia@pishtov.bg",4),
                new Student("Valcho","Kumchev","777777C","064987789","kumcho@valcho.com",1),
                new Student("Kalin","Vrachanski","7987980","0888999888","kalin@vraca.bg",3),
                new Student("Gosho","Georgiev","123456B","0878766555","bai@gosho.bg",2),
                new Student("Richard","Johnson","145145A","+357928296","pesho@mokroto.eu",6)
            };

            // adding some grades to marks list for tests
            otherStudents[0].Marks.Add(6); otherStudents[2].Marks.Add(6); otherStudents[3].Marks.Add(4); otherStudents[4].Marks.Add(2);
            otherStudents[0].Marks.Add(4); otherStudents[2].Marks.Add(6); otherStudents[3].Marks.Add(6); otherStudents[4].Marks.Add(2);
            otherStudents[0].Marks.Add(2); otherStudents[2].Marks.Add(2); otherStudents[3].Marks.Add(3); otherStudents[4].Marks.Add(3);

            var groupNumber2 =
                from student in otherStudents
                where student.GroupNumber == 2
                orderby student.FirstName
                select student;

            foreach (var student in groupNumber2)
            {
                Console.WriteLine(student);
            }

            // task 10 - Implement the previous using the same query expressed with extension methods.
            var _groupNumber2 = otherStudents
                                .Where(st => st.GroupNumber == 2)
                                .OrderBy(st => st.FirstName)
                                .Select(st => st);

            // task 11 - Extract all students that have email in abv.bg. Use string methods and LINQ.
            var studentsABVMail =
                from student in otherStudents
                where student.Email.EndsWith("@abv.bg")
                select student;

            var _studentsABVMail = otherStudents
                                    .Where(st => st.Email.EndsWith("@abv.bg"))
                                    .Select(st => st);

            // task 12 - Extract all students with phones in Sofia. Use LINQ.
            var studentsSofiaTel =
                from student in otherStudents
                where student.Tel.StartsWith("02") || student.Tel.StartsWith("+3592")
                select student;

            var _studentsSofiaTel = otherStudents
                                    .Where(st => st.Tel.StartsWith("02") || st.Tel.StartsWith("+3592"))
                                    .Select(st => st);

            // task 13 - Select all students that have at least one mark Excellent (6) into a new anonymous class that has
            // properties – FullName and Marks. Use LINQ.
            var studentsGrade6 =
                from student in otherStudents
                where student.Marks.Contains(6)
                select new { FullName = student.FullName, Marks = student.Marks };

            var _studentsGrade6 = otherStudents
                                    .Where(st => st.Marks.Contains(6))
                                    .Select(st => new { FullName = st.FullName, Marks = st.Marks });

            foreach (var st in studentsGrade6)
            {
                // they both have 3 marks so print the middle one cause it's different
                Console.WriteLine(st.Marks[1]);
            }

            // task 14 - Write down a similar program that extracts the students with exactly two marks "2". Use extension methods.
            byte theMarkToCount = 2;
            int numberOfMarks = 2;

            var resultTask13 = otherStudents
                                .Where(st => (st.Marks.Count(mark => mark == theMarkToCount)) == numberOfMarks);

            var _resultTask13 = otherStudents
                                .FindAll(st => (st.Marks.Count(mark => mark == theMarkToCount)) == numberOfMarks);

            // task 15 - Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and
            // 6-th digit in the FN).
            var resultTask15 = otherStudents
                                .Where(st => st.FN[4] == '0' && st.FN[5] == '6')
                                .Select(st => st.Marks);

            foreach (var listOfMarks in resultTask15)
            {
                foreach (var mark in listOfMarks)
                {
                    Console.Write(mark + " ");
                }

                Console.WriteLine();
            }

            // task 16 - Create a class Group with properties GroupNumber and DepartmentName. Introduce a property GroupNumber in
            // the Student class. Extract all students from "Mathematics" department. Use the Join operator.
            var someOtherStudents = new List<Student>()
            {
                new Student("Gosho","Georgiev",(byte)1),
                new Student("Misho","Georgiev",(byte)1),
                new Student("Dragomira","Angelova",(byte)3),
                new Student("Martin","Stoilov",(byte)2),
                new Student("Razvan","Sima",(byte)2),
                new Student("Damian","Adamczik",(byte)2),
                new Student("Mitio","Pishtova",(byte)4),
                new Student("Valcho","Kumchev",(byte)1),
                new Student("Kalin","Vrachanski",(byte)3),
                new Student("Pesho","Georgiev",(byte)2),
                new Student("Richard","Johnson",(byte)6)
            };

            var groups = new List<Group>()
            {
                new Group("Mathematics",1),
                new Group("Informatics",2),
                new Group("Life-Style",3),
                new Group("Biology",4),
                new Group("Everything Else",5),
                new Group("International",6)
            };

            // reference for the following query at https://msdn.microsoft.com/en-us/library/bb397941.aspx
            string departmentNeeded = "Mathematics";
            var resulTask16 =
                from student in someOtherStudents
                join _group in groups on student.GroupNumber equals _group.GroupNumber
                where _group.DepartmentName == departmentNeeded
                select new { Name = student.FullName, Department = _group.DepartmentName };

            var finalResultTask16 = resulTask16.ToList();
            if (finalResultTask16.Count != 0)
            {
                foreach (var person in finalResultTask16)
                {
                    Console.WriteLine(person.Name);
                }
            }
            else
            {
                Console.WriteLine("{0} department has no records!", departmentNeeded);
            }

            // task 17 - Write a program to return the string with maximum length from an array of strings. Use LINQ.
            string[] strs =
            {
                "Gosho",
                "Petarcho",
                "Bai Georgi",
                "Stariq dub",
                "Pepi",
                "William",
                "Marti",
                "Scrooge McDuck"
            };

            var maxLength =
                from str in strs
                orderby str.Length descending
                select str;

            Console.WriteLine(maxLength.First());

            var _maxLength = strs.OrderByDescending(s => s.Length).First();

            Console.WriteLine(_maxLength);

            // task 18 - Create a program that extracts all students grouped by GroupNumber and then prints them to the console.
            // Use LINQ. using otherStudents from task 9
            var groupedByGrNum =
                from student in otherStudents
                group student by student.GroupNumber into newGroup
                orderby newGroup.Key
                select newGroup;

            foreach (var group in groupedByGrNum)
            {
                Console.WriteLine(group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }
            }

            // task 19 - Rewrite the previous using extension methods.
            var _groupedByGrNumber = otherStudents.GroupBy(n => n.GroupNumber).OrderBy(gr => gr.Key);

            foreach (var group in _groupedByGrNumber)
            {
                Console.WriteLine(group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }
            }
        }

        public static void SomeMethod()
        {
            Console.WriteLine("Hi");
        }

        public static void OtherMethod()
        {
            Console.WriteLine("Dude");
        }

        public static void SomeOtherMethod(string word)
        {
            Console.WriteLine(word);
        }

        public static void AnotherOtherMethod(string word)
        {
            var reversed = word.Reverse();
            foreach (var symbol in reversed)
            {
                Console.Write(symbol);
            }

            Console.WriteLine();
        }
    }
}