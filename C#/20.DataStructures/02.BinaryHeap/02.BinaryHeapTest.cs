using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryHeap
{
    class BinaryHeapTest
    {
        static void Main()
        {
            //test with primitive type
            BinaryHeapMin<int> numbersHeap = new BinaryHeapMin<int>();
            numbersHeap.Add(5);
            numbersHeap.Add(3);
            numbersHeap.Add(8);
            numbersHeap.Add(8);
            numbersHeap.Add(8);
            numbersHeap.Add(10);
            numbersHeap.Add(-22);
            numbersHeap.Add(-100);

            numbersHeap.Print();

            while (numbersHeap.Count > 0)
            {
                int popedEl = numbersHeap.Pop();
                numbersHeap.Print();
            }

            //test with reference type
            BinaryHeapMin<Car> carsHeap = new BinaryHeapMin<Car>();
            carsHeap.Add(new Car("BMW", "X5", 150000));
            carsHeap.Add(new Car("Mercedes", "CLS", 18000));
            carsHeap.Add(new Car("Golf", "Pernishka 3-ka", 1500));
            carsHeap.Add(new Car("Mercedes", "CLS", 18000));
            carsHeap.Add(new Car("Mercedes", "CLS", 18000));
            carsHeap.Add(new Car("BMW", "X5", 150000));
            carsHeap.Add(new Car("BMW", "X5", 150000));
            carsHeap.Add(new Car("Golf", "Pernishka 3-ka", 1500));
            carsHeap.Add(new Car("Golf", "Pernishka 3-ka", 1500));
            carsHeap.Print();

            while (carsHeap.Count > 0)
            {
                carsHeap.Pop();
                carsHeap.Print();
            }
        }
    }
}
