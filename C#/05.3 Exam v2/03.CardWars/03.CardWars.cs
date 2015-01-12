using System;
using System.Collections.Generic;
using System.Numerics;

class CardWars
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        //in these lists will be stored the cards drawn for each player
        List<string> playerOneCards = new List<string>();
        List<string> playerTwoCards = new List<string>();

        string currentCard = "";

        //draw the cards
        for (int gameRound = 0; gameRound < n; gameRound++)
        {
            //player one cards for each game
            for (int j = 0; j < 3; j++)
            {
                currentCard = Console.ReadLine();
                playerOneCards.Add(currentCard);
            }
            //player two cards for each game
            for (int j = 0; j < 3; j++)
            {
                currentCard = Console.ReadLine();
                playerTwoCards.Add(currentCard);
            }
        }

        //the card types and their scores will be stored in char arrays
        string[] cardTypes = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "A", "J", "Q", "K", "Y", "Z", "X" };
        int[] cardScores = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 11, 12, 13 };

        BigInteger playerOneTotalScore = 0;
        BigInteger playerOneWonGames = 0;

        BigInteger playerTwoTotalScore = 0;
        BigInteger playerTwoWonGames = 0;

        int offset = 0;

        //calculate the socres
        for (int gameRound = 0; gameRound < n; gameRound++)
        {
            bool playerOneWinCard = false;
            bool playerTwoWinCard = false;

            BigInteger playerOneCurrentScore = 0;
            BigInteger playerTwoCurrentScore = 0;

            //check the cards of player one for this round
            for (int i = 0; i < 3; i++)
            {
                int currentIndexPlayerOne = Array.IndexOf(cardTypes, playerOneCards[i + offset]);

                if (currentIndexPlayerOne != 13 && currentIndexPlayerOne != 14 && currentIndexPlayerOne != 15)
                {
                    playerOneCurrentScore += cardScores[currentIndexPlayerOne];
                }
                else if (currentIndexPlayerOne == 13)
                {
                    playerOneTotalScore -= 200;
                }
                else if (currentIndexPlayerOne == 14)
                {
                    playerOneTotalScore *= 2;
                }
                else if (currentIndexPlayerOne == 15)
                {
                    playerOneWinCard = true;
                }
            }

            //check the cards of player two for this round
            for (int i = 0; i < 3; i++)
            {
                int currentIndexPlayerTwo = Array.IndexOf(cardTypes, playerTwoCards[i + offset]);

                if (currentIndexPlayerTwo != 13 && currentIndexPlayerTwo != 14 && currentIndexPlayerTwo != 15)
                {
                    playerTwoCurrentScore += cardScores[currentIndexPlayerTwo];
                }
                else if (currentIndexPlayerTwo == 13)
                {
                    playerTwoTotalScore -= 200;
                }
                else if (currentIndexPlayerTwo == 14)
                {
                    playerTwoTotalScore *= 2;
                }
                else if (currentIndexPlayerTwo == 15)
                {
                    playerTwoWinCard = true;
                }
            }

            //check who is the winner of the round
            if (playerOneWinCard && playerTwoWinCard)
            {
                playerOneTotalScore += 50;
                playerTwoTotalScore += 50;
            }
            else if (playerOneWinCard && !playerTwoWinCard)
            {
                Console.WriteLine("X card drawn! Player one wins the match!");
                return;
            }
            else if (!playerOneWinCard && playerTwoWinCard)
            {
                Console.WriteLine("X card drawn! Player two wins the match!");
                return;
            }

            if (playerOneCurrentScore > playerTwoCurrentScore)
            {
                playerOneTotalScore += playerOneCurrentScore;
                playerOneWonGames++;
            }
            else if (playerTwoCurrentScore > playerOneCurrentScore)
            {
                playerTwoTotalScore += playerTwoCurrentScore;
                playerTwoWonGames++;
            }

            offset += 3;
        }

        //print the final result
        if (playerOneTotalScore > playerTwoTotalScore)
        {
            Console.WriteLine("First player wins!");
            Console.WriteLine("Score: {0}", playerOneTotalScore);
            Console.WriteLine("Games won: {0}", playerOneWonGames);
        }
        else if (playerTwoTotalScore > playerOneTotalScore)
        {
            Console.WriteLine("Second player wins!");
            Console.WriteLine("Score: {0}", playerTwoTotalScore);
            Console.WriteLine("Games won: {0}", playerTwoWonGames);
        }
        else if (playerOneTotalScore == playerTwoTotalScore)
        {
            Console.WriteLine("It's a tie!");
            Console.WriteLine("Score: {0}", playerOneTotalScore);
        }
    }
}

