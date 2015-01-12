using System;
using System.Collections.Generic;

namespace Test
{
    class Test
    {
        static void Main()
        {
            IDictionary<TestClass, int> marks = new Dictionary<TestClass, int>();

            TestClass test1 = new TestClass("test1");
            Console.WriteLine(test1.GetHashCode());
            TestClass test2 = new TestClass("test2");
            Console.WriteLine(test2.GetHashCode());
            TestClass test3 = new TestClass("test3");

            marks[test1] = 1;
            marks[test2] = 2;
            marks[test3] = 3;

            Console.WriteLine(marks[test1]);
            Console.WriteLine(marks[test2]);

            List<int> vonkoList = new List<int>() { 4};
            List<int> conkoList = new List<int>() { 1,2,3};

            vonkoList.AddRange(conkoList);

            for (int i = vonkoList.Count - 1; i >= 0; i--)
            {
                if (conkoList.Contains(vonkoList[i]))
                {
                    vonkoList.Remove(vonkoList[i]);
                }
            }

            Console.WriteLine(string.Join(",", vonkoList));

            SortedSet<int> vonkoSet = new SortedSet<int>();

            HashSet<>
        }
    }
}
