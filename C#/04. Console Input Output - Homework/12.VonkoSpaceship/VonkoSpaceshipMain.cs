namespace VonkoSpaceship
{
    using System;
    using System.Threading;
    using System.Collections.Generic;

    /*I built this game with little more advanced knowledge, using simple OOP
    It is not exactly falling rocks, but very similar with the difference that
    we can fire with our ship and destroy the enemies. The highest scores done
    by a player are saved in a text file. Along the play the game gets more difficult.*/
    public static class VonkoSpaceshipMain
    {
        public const int START_LIVES = 5;
        public const int START_SCORE = -1;
        public const int START_DIFFICULTY = 0;
        public const int START_SHIP_CONST = 20;
        public const int START_DIFF_SHIP = 2;
        public static int lives, score, counterDifficulty,
            createShipConst, diffShipConst, highScore;
        public static int sleepValue;

        static void Main()
        {
            lives = START_LIVES;
            score = START_SCORE;
            counterDifficulty = START_DIFFICULTY;
            createShipConst = START_SHIP_CONST;
            diffShipConst = START_DIFF_SHIP;
            Settings.SetSettings();
            sleepValue = 200;

            try
            {
                highScore = RenderHighScores.LoadHighScores();
                RunGame();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        private static void RunGame()
        {
            RenderShips.CreateOwnShip();
            while (true)
            {
                if (counterDifficulty % 50 == 0)
                    sleepValue -= 5;
                if (counterDifficulty % 200 == 0)
                    diffShipConst++;
                if (counterDifficulty % 100 == 0)
                    score++;

                Thread.Sleep(sleepValue);
                Console.Clear();
                RenderShips.DrawOwnShip();
                if (createShipConst <= 0)
                {
                    RenderShips.CreateEnemyShips();
                    createShipConst = START_SHIP_CONST;
                }
                RenderShips.DrawEnemyShips();
                RenderRockets.DrawRockets();
                //every move we need to reset the press key unless another one is pressed
                ProcessKeys();
                RenderShips.MoveEnemyShipsDown();
                RenderRockets.MoveRockets();
                int scoreKills = RenderRockets.DestroyEnemyShips();
                if (RenderShips.CheckForCollisions())
                {
                    PrintKillMessage();
                    break;
                }
                RenderDataBoard.DrawDataBoard(score, lives);
                counterDifficulty++;
                createShipConst -= diffShipConst;
                score += scoreKills;
            }
        }

        private static void ProcessKeys()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                while (Console.KeyAvailable) Console.ReadKey(true);

                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (RenderShips.ownShip.Col > 0)
                        RenderShips.ownShip.Col--;
                }
                if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (RenderShips.ownShip.Col < Settings.FIELD_WIDTH - RenderShips.SHIP_LEN)
                        RenderShips.ownShip.Col++;
                }

                if (pressedKey.Key == ConsoleKey.Spacebar)
                {
                    RenderShips.ownShip.Shoot();
                }
            }
        }
        private static void PrintKillMessage()
        {
            if (lives > 1)
            {
                Thread.Sleep(1000);
                Console.Clear();
                RenderDataBoard.PrintConsoleMessage(
                    "You lost a life", Settings.FIELD_WIDTH / 2 - 8, Settings.FIELD_HEIGHT / 2, 1500);

                lives--;
                RunGame();
            }
            else
            {
                Thread.Sleep(1000);
                Console.Clear();
                RenderDataBoard.PrintConsoleMessage(
                    "YOU ARE DEAD!!!", 26, Settings.FIELD_HEIGHT / 2, 1500);
                RenderHighScores.WriteHighScore(highScore, score);
            }
        }
    }
}
