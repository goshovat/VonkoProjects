using System;

class NextDate_verConditionals
{
    static void Main()
    {
        int day = int.Parse(Console.ReadLine());
        int month = int.Parse(Console.ReadLine());
        int year = int.Parse(Console.ReadLine());

        switch (month)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
                 if (day < 31)
                {
                    day += 1;
                }
                else if (day == 31)
                {
                    day = 1;
                    month += 1;
                }
                break;

            case 12:
                if (day < 31)
                {
                    day += 1;
                }
                else if (day == 31)
                {
                    day = 1;
                    month = 1;
                    year += 1;
                }
                break;

            case 4:
            case 6:
            case 9:
            case 11:
                if (day < 30)
                {
                    day += 1;
                }
                else if (day == 30)
                {
                    day = 1;
                    month += 1;
                }
                break;

            case 2:
                if (year % 4 != 0)
                {
                    if (day < 28)
                    {
                        day += 1;
                    }
                    else if (day == 28)
                    {
                        day = 1;
                        month += 1;
                    } 
                }
                else
                {
                    if (day < 29)
                    {
                        day += 1;
                    }
                    else if (day == 29)
                    {
                        day = 1;
                        month += 1;
                    } 
                }
                break;

            default: Console.WriteLine("Please enter a valid month!");
                break;
        }

        Console.WriteLine(day+"."+month+"."+year);
    }
}

