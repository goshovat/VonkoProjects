using System;
using System.Threading;
using System.Threading.Tasks;


class JustHangman_PenkaVer
{
    static void Main()
    {
        char c = 'c';
        char h = 'h';
        char a = 'a';
        char m = 'm';
        char p = 'p';
        char i = 'i';
        char o = 'o';
        char n = 'n';

        char hiddenChar = '_';

        bool isCshown = false;
        bool isHshown = false;
        bool isAshown = false;
        bool isMshown = false;
        bool isPshown = false;
        bool isIshown = false;
        bool isOshown = false;
        bool isNshown = false;

        int livesCount = 9;

        while (true)
        {
            Console.Clear();

            Console.WriteLine("You have to guess a word that means a winner,\r\nsomebody who is the best at something.");
            Console.WriteLine();

            if (isCshown)
            {
                Console.Write("{0} ", c);
            }
            else
            {
                Console.Write("{0} ", hiddenChar);
            }

            if (isHshown)
            {
                Console.Write("{0} ", h);
            }
            else
            {
                Console.Write("{0} ", hiddenChar);
            }

            if (isAshown)
            {
                Console.Write("{0} ", a);
            }
            else
            {
                Console.Write("{0} ", hiddenChar);
            }

            if (isMshown)
            {
                Console.Write("{0} ", m);
            }
            else
            {
                Console.Write("{0} ", hiddenChar);
            }

            if (isPshown)
            {
                Console.Write("{0} ", p);
            }
            else
            {
                Console.Write("{0} ", hiddenChar);
            }

            if (isIshown)
            {
                Console.Write("{0} ", i);
            }
            else
            {
                Console.Write("{0} ", hiddenChar);
            }

            if (isOshown)
            {
                Console.Write("{0} ", o);
            }
            else
            {
                Console.Write("{0} ", hiddenChar);
            }

            if (isNshown)
            {
                Console.Write("{0} ", n);
                Console.WriteLine();
            }
            else
            {
                Console.Write("{0} ", hiddenChar);
                Console.WriteLine();
            }

            if (isCshown && isHshown && isHshown && isAshown &&
                isMshown && isPshown && isIshown && isOshown && isNshown)
            {
                Console.WriteLine("You are a fucking winner!");
                Thread.Sleep(3000);
                Main();
            }
            Console.WriteLine();

            Console.Write("Enter command: ");
            string command = Console.ReadLine();

            if (command == "view")
            {
                Console.WriteLine("The number of lives you have is: {0}", livesCount);
                Thread.Sleep(3000);
            }

            if (command == "restart")
            {
                Console.WriteLine("Do you really want to restart?\r\nTo confirm press CTRL + O");
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                if (pressedKey.Modifiers== ConsoleModifiers.Control && pressedKey.Key == ConsoleKey.O)
                {
                    Console.WriteLine("Your program will be restarted now...");
                    Thread.Sleep(3000);
                    Main();
                }     
            }
           
            if (command == "guess")
            {
                Console.Write("Enter letters(only one per line): ");
                char letter = char.Parse(Console.ReadLine());
                if (letter == c)
                {
                    if (!isCshown)
                    {
                        isCshown = true;
                    }
                    else
                    {
                        Console.WriteLine("You already revealed this letter!");
                        Thread.Sleep(3000);
                    }
                }

                if (letter == h)
                {
                    if (!isHshown)
                    {
                        isHshown = true;
                    }
                    else
                    {
                        Console.WriteLine("You already revealed this letter!");
                        Thread.Sleep(3000);
                    }
                }


                if (letter == a)
                {
                    if (!isAshown)
                    {
                        isAshown = true;
                    }
                    else
                    {
                        Console.WriteLine("You already revealed this letter!");
                        Thread.Sleep(3000);
                    }
                }

                if (letter == m)
                {
                    if (!isMshown)
                    {
                        isMshown = true;
                    }
                    else
                    {
                        Console.WriteLine("You already revealed this letter!");
                        Thread.Sleep(3000);
                    }
                }

                if (letter == p)
                {
                    if (!isPshown)
                    {
                        isPshown = true;
                    }
                    else
                    {
                        Console.WriteLine("You already revealed this letter!");
                        Thread.Sleep(3000);
                    }
                }


                if (letter == i)
                {
                    if (!isIshown)
                    {
                        isIshown = true;
                    }
                    else
                    {
                        Console.WriteLine("You already revealed this letter!");
                        Thread.Sleep(3000);
                    }
                }

                if (letter == o)
                {
                    if (!isOshown)
                    {
                        isOshown = true;
                    }
                    else
                    {
                        Console.WriteLine("You already revealed this letter!");
                        Thread.Sleep(3000);
                    }
                }

                if (letter == n)
                {
                    if (!isNshown)
                    {
                        isNshown = true;
                    }
                    else
                    {
                        Console.WriteLine("You already revealed this letter!");
                        Thread.Sleep(3000);
                    }
                }

                if (letter != c && letter != h && letter != a && letter != m &&
                    letter != p && letter != i && letter != o && letter != n)
                {
                    livesCount--;
                    Console.WriteLine("Wrong letter! Your lives are: {0}", livesCount);
                    Thread.Sleep(3000);              
                    if (livesCount == 0)
                    {
                        Console.WriteLine("Game over!");
                        Thread.Sleep(3000);
                        Main();
                    }
                }
            }

           
        }     
    }
}

