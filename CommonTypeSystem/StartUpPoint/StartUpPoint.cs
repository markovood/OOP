using BitArray64_CTS;

namespace StartUpPoint
{
    using System;
    using Person_CTS;
    using Student_CTS;

    public class StartUpPoint
    {
        private static int problemNum = 1;

        public static void Main()
        {
            // problem 1
            SeparateProblems();
            var st = new Student("Pesho", "Ivanov", "Stoianov", 899877123);
            var st1 = new Student("Pesho", "Ivanov", "Stoianov", 123456789);

            Console.WriteLine("TEST ToString()\n\r");
            Console.WriteLine(st);
            Console.WriteLine(st1);

            Console.WriteLine("TEST Equals()\n\r");
            Console.WriteLine(st.Equals(st));
            Console.WriteLine(st1.Equals(st1));

            Console.WriteLine(st.Equals(st1));
            Console.WriteLine(st1.Equals(st));

            Console.WriteLine("TEST GetHashCode()\n\r");
            Console.WriteLine(st.GetHashCode());
            Console.WriteLine(st1.GetHashCode());

            Console.WriteLine("TEST operators '==' and '!='\n\r");
            Console.WriteLine(st == st1);
            Console.WriteLine(st1 == st);

            Console.WriteLine(st != st1);
            Console.WriteLine(st1 != st);

            Console.WriteLine(st == st);
            Console.WriteLine(st1 == st1);

            // problem 2
            SeparateProblems();
            var stCloning = (Student)st.Clone();
            var st1Cloning = (Student)st1.Clone();

            Console.WriteLine("TEST Clone()\n\r");
            Console.WriteLine(st);
            Console.WriteLine(stCloning);
            Console.WriteLine(st == stCloning);
            Console.WriteLine(st1);
            Console.WriteLine(st1Cloning);
            Console.WriteLine(st1 == st1Cloning);

            // problem 3
            SeparateProblems();
            Console.WriteLine("TEST CompareTo()\n\r");
            Console.WriteLine(st.CompareTo(st1));
            Console.WriteLine(st1.CompareTo(st));
            Console.WriteLine(st.CompareTo(st));
            Console.WriteLine(st1.CompareTo(st1));

            // problem 4
            SeparateProblems();
            var somePerson = new Person("Pesho");
            var otherPerson = new Person("Pesho", 31);

            Console.WriteLine("TEST ToString()\n\r");
            Console.WriteLine(somePerson);
            Console.WriteLine(otherPerson);

            // problem 5
            SeparateProblems();
            var someBitArr = new BitArray64(10100100100100100100ul);
            var otherBitArr = new BitArray64(8910891089108910ul);

            Console.WriteLine("TEST IEnumerable<T>\n\r");
            Console.WriteLine("BitArray of {0}", someBitArr.Number);
            int bitPosition = 1;
            foreach (var bit in someBitArr)
            {
                Console.WriteLine("{0}: {1}", bitPosition, bit);
                bitPosition++;
            }

            Console.WriteLine();
            Console.WriteLine("BitArray of {0}", otherBitArr.Number);
            bitPosition = 1;
            foreach (var bit in otherBitArr)
            {
                Console.WriteLine("{0}: {1}", bitPosition, bit);
                bitPosition++;
            }

            Console.WriteLine("TEST Equals()\n\r");
            Console.WriteLine(someBitArr.Equals(otherBitArr));

            Console.WriteLine("TEST GetHashCode()\n\r");
            Console.WriteLine(someBitArr.GetHashCode());
            Console.WriteLine(otherBitArr.GetHashCode());

            Console.WriteLine("TEST Indexer []\n\r");
            Console.WriteLine("someBitArr[0] = {0}", someBitArr[0]);
            Console.WriteLine("changing first element's bit...");
            someBitArr[0] = 1;
            Console.WriteLine("someBitArr[0] = {0}", someBitArr[0]);
            // someBitArr[-1] = 1;
            // someBitArr[someBitArr.Length] = 1;
            // someBitArr[0] = 2;

            Console.WriteLine("TEST operators '==' and '!='\n\r");
            Console.WriteLine(someBitArr == otherBitArr);
            Console.WriteLine(someBitArr != otherBitArr);

            // problem 6
            SeparateProblems();

        }

        private static void SeparateProblems()
        {
            Console.WriteLine(new string('-', 11));
            Console.WriteLine("#Problem {0}#", problemNum);
            Console.WriteLine(new string('-', 11));
            Console.WriteLine();
            problemNum++;
        }
    }
}
