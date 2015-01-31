using System;

class Point
{
    public int XCoord { get; set; }
    public int YCoord { get; set; }

    public Point(int xCoord, int yCoord)
    {
        this.XCoord = xCoord;
        this.YCoord = yCoord;
    }
}

class ShipDamage
{
    static void Main()
    {
        Point[] catapults = new Point[3];

        int sX1 = int.Parse(Console.ReadLine());
        int sY1 = int.Parse(Console.ReadLine());
        int sX2 = int.Parse(Console.ReadLine());
        int sY2 = int.Parse(Console.ReadLine());
        int offset = int.Parse(Console.ReadLine());
        int cX1 = int.Parse(Console.ReadLine());
        int cY1 = int.Parse(Console.ReadLine());
        catapults[0] = new Point(cX1, cY1);
        int cX2 = int.Parse(Console.ReadLine());
        int cY2 = int.Parse(Console.ReadLine());
        catapults[1] = new Point(cX2, cY2);
        int cX3 = int.Parse(Console.ReadLine());
        int cY3 = int.Parse(Console.ReadLine());
        catapults[2] = new Point(cX3, cY3);

        //sx1 will always be on the left
        if (sX1 > sX2)
        {
            int temp = sX1;
            sX1 = sX2;
            sX2 = temp;
        }
        //cx1 will always be down
        if (sY1 > sY2)
        {
            int temp = sY1;
            sY1 = sY2;
            sY2 = temp;
        }

        int damagePercentage = 0;

        for (int i = 0; i < catapults.Length; i++)
        {
            int catapultXCoord = catapults[i].XCoord;
            int catapultYCoord = catapults[i].YCoord;
            int damageX = catapultXCoord;
            int damageY = 2 * offset - catapultYCoord;

            //check for the damage on own ship
            if (damageX < sX2 && damageX > sX1 &&
                damageY > sY1 && damageY < sY2)
            {
                damagePercentage += 100;
            }
            //check for damage on the four sides
            if (damageX < sX2 && damageX > sX1 &&
                damageY == sY1) // hit lower side
            {
                damagePercentage += 50;
            }
            else if (damageX < sX2 && damageX > sX1 &&
                damageY == sY2) //hit upper side
            {
                damagePercentage += 50;
            }
            else if (damageY < sY2 && damageY > sY1 &&
                damageX == sX1) // hit left side
            {
                damagePercentage += 50;
            }
            else if (damageY < sY2 && damageY > sY1 &&
                damageX == sX2) // hit right side
            {
                damagePercentage += 50;
            }
            //check for hits on the corners
            else if (damageX == sX1 && damageY == sY1) // hit lower-left corner
            {
                damagePercentage += 25;
            }
            else if (damageX == sX2 && damageY == sY1)  //hit lower-right corner
            {
                damagePercentage += 25;
            }
            else if (damageX == sX2 && damageY == sY2) //hit higher-right corner
            {
                damagePercentage += 25;
            }
            else if (damageX == sX1 && damageY == sY2) //hit upper left corner
            {
                damagePercentage += 25;
            }
        }

        Console.WriteLine(damagePercentage + "%");
    }
}
