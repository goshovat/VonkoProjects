using System;

class RandomMessage
{
    static Random randomGenerator = new Random();

    static void Main()
    {
        Console.WindowWidth = 100;

        string[] hailPhrases = {"Продуктът е отличен.", "Това е страхотен продукт.", "Постоянно ползвам този продукт.", 
                                   "Това е най-добрият продукт от тази категория."};
        string[] hailStories = { "Вече се чувствам добре.", "Успях да се променя.", "Той направи чудо.", 
                                   "Не мога да повярвам, но вече се чувствам страхотно.", "Опитайте и вие. Аз съм много доволна." };
        string[] firstNames = { "Диана", "Петя", "Стела", "Елена", "Катя" };
        string[] lastNames = { "Иванова", "Петрова", "Кирова" };
        string[] cities = { "София", "Пловдив", "Варна", "Русе", "Бургас" };

        string result = GetRandomPhrase(hailPhrases, "hailPhrases") + GetRandomPhrase(hailStories, "hailStories") 
            + GetRandomPhrase(firstNames, "firstNames") + GetRandomPhrase(lastNames, "lastNames") + GetRandomPhrase(cities, "cities");

        Console.WriteLine(result);
    }

    private static string GetRandomPhrase(string[] phrase, string typeOfPhrases)
    {
        int randomIndex = randomGenerator.Next(phrase.Length);

        if (typeOfPhrases == "firstNames")
            return "--" + phrase[randomIndex] + " ";
        else if (typeOfPhrases == "lastNames")
            return phrase[randomIndex] + ", ";
        else
            return phrase[randomIndex] + " ";
    }
}
