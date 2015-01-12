using System;
using System.Collections.Generic;

namespace DeckStructure
{
    class TestDeckStructure
    {
        static void Main()
        {
            Deck<int> integerDeck = new Deck<int>();

            //test the push method
            for (int i = 1; i <= 3; i++)
            {
                integerDeck.PushLeft(i);
                integerDeck.PushRight(i);
            }

            //test the pop method
            int elementPoppedLeft = integerDeck.PopLeft();
            int secondElementPoppedLeft = integerDeck.PopLeft();
            int elementPoppedRight = integerDeck.PopRight();

            //test the contains method
            Console.WriteLine(integerDeck.Contains(2));
            Console.WriteLine(integerDeck.Contains(5));

            //test the clear method
            integerDeck.Clear();
        }
    }
}
