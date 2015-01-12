using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace Articles
{
    class ArticlesTest
    {
        static void Main()
        {
            Article article1 = new Article("Pesho in action", "Vonko", 200);
            Article article2 = new Article("Bulgarian prostitues", "Vonko", 500.50);
            Article article3 = new Article("Sunny beach - Sodom and Gomore", "Goshko", 350);
            Article article4 = new Article("Social benefits for gipsies", "Sameca", 150.30);
            Article article5 = new Article("The Pernik Golf", "Marto Nazobaniq", 400);

            OrderedSet<Article> articles = new OrderedSet<Article>(
                new Article[] {article1, article2, article3, article4, article5}
                );

            double lowerPrice = 300;
            double higherPrice = 500;

            ICollection<Article> requestedArticles =
                RequestArticles(lowerPrice, higherPrice, articles);

            foreach(Article article in requestedArticles) 
            {
                Console.WriteLine(article);
            }
        }

        private static ICollection<Article> RequestArticles(
            double lowerPrice,double higherPrice,OrderedSet<Article> articles)
        {
            string fakeArtHead = "unknown";

     	    return articles.Range(new Article(fakeArtHead, fakeArtHead, lowerPrice), false,
                new Article(fakeArtHead, fakeArtHead, higherPrice), false);
        }
    }
}
