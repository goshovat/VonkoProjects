using System;

class AngryBits
{
    static void Main()
    {
        int[,] startArray = new int[8, 16];

        //Now we will fill the matrix with the given bits

        for (int rows = 0; rows < 8; rows++)
        {
            int input = int.Parse(Console.ReadLine());

            for (int cols = 15; cols >= 0; cols--)
            {
                int bit = (input >> cols) & 1;
                startArray[rows, 15 - cols] = bit;
            }
        }

        //for (int i = 0; i < 8; i++)
        //{
        //    for (int j = 0; j < 16; j++)
        //    {
        //        Console.Write(startArray[i, j] + " ");
        //    }
        //    Console.WriteLine();
        //}

        //Now we will throw the birds
        int center = 7;
        string direction = "topLeft";
        int x = 0;
        int y = 0;
        int numberHitPigs = 0;
        int points = 0;

        for (int col = center; col >= 0; col--)
        {
            for (int row = 0; row < 8; row++)
            {
                if (startArray[row, col] == 1)
                {
                    startArray[row, col] = 0;

                    //here the bird will start flying
                    y = row;
                    x = col;

                    if (y != 0)
                    {
                        direction = "topRight";
                    }
                    else
                    {
                        direction = "bottomRight";
                    }

                    for (int flightPath = x + 1; flightPath <= 15; flightPath++)
                    {
                        switch (direction)
                        {
                            case "topRight":
                                if (y > 0)
                                {
                                    x++;
                                    y--;
                                }
                                else if (y == 0)
                                {
                                    x++;
                                    y++;
                                    direction = "bottomRight";
                                }
                                break;

                            case "bottomRight":
                                if (y < 7)
                                {
                                    x++;
                                    y++;
                                }
                                else if (y == 7)
                                {
                                    x++;
                                    y--;
                                    direction = "topRight";
                                }
                                break;
                        }

                        if (startArray[y, x] == 1 && x > center)
                        {
                            numberHitPigs = 1;
                            //Console.WriteLine("hit");
                            //Console.WriteLine("flightCounter : {0}", (x-col));
                            //Console.WriteLine("{0},{1}", y, x); 
                            startArray[y, x] = 0;

                            for (int k = y - 1; k < (y - 1 + 3); k++)
                            {
                                for (int m = x - 1; m < (x - 1 + 3); m++)
                                {
                                    if ((k >= 0 && k <= 7 && m >= center + 1 && m <= 15) &&
                                        (startArray[k, m] == 1))
                                    {
                                        numberHitPigs++;
                                        //Console.WriteLine("hit");
                                        //Console.WriteLine("{0},{1}", k, m); 
                                        startArray[k, m] = 0;
                                    }
                                }
                            }

                            points += (x-col) * numberHitPigs;
                            break;
                        }
                    }
                }
            }
        }

        //now we check if the player won

        string win = "Yes";

        for (int j = center + 1; j <= 15; j++)
        {
            for (int i = 0; i < 8; i++)
            {
                if (startArray[i, j] == 1)
                {
                    win = "No";
                }
            }
        }

        Console.WriteLine(points + " " + win);
    }
}

