using System;
using System.Collections.Generic;

namespace PriorityQueue
{
    class PriorityQueueTest
    {
        static void Main()
        {
            Person vonko = new Person("Vonko Mihov", 26, 50);
            Person goshko = new Person("Goshko Radev", 26, 60);
            Person babeto = new Person("Baba Yaga", 75, 12);
            Person samko = new Person("Sameca", 27, 55);

            PriorityQueue<Person> persons = new PriorityQueue<Person>();
            persons.Enqueue(vonko);
            persons.Enqueue(goshko);
            persons.Enqueue(babeto);
            persons.Enqueue(samko);

            Console.WriteLine(persons.ToString());

            Person peeked = persons.Peek();

            Person firstPopped = persons.Dequeue();
            Person secondPopped = persons.Dequeue();
            Person thirdPopped = persons.Dequeue();
            Person fourthPopped = persons.Dequeue();
        }
    }
}
