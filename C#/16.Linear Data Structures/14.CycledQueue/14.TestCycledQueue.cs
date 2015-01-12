using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycledQueue
{
    class TestCycledQueue
    {
        static void Main()
        {
            try
            {
                Queue<int> vonkoQueue = new Queue<int>();

                CycledQueue<int> cycledQueue = new CycledQueue<int>();
                cycledQueue.Enqueue(1);
                cycledQueue.Enqueue(2);

                cycledQueue.Dequeue();
                cycledQueue.Enqueue(3);
                cycledQueue.Dequeue();
                cycledQueue.Enqueue(2);
                cycledQueue.Dequeue();
                cycledQueue.Enqueue(1);
                cycledQueue.Enqueue(2);
                cycledQueue.Dequeue();
                cycledQueue.Enqueue(1);
                //here is the time to resize the array
                cycledQueue.Dequeue();
                cycledQueue.Enqueue(2);
                cycledQueue.Enqueue(5);

                //resize on both sides
                for (int i = 1; i <= 4; i++)
                {
                    cycledQueue.Dequeue();
                    cycledQueue.Enqueue(i);
                }
                cycledQueue.Enqueue(7);
                cycledQueue.Enqueue(8);
                cycledQueue.Enqueue(9);

                //resize here
                cycledQueue.Enqueue(11);
                cycledQueue.Enqueue(12);

                Console.WriteLine(cycledQueue.Peek());
            }
            catch (ApplicationException applExc)
            {
                Console.WriteLine(applExc.Message);
                Console.WriteLine(applExc.StackTrace);
            }
        }
    }
}
