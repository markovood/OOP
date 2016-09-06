namespace TestingPrgm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using AnimalHierarchy.Animals;
    using AnimalHierarchy.Cats;
    using SchoolClasses;
    using SchoolClasses.Persons;
    using StudentsAndWorkers;

    using Student = SchoolClasses.Persons.Student;
    using StudentFromStudentsAndworkers = StudentsAndWorkers.Student;

    public class Test
    {
        private static int taskNum = 1;

        public static void Main()
        {
            #region task 1
            Separator();

            var school = new School();
            var someClass = new StudentsClass("10Б");
            var otherClass = new StudentsClass("10Г");
            var student = new Student("vankata");
            var teacher = new Teacher("Peshev");
            var person = new Person("Baba Gica");
            var math = new Discipline("Mathematics", 41);
            var informatics = new Discipline("IT", 99, 9999);
            var economy = new Discipline("Economics");
            var geography = new Discipline("Geography");
            var design = new Discipline("Interior Design");
            var biology = new Discipline("Biology");
            string comentar = "нема такова чудо";

            school.Classes.Add(someClass);
            school.Classes.Add(otherClass);

            someClass.Students.Add(new Student("gosho"));
            someClass.Students.Add(new Student("pesho"));
            someClass.Students.Add(new Student("misho"));
            someClass.Teachers.Add(new Teacher("Petrova"));
            someClass.Teachers.Add(new Teacher("Misheva"));
            someClass.Teachers.Add(new Teacher("Gospodinov"));

            otherClass.Students.Add(new Student("gecata"));
            otherClass.Students.Add(new Student("peshaka"));
            otherClass.Students.Add(new Student("mimi"));
            otherClass.Teachers.Add(new Teacher("Augustsson"));
            otherClass.Teachers.Add(new Teacher("Iliev"));
            otherClass.Teachers.Add(new Teacher("Atanasova"));

            school.Classes[0].Teachers[0].Disciplines.Add(math);
            school.Classes[0].Teachers[0].Disciplines.Add(economy);
            school.Classes[0].Teachers[0].Disciplines.Add(geography);
            school.Classes[0].Teachers[1].Disciplines.Add(informatics);
            school.Classes[0].Teachers[1].Disciplines.Add(economy);
            school.Classes[0].Teachers[1].Disciplines.Add(math);
            school.Classes[0].Teachers[2].Disciplines.Add(design);
            school.Classes[0].Teachers[2].Disciplines.Add(biology);
            school.Classes[0].Teachers[2].Disciplines.Add(informatics);

            school.Classes[1].Teachers[1].Disciplines.Add(informatics);
            school.Classes[1].Teachers[1].Disciplines.Add(design);
            school.Classes[1].Teachers[1].Disciplines.Add(math);

            school.Classes[0].Students[1].Comments = comentar;
            Console.WriteLine(school.Classes[0].Students[1].Comments);

            foreach (var cl in school.Classes)
            {
                Console.WriteLine(cl.ID);
                foreach (var tchr in cl.Teachers)
                {
                    Console.WriteLine(tchr.Name);
                    if (tchr.Disciplines.Count == 0)
                    {
                        Console.WriteLine("No disciplines assigned!");
                    }
                    else
                    {
                        foreach (var tchrDiscipline in tchr.Disciplines)
                        {
                            Console.WriteLine(tchrDiscipline);
                        }
                    }

                    Console.WriteLine();    // just for better formatting
                }
            }

            Person[] staff = { student, teacher, person };

            #endregion task 1

            #region task 2
            Separator();

            var st = new StudentFromStudentsAndworkers("Gosho", "Goshev", 6);
            var w = new Worker("Gergana", "Gosheva", 105, 8);
            Human[] people =
            {
                st,
                w
            };

            foreach (var human in people)
            {
                if (human is Worker)
                {
                    var humanAsWorker = human as Worker;
                    Console.WriteLine("{0} {1} {2:F2}", human.FirstName, human.LastName, humanAsWorker.MoneyPerHour());
                }
                else
                {
                    // human is Student
                    var humanAsStudent = human as StudentFromStudentsAndworkers;
                    if (humanAsStudent != null)
                        Console.WriteLine("{0} {1} - {2}", human.FirstName, human.LastName, humanAsStudent.Grade);
                }
            }

            // Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method).
            var listOfStudents = new List<StudentsAndWorkers.Student>()
            {
                new StudentFromStudentsAndworkers("Gosho", "Georgiev", 6),
                new StudentFromStudentsAndworkers("Pesho", "Peshev", 4),
                new StudentFromStudentsAndworkers("Dimitar", "Georgiev", 4),
                new StudentFromStudentsAndworkers("Petq", "Dureva", 3),
                new StudentFromStudentsAndworkers("Mira", "Angelova", 6),
                new StudentFromStudentsAndworkers("Marto", "Stoilov", 5),
                new StudentFromStudentsAndworkers("Misho", "Markov", 4),
                new StudentFromStudentsAndworkers("Dimo", "Georgiev", 2),
                new StudentFromStudentsAndworkers("Darina", "Pavlova", 3),
                new StudentFromStudentsAndworkers("Albena", "Popova", 6)
            };

            var sortedStudents =
                from stud in listOfStudents
                orderby stud.Grade ascending
                select stud;

            var _sortedStudents = listOfStudents.OrderBy(s => s.Grade);

            // Initialize a list of 10 workers and sort them by money per hour in descending order.
            var listOfWorkers = new List<StudentsAndWorkers.Worker>()
            {
                new Worker("Dimitar", "Gospodinov", 250),
                new Worker("Georgi", "Petrovski", 104, 4),
                new Worker("Razvan", "Sima", 100),
                new Worker("Damian", "Adamczik", 200, 6),
                new Worker("Joro", "Goshev", 305),
                new Worker("Elica", "Krasteva", 220, 9),
                new Worker("Valentino", "Rossi", 450),
                new Worker("Dimitar", "Berbatov", 4500),
                new Worker("Irina", "Petrova", 350, 12),
                new Worker("Ivan", "Ivanov", 250, 9)
            };

            var sortedWorkers =
                from worker in listOfWorkers
                orderby worker.MoneyPerHour() descending
                select worker;

            var _sortedWorkers = listOfWorkers.OrderByDescending(wk => wk.MoneyPerHour());

            // Merge the lists and sort them by first name and last name.
            var mergedList = new List<Human>();
            mergedList.AddRange(listOfStudents);
            mergedList.AddRange(listOfWorkers);

            var sortedMergedList =
                from element in mergedList
                orderby element.FirstName, element.LastName
                select element;

            var _sortedMergedList = mergedList.OrderBy(wkr => wkr.FirstName).ThenBy(wkr => wkr.LastName);

            #endregion task 2

            #region task 3
            Separator();

            var dog = new Dog("sharo", "male", 3);
            var frog = new Frog("jabok", "female", 1);
            var kitty = new Kitten("pussy", 1);
            var tommy = new Tomcat("Tommy", 2);

            Console.WriteLine(dog);
            dog.MakeSound();
            Console.WriteLine();
            Thread.Sleep(1500);

            Console.WriteLine(frog);
            frog.MakeSound();
            Console.WriteLine();
            Thread.Sleep(1500);

            Console.WriteLine(kitty);
            kitty.MakeSound();
            Console.WriteLine();
            Thread.Sleep(1500);

            Console.WriteLine(tommy);
            tommy.MakeSound();
            Console.WriteLine();
            Thread.Sleep(1500);

            // Create arrays of different kinds of animals and calculate the average age of each kind of animal using a static
            // method (you may use LINQ).
            Animal[] animals =
            {
                new Dog("Sharo", "male", 2),
                new Kitten("Pussy", 0.7),
                new Dog("Bethoven", "male", 1.7),
                new Kitten("Maca", 0.9),
                new Dog("Maq", "female", 2.3),
                new Frog("Kurmit", "male", 1),
                new Kitten("Linda", 0.2),
                new Frog("Zhabcho", "male", 0.5),
                new Dog("Lassy", "male", 2.5),
                new Frog("KakaJaba", "female", 1.2),
                new Kitten("Bibi", 1),
                new Tomcat("Tommy", 2),
                new Tomcat("Thomas", 2.5),
                new Tomcat("Tom", 1.3)
            };

            // using LINQ
            var splittedByAnimalType =
                from animal in animals
                group animal by animal.GetType().Name;

            // for better display at the console
            Console.WriteLine("The average age at each group is as follows:");
            Console.WriteLine(new string('-', 43));

            foreach (var group in splittedByAnimalType)
            {
                var groupAsArray = group.ToArray();
                double averageAge = Animal.AverageAge(groupAsArray);
                Console.WriteLine("{0,-6} --> {1:F2} years", group.Key, averageAge);
            }

            // same as above but using extension methods
            var _splittedByAnimalType = animals.GroupBy(animal => animal.GetType().Name).ToArray();

            // for better display at the console
            Console.WriteLine();
            Console.WriteLine("The average age at each group is as follows:");
            Console.WriteLine(new string('-', 43));

            foreach (var group in _splittedByAnimalType)
            {
                var groupAsArray = group.ToArray();
                double averageAge = Animal.AverageAge(groupAsArray);
                Console.WriteLine("{0,-6} --> {1:F2} years", group.Key, averageAge);
            }

            #endregion task 3
        }

        public static void Separator()
        {
            if (taskNum == 1)
            {
                Console.WriteLine("--------");
                Console.WriteLine("-TASK {0}-", taskNum);
                Console.WriteLine("--------");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("--------");
                Console.WriteLine("-TASK {0}-", taskNum);
                Console.WriteLine("--------");
                Console.WriteLine();
            }

            taskNum++;
        }
    }
}