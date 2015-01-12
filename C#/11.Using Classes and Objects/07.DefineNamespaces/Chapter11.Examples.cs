using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter11;

namespace Chapter11.Examples
{
    class CallClasses
    {
        static void Main()
        {
            //call the dog class
            Dog melezDog = new Dog();
            melezDog.Bark();

            Dog lassieDog = new Dog("Lassie", "pink");
            Console.WriteLine("The color of {0} is {1}", lassieDog.Name, lassieDog.Color);
            lassieDog.Bark();

            //using the sequence class
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("The {0}-nth member of the sequence is: {1}", i, Sequence.IncreaseValue());
            }
        }
    }
}
