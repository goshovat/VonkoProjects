using System;
using System.Collections.Generic;

namespace PriorityQueue
{
    public class Person: IComparable<Person>
    {
        private string name;
        private int age;
        private int waitingTime;

        public Person(string name, int age, int waitingTime)
        {
            this.name = name;
            this.age = age;
            this.waitingTime = waitingTime;
        }

        public string Name
        {
            get { return this.name; }
        }

        public int Age
        {
            get { return this.age; }
        }

        public int WaitingTime
        {
            get { return this.waitingTime; }
        }

        public int CompareTo(Person other)
        {
            return this.waitingTime.CompareTo(other.WaitingTime);
        }

        public override string ToString()
        {
            return this.name + " " + this.age + " " + this.WaitingTime + ";";
        }
    }
}
