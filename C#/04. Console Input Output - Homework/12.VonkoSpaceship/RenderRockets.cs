namespace VonkoSpaceship
{
    using System;
    using System.Collections.Generic;

    public static class RenderRockets
    {
        public static HashSet<Rocket> rocketsFired = new HashSet<Rocket>();

        public static void DrawRockets()
        {
            foreach (Rocket rocket in rocketsFired)
            {
                Console.SetCursorPosition(rocket.Col, rocket.Row);
                Console.ForegroundColor = Rocket.ROCKET_COLOR;
                Console.Write(Rocket.ROCKET_SYMBOL);
            }
        }

        public static void MoveRockets()
        {
            HashSet<Rocket> rocketsToRemove = new HashSet<Rocket>();

            foreach (Rocket rocket in rocketsFired)
            {
                rocket.Row--;
                if (rocket.Row <= 0)
                {
                    rocketsToRemove.Add(rocket);
                }
            }
            foreach (Rocket rocket in rocketsToRemove)
                rocketsFired.Remove(rocket);
        }

        public static int DestroyEnemyShips()
        {
            HashSet<Ship> shipsDestroyed = new HashSet<Ship>();
            HashSet<Rocket> rocketsBlown = new HashSet<Rocket>();
            int scoreKills = 0;

            foreach (Rocket rocket in rocketsFired) 
            {
                foreach (Ship ship in RenderShips.enemyShips)
                {
                    if ((rocket.Row == ship.Row || rocket.Row == ship.Row - 1)
                        && rocket.Col >= ship.Col && rocket.Col <= ship.Col + 2)
                    {
                        shipsDestroyed.Add(ship);
                        rocketsBlown.Add(rocket);
                        Console.SetCursorPosition(rocket.Col, rocket.Row);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('X');
                        scoreKills += 5;
                    }
                }
            }

            foreach (Rocket rocket in rocketsBlown)
            {
                rocketsFired.Remove(rocket);
            }
            foreach (Ship ship in shipsDestroyed)
            {
                RenderShips.enemyShips.Remove(ship);
            }
            return scoreKills;
        }
    }
}
