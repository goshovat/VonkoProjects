using System;
using System.Threading;


class JustPongGame
{
    static int firstPlayerPadSize = 4;
    static int secondPlayerPadSize = 4;
    static int ballPositionX = 0;
    static int ballPositionY = 0;
    //determines if the ball direction is up and right
    static bool ballDirectionUp = true;
    static bool ballDirectionRight = false;
    static int firstPlayerPosition = 0;
    static int secondPlayerPosition = 0;
    static int firstPlayerScore = 0;
    static int secondPlayerScore = 0;
    static Random randomGenerator = new Random();

    static void SetConsoleProperties()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WindowHeight = 18;
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.BufferWidth;
    }

    private static void PrintAtPosition(int x, int y, char symbol)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(symbol);
    }

    private static void SetInitialPositions()
    {
        firstPlayerPosition = Console.WindowHeight / 2 - firstPlayerPadSize / 2;
        secondPlayerPosition = Console.WindowHeight / 2 - secondPlayerPadSize / 2;
        ballPositionX = Console.WindowWidth / 2;
        ballPositionY = Console.WindowHeight / 2;
    }

    static void DrawFirstPlayer()
    {
        for (int y = firstPlayerPosition; y < firstPlayerPosition + firstPlayerPadSize; y++)
        {
            PrintAtPosition(0, y, '|');
            PrintAtPosition(1, y, '|');
        }
    }

    static void DrawSecondPlayer()
    {
        for (int z = secondPlayerPosition; z < secondPlayerPosition + secondPlayerPadSize; z++)
        {
            PrintAtPosition(Console.WindowWidth - 1, z, '|');
            PrintAtPosition(Console.WindowWidth - 2, z, '|');
        }
    }

    private static void DrawBall()
    {
        PrintAtPosition(ballPositionX, ballPositionY, '@');
    }

    private static void PrintResult()
    {
        Console.SetCursorPosition(Console.WindowWidth / 2 - 2, 0);
        Console.WriteLine("{0} - {1}", firstPlayerScore, secondPlayerScore);
    }

    private static void MoveFirstPlayerUp()
    {
        if (firstPlayerPosition > 0)
        {
            firstPlayerPosition--;
        }
    }

    private static void MoveFirstPlayerDown()
    {
        if (firstPlayerPosition < Console.WindowHeight - firstPlayerPadSize)
        {
            firstPlayerPosition++;
        }
    }

    private static void MoveSecondPlayerUp()
    {
        if (secondPlayerPosition > 0)
        {
            secondPlayerPosition--;
        }
    }

    private static void MoveSecondPlayerDown()
    {
        if (secondPlayerPosition < Console.WindowHeight - secondPlayerPadSize)
        {
            secondPlayerPosition++;
        }
    }

    private static void SecondPlayerAIMove()
    {
        int randomNumber = randomGenerator.Next(0, 101);

        if (randomNumber < 60)
        {
            if (ballDirectionUp == true)
            {
                MoveSecondPlayerUp();
            }
            else
            {
                MoveSecondPlayerDown();
            }
        }
    }

    private static void MoveBall()
    {
        if (ballPositionY == 0)
        {
            ballDirectionUp = false;
        }
        if (ballPositionY == Console.WindowHeight - 1)
        {
            ballDirectionUp = true;
        }

        if ((ballPositionX == Console.WindowWidth - 2) &&
            (ballPositionY >= secondPlayerPosition) &&
            (ballPositionY <= secondPlayerPosition + secondPlayerPadSize))
        {
            ballDirectionRight = false;
        }

        if ((ballPositionX == 2) &&
            (ballPositionY >= firstPlayerPosition) &&
            (ballPositionY <= firstPlayerPosition + firstPlayerPadSize))
        {
            ballDirectionRight = true;
        }

        if ((ballPositionX == 0) && ((ballPositionY < firstPlayerPosition)
            || (ballPositionY > firstPlayerPosition + firstPlayerPadSize)))
        {
            secondPlayerScore++;
            Console.ReadKey();
            Main();
        }

        if ((ballPositionX == Console.WindowWidth -1) && ((ballPositionY < secondPlayerPosition) ||
            (ballPositionY > secondPlayerPosition + secondPlayerPadSize)))
        {
            firstPlayerScore++;
            Console.ReadKey();
            ballDirectionRight = false;
            Main();
        }

        if (ballDirectionUp)
        {
            ballPositionY--;
        }
        else
        {
            ballPositionY++;
        }

        if (ballDirectionRight)
        {
            ballPositionX++;
        }
        else
        {
            ballPositionX--;
        }

    }

    private static void WinGame()
    {
        if (firstPlayerScore == 15)
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, 0);
            Console.WriteLine("Player 1 wins!");
            firstPlayerScore = 0;
            secondPlayerScore = 0;
            Console.ReadKey();
            Main();
        }
        if (secondPlayerScore == 15)
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, 0);
            Console.WriteLine("Player 2 wins!");
            firstPlayerScore = 0;
            secondPlayerScore = 0;
            Console.ReadKey();
            Main();
        }
    }

    static void Main()
    {
        SetConsoleProperties();
        SetInitialPositions();

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    MoveFirstPlayerUp();
                }
                if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    MoveFirstPlayerDown();
                }
            }

            SecondPlayerAIMove();
            MoveBall();
            Console.Clear();
            DrawFirstPlayer();
            DrawSecondPlayer();
            DrawBall();
            PrintResult();
            WinGame();
            Thread.Sleep(60);
        }
    }

}


/*_________________________________
|              1-0                 |
|                                  |
||                                 |
||                                 |
||                                ||
||              *                 ||
|                                 ||
|                                 ||
|                                  |
|                                  |
|                                  |
|                                  |                 
|___________________________________*/