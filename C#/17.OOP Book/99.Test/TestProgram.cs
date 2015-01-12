using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TestProgram
    {
        static void Main()
        {
            HomeKitty homeCat = new HomeKitty(5);

            Kitty somecAT = (Kitty)homeCat;

            List<int> vonkoList = new List<int>();

            object kittyObj = homeCat;
            HomeKitty newCat = (HomeKitty)kittyObj;

            Console.WriteLine(newCat);
            Console.WriteLine(newCat.ToString());

        }
    }
}
