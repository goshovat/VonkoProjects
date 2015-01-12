namespace VonkoSpaceship
{
    using System;
    using System.IO;

    public static class RenderHighScores
    {
        public const string FILE_NAME = "highscores.txt";

        public static int LoadHighScores()
        {
            if (!File.Exists(FILE_NAME))
                return 0;

            int lasthighScore = 0;
            StreamReader reader = new StreamReader(FILE_NAME);
            try
            {
                using (reader)
                {
                    string[] line = reader.ReadLine().Split();
                    lasthighScore = int.Parse(line[1]);
                }
            }
            catch (FormatException)
            {
                RenderDataBoard.PrintConsoleMessage(
                    string.Format("Error! Invalid highscore value in '{0}'", FILE_NAME));
                return 0;
            }
            catch (IndexOutOfRangeException)
            {
                RenderDataBoard.PrintConsoleMessage(
                    string.Format("Error! Invalid highscore value in '{0}'", FILE_NAME));
                return 0;
            }
            catch (IOException)
            {
                RenderDataBoard.PrintConsoleMessage(
                    string.Format("Error occured during reading from highscores file '{0}'", FILE_NAME));
                return 0;
            }
            return lasthighScore;
        }

        public static void WriteHighScore(int highScore, int currentScore)
        {
            if (currentScore > highScore)
            {
                highScore = currentScore;
                Console.Clear();
                RenderDataBoard.PrintConsoleMessage(
                    "YOU ARE DEAD!!!", 25, Settings.FIELD_HEIGHT / 2 + 1, 0);
                RenderDataBoard.PrintConsoleMessage(
                    "Cogratulations! You have set a new high score.", 10, Settings.FIELD_HEIGHT / 2 + 2, 0);
                RenderDataBoard.PrintConsoleMessage(
                    "Write your nickname:", 20, Settings.FIELD_HEIGHT / 2 + 3, 0);
                Console.SetCursorPosition(20, Settings.FIELD_HEIGHT / 2 + 4);
                Console.CursorVisible = true;
                string nickName = Console.ReadLine();
                StreamWriter writer = new StreamWriter(FILE_NAME);

                try
                {
                    using (writer)
                    {
                        writer.WriteLine("{0} {1}", nickName, highScore);
                    }
                }
                catch (IOException)
                {
                    RenderDataBoard.PrintConsoleMessage(
                            string.Format("Error occured writing highscores file '{0}'", FILE_NAME));
                }
            }
        }      
    }
}
