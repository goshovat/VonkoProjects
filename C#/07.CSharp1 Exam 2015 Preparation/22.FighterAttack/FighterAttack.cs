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

        int missileX = fX + d;
        int missileY = fY;
        int totalDamage = 0;

        //check the 100 hit-field
        if (missileX >= pX1 && missileX <= pX2 &&
            missileY >= pY1 && missileY <= pY2)
        {
            totalDamage += 100;
        }
        //check the 75 hit field
        if(missileX + 1 >= pX1 && missileX + 1 <= pX2 &&
            missileY >= pY1 && missileY <= pY2)
        {
            totalDamage += 75;
        }
        //check the upper 50 hit-field
        if (missileX >= pX1 && missileX <= pX2 &&
            missileY + 1 >= pY1 && missileY + 1 <= pY2)
        {
            totalDamage += 50;
        }
        if (missileX >= pX1 && missileX <= pX2 &&
            missileY - 1 >= pY1 && missileY - 1 <= pY2)
        {
            totalDamage += 50;
        }

        Console.WriteLine(totalDamage + "%");
    }
}
