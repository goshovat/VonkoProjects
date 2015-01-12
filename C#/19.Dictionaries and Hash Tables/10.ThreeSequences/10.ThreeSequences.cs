using System;
using System.Collections.Generic;

namespace ThreeSequences
{
    class ThreeSequences
    {
        static void Main()
        {
            //fill up the first sequence
            HashSet<int> firstSequence = new HashSet<int>();
            int prevMember = 1;
            firstSequence.Add(prevMember); //first member of the sequence

            for (int i = 1; i < 100000; i++)
            {
                int nextMember = 2 * prevMember + 3;
                firstSequence.Add(nextMember);
                prevMember = nextMember;
            }

            //fill up the second sequence
            HashSet<int> secondSequence = new HashSet<int>();
            prevMember = 2;
            secondSequence.Add(prevMember);

            for (int i = 1; i < 100000; i++)
            {
                int nextMember = 3 * prevMember + 1;
                secondSequence.Add(nextMember);
                prevMember = nextMember;
            }

            //fill up the third sequence
            HashSet<int> thirdSequence = new HashSet<int>();
            prevMember = 2;
            thirdSequence.Add(prevMember);

            for (int i = 1; i < 100000; i++)
            {
                int nextMember = 2 * prevMember - 1;
                thirdSequence.Add(nextMember);
                prevMember = nextMember;
            }

            //this is too big
            //Console.WriteLine("The union of f1 and f2:");
            //PrintUnion<int>(firstSequence, secondSequence);

            Console.WriteLine("The union of f1 and f3:");
            PrintUnion<int>(firstSequence, thirdSequence);

            //this is too big
            //Console.WriteLine("The union of f2 and f3:");
            //PrintUnion<int>(secondSequence, thirdSequence);

            //this is too big
            //Console.WriteLine("The union of f1, f2 and f3:");
            //PrintUnion<int>(firstSequence, secondSequence, thirdSequence); 

            Console.WriteLine("The intersect of f1 and f2:");
            PrintIntersect<int>(firstSequence, secondSequence);

            Console.WriteLine("The intersect of f1 and f3: ");
            PrintIntersect<int>(firstSequence, thirdSequence);

            Console.WriteLine("The intersect of f2 and f3: ");
            PrintIntersect<int>(secondSequence, thirdSequence);

            Console.WriteLine("The intersect of f1, f2 and f3: ");
            PrintIntersect<int>(firstSequence, secondSequence, thirdSequence);
        }

        private static void PrintUnion<T>(params HashSet<T>[] sets)
        {
            HashSet<T> union = new HashSet<T>();

            foreach (HashSet<T> set in sets)
            {
                union.UnionWith(set);
            }

            PrintMembers<T>(union);
        }

        private static void PrintIntersect<T> (params HashSet<T>[] sets)
        {
            HashSet<T> intersect = new HashSet<T>();

            if (sets.Length > 0)
            {
                intersect.UnionWith(sets[0]);

                foreach (HashSet<T> set in sets)
                {
                    intersect.IntersectWith(set);
                }

                PrintMembers<T>(intersect);
            }
        }

        private static void PrintMembers<T>(HashSet<T> cars)
        {
            foreach (T car in cars)
                Console.Write(car + " ");

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        }
    }
}
