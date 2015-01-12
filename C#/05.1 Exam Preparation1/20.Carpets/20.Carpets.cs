using System;

class Carpets
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        int rows = input;
        int elementsOnLine = input;
        int center = elementsOnLine / 2;

        for (int currentRow = 1; currentRow <= rows/2; currentRow++)
        {
            int elPos = 1;

            while(elPos <=elementsOnLine) 
            {
                if ((elPos <= center - currentRow) || (elPos > center + currentRow))
                {
                    Console.Write(".");
                    elPos++;
                }
                else
                {
                    for (int i = 0; i < currentRow; i++)
                    {
                        if (i % 2 == 0)
                        {
                            Console.Write("/");                           
                        }
                        else
                        {
                            Console.Write(" ");                           
                        }
                        elPos++;
                    }

                    for (int i = currentRow; i >=1 ; i--)
                    {
                         if (i % 2 == 0)
                        {
                            Console.Write(" ");                           
                        }
                        else
                        {
                            Console.Write("\\");                           
                        }
                        elPos++;
                    }
                }
                
            }

            Console.WriteLine();
        }


        for (int currentRow = rows/2; currentRow >= 1; currentRow--)
        {
            int elPos = 1;

            while (elPos <= elementsOnLine)
            {
                if ((elPos <= center - currentRow) || (elPos > center + currentRow))
                {
                    Console.Write(".");
                    elPos++;
                }
                else
                {
                    for (int i = 0; i < currentRow; i++)
                    {
                        if (i % 2 == 0)
                        {
                            Console.Write("\\");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                        elPos++;
                    }

                    for (int i = currentRow; i >= 1; i--)
                    {
                        if (i % 2 == 0)
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write("/");
                        }
                        elPos++;
                    }
                }
                
            }

            Console.WriteLine();
        }
    }
}

