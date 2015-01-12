using System;
using System.Collections.Generic;
using ShortestSequenceOperations;

namespace DoubleLinkedList
{
    class TestDoubleLinkedList
    {
        static void Main()
        {
            try
            {
                DoubleLinkedList<Number> numbersList = new DoubleLinkedList<Number>();
                Number five;
                Number seven;
                Number eight;
                AddFirstNumbers(numbersList, out five, out seven, out eight);

                //test the IndexOf method
                TestIndexOf(numbersList, five, seven, eight);

                //test ToArray method
                Number[] array = numbersList.ToArray();

                Number two = new Number(2);
                Number nine = new Number(9);
                Number ten = new Number(10);

                //test the InsertAt method
                TestInsertAt(numbersList, two, nine, ten);

                //test the RemoveAt method
                TestRemoveAt(numbersList, two);

                //test Remove method
                TestRemove(numbersList, five, seven, two);

                TestConstructorWithCollection();

                //test Contains method
                Console.WriteLine(numbersList.Contains(seven));
            }
            catch (ArgumentException argOutRange)
            {
                 Console.WriteLine(argOutRange.Message);
               Console.WriteLine(argOutRange.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        //these methods will run different test scenarios to dest the methods of the class
        private static void AddFirstNumbers(DoubleLinkedList<Number> numbersList, out Number five, out Number seven, out Number eight)
        {
            five = new Number(5);
            seven = new Number(7);
            eight = new Number(8);

            //test the Add method
            numbersList.Add(five);
            numbersList.Add(seven);
            numbersList.Add(eight);
        }

        private static void TestIndexOf(DoubleLinkedList<Number> numbersList, Number five, Number seven, Number eight)
        {
            Console.WriteLine(numbersList.IndexOf(five));
            Console.WriteLine(numbersList.IndexOf(seven));
            Console.WriteLine(numbersList.IndexOf(eight));
        }

        private static void TestInsertAt(DoubleLinkedList<Number> numbersList, Number two, Number nine, Number ten)
        {
            numbersList.InsertAt(two, 2);
            numbersList.InsertAt(nine, 0);
            numbersList.InsertAt(ten, numbersList.Count);
            Console.WriteLine(numbersList.ToString());
        }

        private static void TestRemoveAt(DoubleLinkedList<Number> numbersList, Number two)
        {
            Number removedElement = numbersList.RemoveAt(4);
            Console.WriteLine(numbersList.ToString());
            numbersList.Clear();
            numbersList.InsertAt(two, 0);
            numbersList.RemoveAt(0);
        }

        private static void TestRemove(DoubleLinkedList<Number> numbersList, Number five, Number seven, Number two)
        {
            numbersList.Add(two);
            numbersList.Add(seven);
            numbersList.Add(five);
            Console.WriteLine(numbersList.ToString());
            int removedIndex = numbersList.Remove(five);
            Console.WriteLine(numbersList.ToString());
        }

        private static void TestConstructorWithCollection()
        {
            int[] intArray = new int[6];

            for (int i = 1; i <= intArray.Length; i++)
                intArray[i - 1] = i;

            DoubleLinkedList<int> arrayList = new DoubleLinkedList<int>(intArray);

            Console.WriteLine(arrayList.ToString());
        }
    }
}
