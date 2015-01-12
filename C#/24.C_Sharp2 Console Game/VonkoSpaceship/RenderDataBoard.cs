namespace VonkoSpaceship
{
    using System;
    using System.Threading;

     public static class RenderDataBoard
    {
        public static void DrawDataBoard(int currentScore, int currentLives)
        {
            Console.SetCursorPosition(20, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Score: {0}             Lives: {1}", currentScore, currentLives);
        }

        public static void PrintConsoleMessage(string message)
        {
            Console.SetCursorPosition(10, Settings.FIELD_HEIGHT / 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Thread.Sleep(3500);
        }

        public static void PrintConsoleMessage(string message, int col, int row, int sleep)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Thread.Sleep(sleep);
        }
    }
}
