using System;
using System.Collections.Generic;
using ShortestSequenceOperations;

namespace DynamicStack
{
    class TestDynamicStack
    {
        static void Main()
        {
            Stack<int> vonkoStack = new Stack<int>();

            //initialize the objects that will be put into the stack
            Number one = new Number(1);
            Number two = new Number(2);
            Number three = new Number(3);
            Number five = new Number(5);
            Number six = new Number(6);
            Number seven = new Number(7);

            DynamicStack<Number> numberStack = new DynamicStack<Number>();

            try
            {
                TestPush(one, two, three, numberStack);

                TestPop(three, numberStack);

                TestPeek(three, numberStack);

                TestClear(one, two, three, numberStack);

                //test contains
                TestContains(one, two, three, five, numberStack);

                TestConstructorWithArray(five, six, seven, numberStack);
            }
            catch (ApplicationException applExc)
            {
                Console.WriteLine(applExc.Message);
                Console.WriteLine(applExc.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        //these methods will run test scenarios to test the different methods of DynamicStack
        private static void TestPush(Number one, Number two, Number three, DynamicStack<Number> numberStack)
        {
            Console.WriteLine("Test the push method:");
            numberStack.Push(one);
            numberStack.Push(two);
            numberStack.Push(three);
            Console.WriteLine("The stack after pushing three elements:");
            PrintStack(numberStack);
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void TestPop(Number three, DynamicStack<Number> numberStack)
        {
            Console.WriteLine("Test the pop method:");
            numberStack.Push(three);
            Number removedElement = numberStack.Pop();
            Console.WriteLine(string.Format("Popped element: {0}", removedElement.Value));
            Console.WriteLine("The stack after poping one element: ");
            PrintStack(numberStack);
            Console.WriteLine();
        }

        private static void TestPeek(Number three, DynamicStack<Number> numberStack)
        {
            Console.WriteLine("Test the peek method: ");
            numberStack.Push(three);
            Number peekedElement = numberStack.Peek();
            Console.WriteLine(string.Format("The peeked element is: ", peekedElement.ToString()));
            Console.WriteLine("The stack after peeking one element is: ");
            PrintStack(numberStack);
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void TestClear(Number one, Number two, Number three, DynamicStack<Number> numberStack)
        {
            Console.WriteLine("Test the clear method: ");
            numberStack.Push(one);
            numberStack.Push(two);
            numberStack.Push(three);
            numberStack.Clear();
            Console.WriteLine("The stack after clearing it:");
            PrintStack(numberStack);
            Console.WriteLine();
        }

        private static void TestContains(Number one, Number two, Number three, Number five, DynamicStack<Number> numberStack)
        {
            Console.WriteLine("Test the contains method: ");
            numberStack.Push(one);
            numberStack.Push(two);
            numberStack.Push(three);
            Console.WriteLine(string.Format("The stack contains {0} -> {1}", one, numberStack.Contains(one)));
            Console.WriteLine(string.Format("The stack contains {0} -> {1}", five, numberStack.Contains(five)));
            Console.WriteLine();
        }

        private static void TestConstructorWithArray(Number five, Number six, Number seven, DynamicStack<Number> numberStack)
        {
            Console.WriteLine("Test the array constructor:");
            Number[] numberArray = new Number[] { five, six, seven };

            DynamicStack<Number> arrayStack = new DynamicStack<Number>(numberArray);
            Console.WriteLine("After constructing the stack with array, see it's elements in the order they pop: ");
            PrintStack(arrayStack);
            Console.WriteLine();
        }

        private static void PrintStack(DynamicStack<Number> stack) 
        {
            while (stack.Count > 0)
            {
                Number currentNumber = stack.Pop();
                Console.Write(currentNumber + " ");
            }
        }
    }
}
