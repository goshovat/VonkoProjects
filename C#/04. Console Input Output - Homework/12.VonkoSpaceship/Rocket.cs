namespace VonkoSpaceship
{
    using System;

    public class Rocket
    {
        public const char ROCKET_SYMBOL = '*';
        public const ConsoleColor ROCKET_COLOR = ConsoleColor.White;
        public int Col { get; set; }
        public int Row { get; set; }

        public Rocket(int col, int row)
        {
            this.Col = col;
            this.Row = row;
        }
    }
}
