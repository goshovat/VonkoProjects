using System;
using System.Collections.Generic;

namespace ShortestSequenceOperations
{
    class ShortestSequenceOperations
    {
        static void Main()
        {
            int n = 5;
            int m = 16;

            Number currentNumber = new Number(n);
            Queue<Number> queue = new Queue<Number>();
            queue.Enqueue(currentNumber);

            while (queue.Count > 0)
            {
                currentNumber = queue.Dequeue();

                if (currentNumber.Value == m)
                    break;

                queue.Enqueue(new Number(currentNumber.Value + 1, currentNumber));
                queue.Enqueue(new Number(currentNumber.Value + 2, currentNumber));
                queue.Enqueue(new Number(currentNumber.Value * 2, currentNumber));
            }

            Stack<Number> shortestPath = new Stack<Number>();
            shortestPath.Push(currentNumber);

            Number prev = currentNumber.Previous;
            while (prev != null)
            {
                shortestPath.Push(prev);
                currentNumber = prev;
                prev = currentNumber.Previous;
            }

            while (shortestPath.Count > 0)
            {
                currentNumber = shortestPath.Pop();
                Console.WriteLine(currentNumber.Value);
            }
        }
    }
}
