﻿namespace AnimalsHierarchy
{
    using System;
    using System.Linq;

    class AnimalsHierarchyMain
    {
        static void Main()
        {
            Animal[] animals = new Animal[] 
            {
                new Dog(3, "Sharo", "male"),
                new Frog(4, "Keranka", "male"),
                new Kitten(5, "Canka", "female"),
                new Tomcat(2, "Misho", "male")
            };

            foreach (Animal animal in animals)
                animal.MakeSound();

            Kitten canka = (Kitten)animals[2];
            Console.WriteLine(canka.Scratch()); 

            //calcukate age by using lambda expressions
            double averageAge1 = animals.Average(a => a.Age);
            Console.WriteLine(averageAge1);

            double averageAge2 = (from animal in animals
                                  select animal.Age).Average();
            Console.WriteLine(averageAge2);

            Dog[] dogs = new Dog[] 
            {
                new Dog(8, "Sharo", "male"),
                new Dog(2, "Pepi", "male"),
                new Dog(1, "Gosho", "male"),
                new Dog(6, "Misho", "male"),
            };

            double averageAGogs = dogs.Average(d => d.Age);
        }
    }
}
