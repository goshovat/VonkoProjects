using System;

class FighterAttack
{
    static void Main()
    {
        int pX1 = int.Parse(Console.ReadLine());
        int pY1 = int.Parse(Console.ReadLine());
        int pX2 = int.Parse(Console.ReadLine());
        int pY2 = int.Parse(Console.ReadLine());
        int fX = int.Parse(Console.ReadLine());
        int fY = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());

        int damage = 0;
        int attack = fX+d;

        if (pX1 > pX2)
        {
            int temp = pX1;
            pX1 = pX2;
            pX2 = temp;
        }

        if (pY1 > pY2)
        {
            int temp = pY1;
            pY1 = pY2;
            pY2 = temp;
        }

        if ( attack < pX2 && attack >= pX1 && fY > pY1 && fY < pY2)
        {
            damage = 275;
        }
        else if (attack < pX2 && attack >= pX1 && (fY == pY1 || fY == pY2))
        {
            damage = 225;
        }
        else if (attack == pX2 && fY > pY1 && fY < pY2)
        {
            damage = 200;
        }
        else if (attack == pX1 && pX1 == pX2 && pY1 == pY2 && fY == pY1)
        {
            damage = 100;
        }
        else if (attack == pX2 && pY1 != pY2 && (fY == pY1 || fY == pY2))
        {
            damage = 150;
        }
        else if (attack == pX1 - 1 && (fY >= pY1 && fY <= pY2))
        {
            damage = 75;
        }
        else if (attack <= pX2 && attack >= pX1 && (fY == pY1 - 1 || fY == pY2 + 1))
        {
            damage = 50;
        }

        Console.WriteLine("{0}%", damage);
    }
}

