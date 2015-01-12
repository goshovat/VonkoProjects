using System;

class Number0to999InBulgarian_ver2
{
    static void Main()
    {
        Console.WriteLine("Please enter a number between 0 and 999: ");
        string input = Console.ReadLine();

        string[] ones = new String[]{"", "едно", "две", "три", "четири", "пет", 
                         "шест", "седем", "осем", "девет"};
        string[] tens = new String[]{"", "", "двадесет", "тридесет", "четиредесет", 
                         "петдесет", "шестдесет", "седемдесет", "осемдесет", "деветдесет"};
        string[] specialNumbers = new String[]{"десет", "единадесет", "дванадесет", "тринадесет",
                                  "четиринадесет", "петнадесет", "шестнадесет", "седемнадесет",
                                  "осемнадесет", "деветнадесет"};
        int length = input.Length;
        int number = 0;


        try
        {
            number = int.Parse(input);
        }
        catch (FormatException)
        {
            Console.WriteLine("Моля въведете валидно число!");
            return;
        }

        int index = number / 100;
        int index1 = (number / 10) % 10;
        int index2 = (number % 100) % 10;

        if (length == 1)
        {
            if (input[0] == '0')
            {
                Console.WriteLine("Числото е нула!");
            }
            else
            {
                Console.WriteLine(ones[index2]);
            }
        }

        else if (length == 2)
        {
            if (input[0] == '1')
            {
                Console.WriteLine(specialNumbers[index2]);
            }
            else
            {
                if (input[1] == '0')
                {
                    Console.WriteLine(tens[index1]);
                }
                else
                {
                    Console.WriteLine(tens[index1] + " и " + ones[index2]);
                }
            }
        }

        else if (length == 3)
        {
            if (input[1] == '0' && input[2] == '0')
            {
                if (index == 1)
                {
                    Console.WriteLine("сто");
                }
                else if (index < 4)
                {
                    Console.WriteLine(ones[index] + "стa " + tens[index1] + " " + ones[index2]);
                }
                else
                {
                    Console.WriteLine(ones[index] + "стотин " + tens[index1] + " " + ones[index2]);
                }
            }

            else if (input[1] == '0')
            {
                if (input[0] == '1')
                {
                    Console.WriteLine("сто и " + ones[index2]);
                }

                else if (input[0] != 1 && input[2] != '0')
                {
                    Console.WriteLine(ones[index] + "стотин и " + ones[index2]);
                }
            }

            else if (input[1] == '1')
            {
                if (input[0] == '1')
                {
                    Console.WriteLine("сто и " + specialNumbers[index2]);
                }
                else
                {
                    if (index < 4)
                    {
                        Console.WriteLine(ones[index] + "ста и " + specialNumbers[index1]);
                    }
                    else
                    {
                        Console.WriteLine(ones[index] + "стотин и " + specialNumbers[index1]);
                    }
                }
            }

            else if (input[1] != '0' && input[1] != '1')
            {
                if (input[0] == '1')
                {
                    if (input[2] == '0')
                    {
                        Console.WriteLine("сто" + " и " + tens[index1]);
                    }
                    else
                    {
                        Console.WriteLine("сто " + tens[index1] + " и " + ones[index2]);
                    }
                }

                else if (input[1] != '0' || input[2] != '0')
                {
                    if (input[2] == '0')
                    {
                        if (index < 4)
                        {
                            Console.WriteLine(ones[index] + "ста" + " и " + tens[index1]);
                        }
                        else
                        {
                            Console.WriteLine(ones[index] + "стотин" + " и " + tens[index1]);
                        }
                    }
                    else
                    {
                        Console.WriteLine(ones[index] + "стотин и " + tens[index1] + " и " + ones[index2]);
                    }
                }
            }
        }

        else
        {
            Console.WriteLine("Моля въведете трицифрено число!");
        }
    }
}

