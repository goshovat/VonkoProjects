using System;

class ShipDamage
{
    static void Main()
    {
        string inputSX1 = Console.ReadLine();
        int sX1 = int.Parse(inputSX1);
        string inputSY1 = Console.ReadLine();
        int sY1 = int.Parse(inputSY1);
        string inputSX2 = Console.ReadLine();
        int sX2 = int.Parse(inputSX2);
        string inputSY2 = Console.ReadLine();
        int sY2 = int.Parse(inputSY2);
        string inputHY = Console.ReadLine();
        int hY = int.Parse(inputHY);
        string inputcX1 = Console.ReadLine();
        int cX1 = int.Parse(inputcX1);
        string inputcY1 = Console.ReadLine();
        int cY1 = int.Parse(inputcY1);
        string inputcX2 = Console.ReadLine();
        int cX2 = int.Parse(inputcX2);
        string inputcY2 = Console.ReadLine();
        int cY2 = int.Parse(inputcY2);
        string inputcX3 = Console.ReadLine();
        int cX3 = int.Parse(inputcX3);
        string inputcY3 = Console.ReadLine();
        int cY3 = int.Parse(inputcY3);

        int damage = 0;

        //Here we make the Ys where the catapults will strike

        cY1 = 2 * hY - cY1;
        cY2 = 2 * hY - cY2;
        cY3 = 2 * hY - cY3;

        if (sX1 > sX2)
        {
            int temp = sX1;
            sX1 = sX2;
            sX2 = temp;
        }
        if (sY1 > sY2)
        {
            int temp = sY1;
            sY1 = sY2;
            sY2 = temp;
        }

        //Here we make the case when the catapults hit the some of the corners
        if ((cX1 == sX1 && cY1 == sY1) || (cX1 == sX2 && cY1 == sY2) ||
            (cX1 == sX1 && cY1 == sY2) || (cX1 == sX2 && cY1 == sY1))
        {
            damage += 25;
        }
        if ((cX2 == sX1 && cY2 == sY1) || (cX2 == sX2 && cY2 == sY2) ||
           (cX2 == sX1 && cY2 == sY2) || (cX2 == sX2 && cY2 == sY1))
        {
            damage += 25;
        }
        if ((cX3 == sX1 && cY3 == sY1) || (cX3 == sX2 && cY3 == sY2) ||
           (cX3 == sX1 && cY3 == sY2) || (cX3 == sX2 && cY3 == sY1))
        {
            damage += 25;
        }

        //here we make the case when the catapults hit some of the sides
        //bottom and top side
        if ((cY1 == sY1 || cY1 == sY2) && (cX1 < sX2 && cX1 > sX1))
        {
            damage += 50;
        }
        if ((cY2 == sY1 || cY2 == sY2) && (cX2 < sX2 && cX2 > sX1))
        {
            damage += 50;
        }
        if ((cY3 == sY1 || cY3 == sY2) && (cX3 < sX2 && cX3 > sX1))
        {
            damage += 50;
        }

        //left and right side
        if ((cX1 == sX1 || cX1 == sX2) && (cY1 < sY2 && cY1 > sY1))
        {
            damage += 50;
        }
        if ((cX2 == sX1 || cX2 == sX2) &&  (cY2 < sY2 && cY2 > sY1))
        {
            damage += 50;
        }
        if ((cX3 == sX1 || cX3 == sX2) && (cY3 < sY2 && cY3 > sY1))
        {
            damage += 50;
        }
         
        //here we make hit inside the ship
        if (cX1 < sX2 && cX1 > sX1 && cY1 < sY2 && cY1 > sY1)
        {
            damage += 100;
        }
        if (cX2 < sX2 && cX2 > sX1 && cY2 < sY2 && cY2 > sY1)
        {
            damage += 100;
        }
        if (cX3 < sX2 && cX3 > sX1 && cY3 < sY2 && cY3 > sY1)
        {
            damage += 100;
        }

        Console.WriteLine("{0}%", damage);
    }
}

