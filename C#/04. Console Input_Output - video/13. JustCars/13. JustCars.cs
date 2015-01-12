using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

struct Object //here we will keep info about the cars
{
    public int x;
    public int y;
    public ConsoleColor color;
    public char c;
}

class JustCars
{
    static void SetConsoleProperties()
    {
        Console.WindowWidth = 30;
        Console.WindowHeight = 25;
        Console.BufferWidth = Console.WindowWidth;
        Console.BufferHeight = Console.WindowHeight;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.BackgroundColor = ConsoleColor.White;
    }

    static void PrintOnPosition(int x, int y, char symbol, ConsoleColor color = ConsoleColor.Cyan)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(symbol);
    }

    static void PrintStringOnPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.Cyan)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(str);
    }

    static void DrawFieldBorder()
    {
        for (int i = 0; i < Console.WindowHeight; i++)
        {
            PrintOnPosition(playFieldWidth, i, '|', ConsoleColor.Black);
        }
    }

    static int playFieldWidth = 15;

    static void Main()
    {
        double acceleration = 0.1;
        double currentSpeed = 150;
        int currentSpeedInt = 0;
        int lives = 10;
        Object ownCar = new Object();
        ownCar.x = playFieldWidth / 2;
        ownCar.y = Console.WindowHeight - 1;
        ownCar.c = '@';
        ownCar.color = ConsoleColor.Magenta;
        Random randomGenerator = new Random();
        List<Object> objects = new List<Object>();

        while (true)
        {
            {
                Object newCar = new Object();
                int randomColor = randomGenerator.Next(0, 5);
                ConsoleColor carsColor = ConsoleColor.Gray;

                switch (randomColor)
                {
                    case 0: carsColor = ConsoleColor.Blue; break;
                    case 1: carsColor = ConsoleColor.Black; break;
                    case 2: carsColor = ConsoleColor.Green; break;
                    case 3: carsColor = ConsoleColor.DarkCyan; break;
                    case 4: carsColor = ConsoleColor.DarkMagenta; break;
                }

                int chance = randomGenerator.Next(0, 100);
                if (chance < 95)
                {
                    newCar.color = carsColor;
                    newCar.x = randomGenerator.Next(0, playFieldWidth);
                    newCar.y = 0;
                    newCar.c = '#';
                    objects.Add(newCar);
                }
                else
                {
                    Object bonusObject = new Object();
                    bonusObject.color = ConsoleColor.Red;
                    bonusObject.x = randomGenerator.Next(0, playFieldWidth);
                    bonusObject.y = 0;
                    bonusObject.c = '5';
                    objects.Add(bonusObject);
                }
            }


            if (Console.KeyAvailable)
            {
                //while (Console.KeyAvailable) Console.ReadKey(true);
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (ownCar.x > 0)
                    {
                        ownCar.x--;
                    }
                }
                if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (ownCar.x < playFieldWidth - 1)
                    {
                        ownCar.x++;
                    }
                }
            }

            SetConsoleProperties();

            List<Object> newList = new List<Object>();

            for (int i = 0; i < objects.Count; i++)
            {
                Object oldCar = objects[i];
                Object newObject = new Object();
                newObject.x = oldCar.x;
                newObject.y = oldCar.y + 1;
                newObject.c = oldCar.c;
                newObject.color = oldCar.color;
                if (newObject.y < Console.WindowHeight)
                {
                    newList.Add(newObject);
                    if ((newObject.c == '#') && (newObject.y == ownCar.y) && (newObject.x == ownCar.x))
                    {
                        lives--;
                        PrintOnPosition(ownCar.x, ownCar.y, 'x', ConsoleColor.Red);
                        Console.Beep(500, 500);
                        Thread.Sleep(500);
                        objects.Clear();
                        ownCar.x = playFieldWidth / 2;

                        if (lives == 0)
                        {
                            Console.Clear();
                            PrintStringOnPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2, "Game Over", ConsoleColor.Red);
                            Thread.Sleep(2000);
                            Main();
                        }
                    }
                    else if ((newObject.c == '5') && (newObject.y == ownCar.y) && (newObject.x == ownCar.x))
                    {
                        currentSpeed += 5.0;
                    }
                }
            }

            objects = newList;

            Console.Clear();
            PrintOnPosition(ownCar.x, ownCar.y, ownCar.c, ownCar.color);

            foreach (Object car in objects)
            {
                PrintOnPosition(car.x, car.y, car.c, car.color);
            }

            DrawFieldBorder();

            PrintStringOnPosition(playFieldWidth + 4, Console.WindowHeight / 2, "Lives: " + lives, ConsoleColor.Red);
            PrintStringOnPosition(playFieldWidth + 1, Console.WindowHeight / 2 + 2, "Easiness:" + currentSpeedInt, ConsoleColor.Red);

            currentSpeed -= acceleration;
            if (currentSpeed < 10)
            {
                currentSpeed = 10;
            }
            currentSpeedInt = (int)currentSpeed;
            Thread.Sleep((int)currentSpeed);
        }
    }
}

