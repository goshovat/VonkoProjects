using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class TwoGirlsOnePath
{
    static void Main()
    {
        string[] field = Console.ReadLine().Split();

        int molyCoord = 0;
        int dollyCoord = field.Length - 1;
        BigInteger mollySum = 0;
        BigInteger dollySum = 0;
        bool mollyLost = false;
        bool dollyLost = false;

        while (true)
        {
            if (molyCoord != dollyCoord)
            {
                long flowers = 0;
                long curMolValue = long.Parse(field[molyCoord]);

                //molly
                if (curMolValue == 0)
                    mollyLost = true;
                else
                {
                    flowers = curMolValue;
                    mollySum += flowers;
                    field[molyCoord] = "0";
                }

                molyCoord = (int)((molyCoord + flowers) % field.Length);

                //dolly
                flowers = 0;
                long curDolValue = long.Parse(field[dollyCoord]);

                if (curDolValue == 0)
                    dollyLost = true;
                else
                {
                    flowers = curDolValue;
                    dollySum += flowers;
                    field[dollyCoord] = "0";
                }

                dollyCoord = (int)(((dollyCoord - flowers) % field.Length + 
                    field.Length) % field.Length);
            }
            else
            {
                long curValue = long.Parse(field[molyCoord]);

                if (curValue == 0)
                {
                    mollyLost = true;
                    dollyLost = true;
                }
                else
                {
                    long flowers = curValue;

                    mollySum += flowers / 2;
                    dollySum += flowers / 2;

                    if ((flowers & 1) != 0)
                        field[molyCoord] = "1";
                    else
                        field[molyCoord] = "0";

                    molyCoord = (int)((molyCoord + flowers) % field.Length);

                    dollyCoord = (int)(((dollyCoord - flowers) % field.Length +
                     field.Length) % field.Length);
                }
            }

            //check if somebody lost
            if (mollyLost && dollyLost)
            {
                Console.WriteLine("Draw");
                Console.WriteLine("{0} {1}", mollySum, dollySum);
                break;
            }
            else if (mollyLost)
            {
                Console.WriteLine("Dolly");
                Console.WriteLine("{0} {1}", mollySum, dollySum);
                break;
            }
            else if (dollyLost)
            {
                Console.WriteLine("Molly");
                Console.WriteLine("{0} {1}", mollySum, dollySum);
                break;
            }
        }
    }
}
