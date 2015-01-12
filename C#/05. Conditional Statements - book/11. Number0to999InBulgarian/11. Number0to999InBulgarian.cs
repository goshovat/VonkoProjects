using System;

class Number0to999InBulgarian
{
    static void Main()
    {
        Console.WriteLine("Enter a number from 0 to 999: ");
        string input = Console.ReadLine();


        if (input.Length == 1)
        {
            switch (input[0])
            {
                case '0': Console.WriteLine("Нула"); break;
                case '1': Console.WriteLine("Едно"); break;
                case '2': Console.WriteLine("Две"); break;
                case '3': Console.WriteLine("Три"); break;
                case '4': Console.WriteLine("Четири"); break;
                case '5': Console.WriteLine("Пет"); break;
                case '6': Console.WriteLine("Шест"); break;
                case '7': Console.WriteLine("Седем"); break;
                case '8': Console.WriteLine("Осем"); break;
                case '9': Console.WriteLine("Девет"); break;
            }
        }

        else if (input.Length == 2)
        {
            if (input[0] == '1')
            {
                switch (input[1])
                {
                    case '0': Console.WriteLine("Десет"); break;
                    case '1': Console.WriteLine("Единадесет"); break;
                    case '2': Console.WriteLine("Дванадесет"); break;
                    case '3': Console.WriteLine("Тринадесет"); break;
                    case '4': Console.WriteLine("Четиринадесет"); break;
                    case '5': Console.WriteLine("Петнадесет"); break;
                    case '6': Console.WriteLine("Шестнадесет"); break;
                    case '7': Console.WriteLine("Седемнадесет"); break;
                    case '8': Console.WriteLine("Осемнадесет"); break;
                    case '9': Console.WriteLine("Деветнадесет"); break;
                }
            }
            else if (input[0] != '1')
            {
                if (input[1] == '0')
                {
                    switch (input[0])
                    {
                        case '2': Console.WriteLine("Двадесет"); break;
                        case '3': Console.WriteLine("Тридесет"); break;
                        case '4': Console.WriteLine("Четиредесет"); break;
                        case '5': Console.WriteLine("Петдесет"); break;
                        case '6': Console.WriteLine("Шестдесет"); break;
                        case '7': Console.WriteLine("Седемдесет"); break;
                        case '8': Console.WriteLine("Осемдесет"); break;
                        case '9': Console.WriteLine("Деветдесет"); break;
                    }
                }
                else
                {
                    switch (input[0])
                    {
                        case '2': Console.Write("Двадесет"); break;
                        case '3': Console.Write("Тридесет"); break;
                        case '4': Console.Write("Четиредесет"); break;
                        case '5': Console.Write("Петдесет"); break;
                        case '6': Console.Write("Шестедест"); break;
                        case '7': Console.Write("Седемдесет"); break;
                        case '8': Console.Write("Осемдесет"); break;
                        case '9': Console.Write("Деветдесет"); break;
                    }
                    switch (input[1])
                    {
                        case '1': Console.WriteLine(" и Едно"); break;
                        case '2': Console.WriteLine(" и Две"); break;
                        case '3': Console.WriteLine(" и Три"); break;
                        case '4': Console.WriteLine(" и Четири"); break;
                        case '5': Console.WriteLine(" и Пет"); break;
                        case '6': Console.WriteLine(" и Шест"); break;
                        case '7': Console.WriteLine(" и Седем"); break;
                        case '8': Console.WriteLine(" и Осем"); break;
                        case '9': Console.WriteLine(" и Девет"); break;
                    }
                }
            }
        }


        else if (input.Length == 3)
        {
            switch (input[0])
            {
                case '1': Console.Write("Сто"); break;
                case '2': Console.Write("Двеста"); break;
                case '3': Console.Write("Триста"); break;
                case '4': Console.Write("Четиристотин"); break;
                case '5': Console.Write("Петстотин"); break;
                case '6': Console.Write("Шестотин"); break;
                case '7': Console.Write("Седемстотин"); break;
                case '8': Console.Write("Осемстотин"); break;
                case '9': Console.Write("Деведстотин"); break;
            }

            if (input[1] == '0')
            {
                switch (input[2])
                {
                    case '1': Console.WriteLine(" и Едно"); break;
                    case '2': Console.WriteLine(" и Две"); break;
                    case '3': Console.WriteLine(" и Три"); break;
                    case '4': Console.WriteLine(" и Четири"); break;
                    case '5': Console.WriteLine(" и Пет"); break;
                    case '6': Console.WriteLine(" и Шест"); break;
                    case '7': Console.WriteLine(" и Седем"); break;
                    case '8': Console.WriteLine(" и Осем"); break;
                    case '9': Console.WriteLine(" и Девет"); break;
                }
            }
            else if (input[1] != '0')
            {
                if (input[1] == '1')
                {
                    switch (input[2])
                    {
                        case '0': Console.WriteLine(" и Десет"); break;
                        case '1': Console.WriteLine(" и Единадесет"); break;
                        case '2': Console.WriteLine(" и Дванадесет"); break;
                        case '3': Console.WriteLine(" и Тринадесет"); break;
                        case '4': Console.WriteLine(" и Четиринадесет"); break;
                        case '5': Console.WriteLine(" и Петнадесет"); break;
                        case '6': Console.WriteLine(" и Шестнадесет"); break;
                        case '7': Console.WriteLine(" и Седемнадесет"); break;
                        case '8': Console.WriteLine(" и Осемнадесет"); break;
                        case '9': Console.WriteLine(" и Деветнадесет"); break;
                    }
                }

                else if (input[1]!= 1 && input[2] == '0')
                {
                    switch (input[1])
                    {
                        case '2': Console.WriteLine(" и Двадесет"); break;
                        case '3': Console.WriteLine(" и Тридесет"); break;
                        case '4': Console.WriteLine(" и Четиредесет"); break;
                        case '5': Console.WriteLine(" и Петдесет"); break;
                        case '6': Console.WriteLine(" и Шестедесет"); break;
                        case '7': Console.WriteLine(" и Седемдесет"); break;
                        case '8': Console.WriteLine(" и Осемдесет"); break;
                        case '9': Console.WriteLine(" и Деветдесет"); break;
                    }
                }
                else if (input[1] != 0 && input[2] !=0)
                {
                    switch (input[1])
                    {
                        case '2': Console.Write(" Двадесет"); break;
                        case '3': Console.Write(" Тридесет"); break;
                        case '4': Console.Write(" Четиредесет"); break;
                        case '5': Console.Write(" Петдесет"); break;
                        case '6': Console.Write(" Шестедесет"); break;
                        case '7': Console.Write(" Седемдесет"); break;
                        case '8': Console.Write(" Осемдесет"); break;
                        case '9': Console.Write(" Деветдесет"); break;
                    }
                    switch(input[2]) 
                    {
                        case '1': Console.WriteLine(" и Едно"); break;
                        case '2': Console.WriteLine(" и Две"); break;
                        case '3': Console.WriteLine(" и Три"); break;
                        case '4': Console.WriteLine(" и Четири"); break;
                        case '5': Console.WriteLine(" и Пет"); break;
                        case '6': Console.WriteLine(" и Шест"); break;
                        case '7': Console.WriteLine(" и Седем"); break;
                        case '8': Console.WriteLine(" и Осем"); break;
                        case '9': Console.WriteLine(" и Девет"); break;
                    }
                }
            }
        }

        else
        {
            Console.WriteLine("Въведете число от 0 до 999");
        }
        Console.WriteLine();
    } 
}

