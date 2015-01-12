using System;
using System.Collections.Generic;
using Chapter11;

namespace TenCatObjects
{
    class TenCatObject
    {
        static void Main()
        {
            List<Cat> listOfCats = new List<Cat>();

            //first create the ten cats and store them in a list
            for (int i = 0; i < 10; i++)
            {
                Cat currentCat = new Cat("Cat" + Sequence.IncreaseValue(), "pink");
                listOfCats.Add(currentCat);
            }

            //now make the ten cats to myauu
            for (int i = 0; i < 10; i++)
            {
                listOfCats[i].Myau();
            }
        }
    }
}
