using System;

class Gardens
{
    static void Main()
    {
        //tomato cucumber potato carrot cabbage beans
        decimal tomatoSeedsAmount = decimal.Parse(Console.ReadLine());
        decimal tomatoSeedPrice = 0.5m;
        int tomatoArea = int.Parse(Console.ReadLine());

        decimal cucumberSeedsAmount = decimal.Parse(Console.ReadLine());
        decimal cucumberSeedPrice = 0.4m;
        int cucumberArea = int.Parse(Console.ReadLine());

        decimal potatoSeedsAmount = decimal.Parse(Console.ReadLine());
        decimal potatoSeedPrice = 0.25m;
        int potatoArea = int.Parse(Console.ReadLine());

        decimal carrotSeedsAmount = decimal.Parse(Console.ReadLine());
        decimal carrotSeedPrice = 0.6m;
        int carrotArea = int.Parse(Console.ReadLine());

        decimal gabbageSeedsAmount = decimal.Parse(Console.ReadLine());
        decimal cabbageSeedPrice = 0.3m;
        int gabbageArea = int.Parse(Console.ReadLine());

        decimal beansSeedsAmount = decimal.Parse(Console.ReadLine());
        decimal beansSeedPrice = 0.4m;

        //make the calcualations
        decimal totalCost = tomatoSeedsAmount * tomatoSeedPrice + cucumberSeedsAmount * cucumberSeedPrice +
            potatoSeedsAmount * potatoSeedPrice + carrotSeedsAmount * carrotSeedPrice + gabbageSeedsAmount * cabbageSeedPrice + beansSeedsAmount * beansSeedPrice;

        Console.WriteLine("Total costs: {0:F2}", totalCost);

        int totalArea = tomatoArea + cucumberArea + potatoArea + carrotArea + gabbageArea;

        if (totalArea < 250)
        {
            int beansArea = 250 - totalArea;
            Console.WriteLine("Beans area: {0}", beansArea);
        }
        else if (totalArea == 250)
        {
            Console.WriteLine("No area for beans");
        }
        else if (totalArea > 250)
        {
            Console.WriteLine("Insufficient area");
        }
    }
}

