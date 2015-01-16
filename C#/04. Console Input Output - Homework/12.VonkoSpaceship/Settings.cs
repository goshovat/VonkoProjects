namespace VonkoSpaceship
{
    using System;

    public static class Settings
    {
        public const int FIELD_WIDTH = 70;
        public const int FIELD_HEIGHT = 60;

        public static void SetSettings()
        {
            Console.WindowWidth = FIELD_WIDTH;
            Console.WindowHeight = FIELD_HEIGHT;
            Console.BufferWidth = FIELD_WIDTH;
            Console.BufferHeight = FIELD_HEIGHT;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
        }
    }
}
