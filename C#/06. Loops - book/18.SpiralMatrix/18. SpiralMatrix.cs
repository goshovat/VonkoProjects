using System;

class SpiralMatrix
{
    public static void Main()
    {
        int n = 0;
        Console.WriteLine("Write a positive integer N: ");

        bool parseN = int.TryParse(Console.ReadLine(), out n);

        if (parseN && n > 0)
        {
            int[,] arr = new int[n, n];

            int x = 0, y = 0, direction = 0;

            for (int i = 0; i < n * n; i++)
            {
                arr[y, x] = i + 1;

                switch (direction)
                {
                    case 0:
                        if (x < (n - 1) && arr[y, x + 1] == 0)
                        {
                            x++;
                        }
                        else
                        {
                            direction = (++direction) % 4;
                            y++;
                        }
                        break;
                    case 1:
                        if (y < (n - 1) && arr[y + 1, x] == 0)
                        {
                            y++;
                        }
                        else
                        {
                            direction = (++direction) % 4;
                            x--;
                        }
                        break;
                    case 2:
                        if (x > 0 && arr[y, x - 1] == 0)
                        {
                            x--;
                        }
                        else
                        {
                            direction = (++direction) % 4;
                            y--;
                        }
                        break;
                    case 3:
                        if (y > 0 && arr[y - 1, x] == 0)
                        {
                            y--;
                        }
                        else
                        {
                            direction = (++direction) % 4;
                            x++;
                        }
                        break;
                }
            }

            int align = (n * n).ToString().Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i,j].ToString().PadLeft(align + 1));
                }
                Console.WriteLine();
            }
        }

        else
        {
            Console.WriteLine("Please enter a valid number!");
        }
    }
}
