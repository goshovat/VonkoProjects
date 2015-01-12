namespace VonkoSpaceship
{
    using System;

    public class Ship
    {
        public int Col { get; set; }
        public int Row { get; set; }
        public ConsoleColor Color { get; set; }
        public string Symbol { get; set; }

        public Ship
            (int col, int row, ConsoleColor color, string symbol)
        {

            this.Col = col;
            this.Row = row;
            this.Color = color;
            this.Symbol = symbol;
        }

        public void Shoot()
        {
            Rocket rocket = new Rocket(this.Col + 1, this.Row - 1);
            RenderRockets.rocketsFired.Add(rocket);
        }
    }
}
