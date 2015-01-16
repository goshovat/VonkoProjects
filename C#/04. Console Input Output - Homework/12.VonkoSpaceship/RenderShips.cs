namespace VonkoSpaceship
{
    using System;
    using System.Collections.Generic;

    public static class RenderShips
    {
        public const string OWN_SHIP_SYMBOL = "oVo";
        public const int SHIP_LEN = 3;
        public const int SHIP_DISTANCE = 4;
        public static Ship ownShip;
        public static HashSet<Ship> enemyShips = new HashSet<Ship>();
        private static char[] possibleSymbols = { 'c', 'o', '@', '#', 'h', '+', 'k', 'v', 'd', 
                                                'n', 'm', 'x', 'p', 'w', 'z', 'g', 's'};

        #region OwnShip
        static public void CreateOwnShip()
        {
            ownShip = new Ship(Settings.FIELD_WIDTH / 2 - 1, Settings.FIELD_HEIGHT - 2,
                ConsoleColor.Green, OWN_SHIP_SYMBOL);
        }

        static public void DrawOwnShip()
        {
            Console.ForegroundColor = ownShip.Color;
            Console.SetCursorPosition(ownShip.Col, ownShip.Row);
            Console.Write(ownShip.Symbol);
        }
        #endregion

        #region EnemyShips
        static public void CreateEnemyShips()
        {
            Random randomGen = new Random();
            int shipNumber = randomGen.Next(0, 6);
            int col = randomGen.Next(0, Settings.FIELD_WIDTH - SHIP_LEN + 1);

            for (int i = 0; i < shipNumber; i++)
            {
                if (col < Settings.FIELD_WIDTH - SHIP_LEN) 
                {
                    int row = 1;
                    ConsoleColor shipColor = (ConsoleColor)randomGen.Next(10, 16);
                    char shipChar = possibleSymbols[randomGen.Next(0, possibleSymbols.Length)];
                    string symbol = (char)shipChar + "" + (char)shipChar + (char)shipChar;
                    Ship enemyShip = new Ship(col, row, shipColor, symbol);
                    enemyShips.Add(enemyShip);
                    col += SHIP_DISTANCE;
                }
            }
        }

        public static void DrawEnemyShips()
        {
            foreach (Ship enemyShip in enemyShips)
            {
                Console.ForegroundColor = enemyShip.Color;
                Console.SetCursorPosition(enemyShip.Col, enemyShip.Row);
                Console.Write(enemyShip.Symbol);
            }
        }

        public static void MoveEnemyShipsDown()
        {
            HashSet<Ship> shipsToRemove = new HashSet<Ship>();
            foreach (Ship ship in enemyShips)
            {
                ship.Row++;
                if (ship.Row >= Settings.FIELD_HEIGHT)
                {
                    shipsToRemove.Add(ship);
                }
            }
            foreach (Ship shipToRemove in shipsToRemove)
                enemyShips.Remove(shipToRemove);
        }
        #endregion

        //check collision between own ship and enemy ships
        public static bool CheckForCollisions()
        {
            foreach(Ship enemyShip in enemyShips) 
            {
                if (enemyShip.Col + SHIP_LEN - 1 >= ownShip.Col &&
                    enemyShip.Col <= ownShip.Col + SHIP_LEN -1 &&
                    enemyShip.Row == ownShip.Row)
                {
                    Console.SetCursorPosition(ownShip.Col + 1, ownShip.Row);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('X');
                    enemyShips.Clear();
                    RenderRockets.rocketsFired.Clear();
                    return true;
                }
            }
            return false;
        }
    }
}
