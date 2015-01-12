using System;
using System.Collections.Generic;

namespace Animals
{
    class AnimalsTest
    {
        static void Main()
        {
            try
            {
                List<Animal> animalsList = CreateAnimals();

                foreach (Animal animal in animalsList)
                    animal.PrintInfo();
            }
            catch (ApplicationException appliExc)
            {
                Console.WriteLine(appliExc.Message);
            }
        }

        private static List<Animal> CreateAnimals()
        {
            List<Animal> animalsList = new List<Animal>();

            Dog sharo = new Dog("Sharo", 4, "Female");
            animalsList.Add(sharo);
            sharo.Gender = "Male";

            Frog ugly = new Frog("Ugly Thing", 2, "Female");
            ugly.Age = 1;
            animalsList.Add(ugly);

            Cat pussycat = new Cat("Pussycat", 5, "Female");
            animalsList.Add(pussycat);

            Kitten smallkitty = new Kitten("Kitty", 0, "Male");
            animalsList.Add(smallkitty);

            Tomcat tommy = new Tomcat("Tommy", 6, "Male");
            animalsList.Add(tommy);

            return animalsList;
        }
    }
}
