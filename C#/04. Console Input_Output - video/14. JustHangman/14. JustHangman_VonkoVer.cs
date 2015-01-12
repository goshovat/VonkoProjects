using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


class JustHangman_VonkoVer
{
    static void Main()
    {
        string winnigWord = "champion";
        string finalWord = "________";
        string condition = "You have to guess a word that means a winner,\r\nsomebody who was the best at something:";
        int triesRemaining = winnigWord.Length;

        char hiddenChar = '_';

        char firstSymbol = hiddenChar;
        char secondSymbol = hiddenChar;
        char thirdSymbol = hiddenChar;
        char fourthSymbol = hiddenChar;
        char fifthSymbol = hiddenChar;
        char sixthSymbol = hiddenChar;
        char seventhSymbol = hiddenChar;
        char eighthSymbol = hiddenChar;

        Console.WriteLine(condition);
        Console.WriteLine();

        for (int j = 0; j < winnigWord.Length; j++)
        {
            if (firstSymbol == '_')
            {
                Console.WriteLine("Write first letter: ");
                ConsoleKeyInfo pressedFirstKey = Console.ReadKey();
                if (pressedFirstKey.Key == ConsoleKey.C)
                {
                    firstSymbol = 'C';
                }
            }
            Console.WriteLine();

            if (secondSymbol == '_')
            {
                Console.WriteLine("Write second letter: ");
                ConsoleKeyInfo pressedSecondKey = Console.ReadKey();
                if (pressedSecondKey.Key == ConsoleKey.H)
                {
                    secondSymbol = 'H';
                }
            }
            Console.WriteLine();

            if (thirdSymbol == '_')
            {
                Console.WriteLine("Write third letter: ");
                ConsoleKeyInfo pressedThirdKey = Console.ReadKey();
                if (pressedThirdKey.Key == ConsoleKey.A)
                {
                    thirdSymbol = 'A';
                }
            }
            Console.WriteLine();

            if (fourthSymbol == '_')
            {
                Console.WriteLine("Write fourth letter: ");
                ConsoleKeyInfo pressedFourthKey = Console.ReadKey();
                if (pressedFourthKey.Key == ConsoleKey.M)
                {
                    fourthSymbol = 'M';
                }
            }
            Console.WriteLine();

            if (fifthSymbol == '_')
            {
                Console.WriteLine("Write fifth letter: ");
                ConsoleKeyInfo pressedFifthKey = Console.ReadKey();
                if (pressedFifthKey.Key == ConsoleKey.P)
                {
                    fifthSymbol = 'P';
                }
            }
            Console.WriteLine();

            if (sixthSymbol == '_')
            {
                Console.WriteLine("Write sixth letter: ");
                ConsoleKeyInfo pressedSixthKey = Console.ReadKey();
                if (pressedSixthKey.Key == ConsoleKey.I)
                {
                    sixthSymbol = 'I';
                }
            }
            Console.WriteLine();

            if (seventhSymbol == '_')
            {
                Console.WriteLine("Write seventh letter: ");
                ConsoleKeyInfo pressedSeventhKey = Console.ReadKey();
                if (pressedSeventhKey.Key == ConsoleKey.O)
                {
                    seventhSymbol = 'O';
                }
            }
            Console.WriteLine();

            if (eighthSymbol == '_')
            {
                Console.WriteLine("Write eighth letter: ");
                ConsoleKeyInfo pressedEighthKey = Console.ReadKey();
                if (pressedEighthKey.Key == ConsoleKey.N)
                {
                    eighthSymbol = 'N';
                }
            }
            Console.WriteLine();

            Console.Clear();

            finalWord = firstSymbol + " " + secondSymbol + " " + thirdSymbol + " " +
                fourthSymbol + " " + fifthSymbol + " " + sixthSymbol + " " +
                seventhSymbol + " " + eighthSymbol;

            Console.WriteLine(condition);
            Console.WriteLine();

            Console.WriteLine(finalWord);            
            Console.WriteLine();

            if (finalWord == "C H A M P I O N")
            {
                Console.WriteLine("You win, baby!");
                Console.WriteLine();
            }
            else
            {
                triesRemaining--;
                Console.WriteLine("Tries remaining: {0}", triesRemaining);
                Console.WriteLine("Press any key to continue: ");
                Console.ReadKey();
                Console.WriteLine();
            }   
        }

        if (finalWord != "C H A M P I O N")
        {
            Console.WriteLine("You lost and you are publically raped!");
            Thread.Sleep(6000);
        }
    }
}

