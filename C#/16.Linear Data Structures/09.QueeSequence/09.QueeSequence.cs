using System;
using System.Collections.Generic;

namespace QueeSequence
{
    class QueeSequence
    {
        static void Main()
        {
            int n = 2;
            int count = 50;

            int currentCount = 0;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);

            while (queue.Count > 0)
            {
                int currentNumber = queue.Dequeue();
                Console.Write(currentNumber + " ");
                currentCount++;

                if (currentCount == count)
                    break;

                queue.Enqueue(currentNumber + 1);
                queue.Enqueue(2 * currentNumber + 1);
                queue.Enqueue(currentNumber + 2);
            }
        }
    }
}
