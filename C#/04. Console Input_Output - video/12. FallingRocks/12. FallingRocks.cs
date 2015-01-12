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
    public string s;
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
        Object dwarf = new Object();
        dwarf.x = playFieldWidth / 2;
        dwarf.y = Console.WindowHeight - 1;
        dwarf.c = '@';
        dwarf.color = ConsoleColor.Magenta;
        Random randomGenerator = new Random();
        List<Object> objects = new List<Object>();

        while (true)
        {
            {
                Object newRock = new Object();
                int randomColor = randomGenerator.Next(0, 5);
                int randomRockType = randomGenerator.Next(0, 12);
                ConsoleColor rocksColor = ConsoleColor.Gray;

                switch (randomColor)
                {
                    case 0: rocksColor = ConsoleColor.Blue; break;
                    case 1: rocksColor = ConsoleColor.Black; break;
                    case 2: rocksColor = ConsoleColor.Green; break;
                    case 3: rocksColor = ConsoleColor.DarkCyan; break;
                    case 4: rocksColor = ConsoleColor.DarkMagenta; break;
                }

                int chance = randomGenerator.Next(0, 100);
                if ((chance < 100) && (chance > 90))
                {
                    newRock.color = rocksColor;
                    newRock.x = randomGenerator.Next(0, playFieldWidth-2);
                    newRock.y = 0;
                    switch (randomRockType)
                    {
                        case 0: newRock.s = "^^^"; break;
                        case 1: newRock.s = "***"; break;
                        case 2: newRock.s = "&&&"; break;
                        case 3: newRock.s = "+++"; break;
                        case 4: newRock.s = "%%%"; break;
                        case 5: newRock.s = "$$$"; break;
                        case 6: newRock.s = "###"; break;
                        case 7: newRock.s = "!!!"; break;
                        case 8: newRock.s = "..."; break;
                        case 9: newRock.s = ";;;"; break;
                        case 10: newRock.s = "---"; break;
                        case 11: newRock.s = "@@@"; break;
                    }
                    objects.Add(newRock);
                }
                else if ((chance <= 90) && (chance >= 70))
                {
                    newRock.color = rocksColor;
                    newRock.x = randomGenerator.Next(0, playFieldWidth - 2);
                    newRock.y = 0;
                    switch (randomRockType)
                    {
                        case 0: newRock.s = "^^"; break;
                        case 1: newRock.s = "**"; break;
                        case 2: newRock.s = "&&"; break;
                        case 3: newRock.s = "++"; break;
                        case 4: newRock.s = "%%"; break;
                        case 5: newRock.s = "$$"; break;
                        case 6: newRock.s = "##"; break;
                        case 7: newRock.s = "!!"; break;
                        case 8: newRock.s = ".."; break;
                        case 9: newRock.s = ";;"; break;
                        case 10: newRock.s = "--"; break;
                        case 11: newRock.s = "@@"; break;
                    }
                    objects.Add(newRock);
                }
                else if ((chance < 70) && (chance > 5))
                {
                    newRock.color = rocksColor;
                    newRock.x = randomGenerator.Next(0, playFieldWidth - 2);
                    newRock.y = 0;
                    switch (randomRockType)
                    {
                        case 0: newRock.s = "^"; break;
                        case 1: newRock.s = "*"; break;
                        case 2: newRock.s = "&"; break;
                        case 3: newRock.s = "+"; break;
                        case 4: newRock.s = "%"; break;
                        case 5: newRock.s = "$"; break;
                        case 6: newRock.s = "#"; break;
                        case 7: newRock.s = "!"; break;
                        case 8: newRock.s = "."; break;
                        case 9: newRock.s = ";"; break;
                        case 10: newRock.s = "-"; break;
                        case 11: newRock.s = "@"; break;
                    }
                    objects.Add(newRock);
                }
                else if (chance <= 5)
                {
                    Object bonusObject = new Object();
                    bonusObject.color = ConsoleColor.Red;
                    bonusObject.x = randomGenerator.Next(0, playFieldWidth);
                    bonusObject.y = 0;
                    bonusObject.s = "5";
                    objects.Add(bonusObject);
                }
            }


            if (Console.KeyAvailable)
            {
                //while (Console.KeyAvailable) Console.ReadKey(true);
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (dwarf.x > 0)
                    {
                        dwarf.x--;
                    }
                }
                if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (dwarf.x < playFieldWidth - 3)
                    {
                        dwarf.x++;
                    }
                }
            }

            SetConsoleProperties();

            List<Object> newList = new List<Object>();

            for (int i = 0; i < objects.Count; i++)
            {
                Object oldRock = objects[i];
                Object newObject = new Object();
                newObject.x = oldRock.x;
                newObject.y = oldRock.y + 1;
                newObject.s = oldRock.s;
                newObject.color = oldRock.color;
                if (newObject.y < Console.WindowHeight)
                {
                    newList.Add(newObject);
                    if ((newObject.s.Length == 3) && (newObject.y == dwarf.y) && ((newObject.x >= dwarf.x && newObject.x <= dwarf.x+2) ||
                        (newObject.x >= dwarf.x-2) && (newObject.x < dwarf.x + 2)))
                    {
                        lives--;
                        PrintStringOnPosition(dwarf.x+1, dwarf.y, "x", ConsoleColor.Red);
                        Console.Beep(500, 500);
                        Thread.Sleep(500);
                        objects.Clear();
                        dwarf.x = playFieldWidth / 2;

                        if (lives == 0)
                        {
                            Console.Clear();
                            PrintStringOnPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2, "Game Over", ConsoleColor.Red);
                            Thread.Sleep(2000);
                            Main();
                        }
                    }
                    else if ((newObject.s.Length == 2) && (newObject.y == dwarf.y) && ((newObject.x >= dwarf.x && newObject.x <= dwarf.x+2) ||
                        (newObject.x >= dwarf.x - 1) && (newObject.x < dwarf.x + 1)))
                    {
                        lives--;
                        PrintStringOnPosition(dwarf.x + 1, dwarf.y, "x", ConsoleColor.Red);
                        Console.Beep(500, 500);
                        Thread.Sleep(500);
                        objects.Clear();
                        dwarf.x = playFieldWidth / 2;

                        if (lives == 0)
                        {
                            Console.Clear();
                            PrintStringOnPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2, "Game Over", ConsoleColor.Red);
                            Thread.Sleep(2000);
                            Main();
                        }
                    }
                    else if ((newObject.s.Length == 1 && newObject.s != "5") && (newObject.y == dwarf.y) && (newObject.x >= dwarf.x && newObject.x <= dwarf.x+2))
                    {
                        lives--;
                        PrintStringOnPosition(dwarf.x + 1, dwarf.y, "x", ConsoleColor.Red);
                        Console.Beep(500, 500);
                        Thread.Sleep(500);
                        objects.Clear();
                        dwarf.x = playFieldWidth / 2;

                        if (lives == 0)
                        {
                            Console.Clear();
                            PrintStringOnPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2, "Game Over", ConsoleColor.Red);
                            Thread.Sleep(2000);
                            Main();
                        }
                    }
                    else if ((newObject.s == "5") && (newObject.y == dwarf.y) && (newObject.x >= dwarf.x && newObject.x <= dwarf.x + 2))
                    {
                        currentSpeed += 5.0;
                    }
                }
            }

            objects = newList;

            Console.Clear();

            //Here we draw our dwarf
            PrintStringOnPosition(dwarf.x, dwarf.y, "(0)", dwarf.color);

            foreach (Object rock in objects)
            {
                PrintStringOnPosition(rock.x, rock.y, rock.s, rock.color);
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

