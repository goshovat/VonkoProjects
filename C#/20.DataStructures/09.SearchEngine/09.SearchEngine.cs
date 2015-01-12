using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace SearchEngine
{
    class SearchEngine
    {
        static void Main()
        {
            //this method will be hardcode although in real world
            //it can take the information from text files or from the web
            List<Car> allCars = GetCars();

            Dictionary<string, List<Car>> byBrand = ArrangeByBrand(allCars);
            Dictionary<string, List<Car>> byModel = ArrangeByModel(allCars);
            Dictionary<string, List<Car>> byColor = ArrangeByColor(allCars);

            OrderedSet<Car> byYear = new OrderedSet<Car>(allCars, new YearComparer());
            OrderedSet<Car> byPrice = new OrderedSet<Car>(allCars);

            //hardcoded request by brand:BMW, price:from 0 to 10000, color: gray, year:2010-2014
            List<Car> requestedCars = MakeReques(byBrand, byColor, byYear, byPrice);

            Console.WriteLine("The result:");
            foreach(Car car in requestedCars)
                Console.WriteLine(car);
        }

        private static List<Car> GetCars()
        {
            List<Car> allCars = new List<Car>();

            allCars.Add(new Car( "BMW", "X6", "gray", 2014, 200000));
            allCars.Add(new Car("BMW", "6 M6", "gray", 2012, 80000));
            allCars.Add(new Car("Mercedes", "CL", "white", 2013, 100000));
            allCars.Add(new Car("Mercedes", "CLS", "white", 2011, 56000));
            allCars.Add(new Car("Lada", "2104", "yellow", 1987, 650));
            allCars.Add(new Car("VW", "Golf 3 Pernik Edition", "gray", 1993, 3500));

            return allCars;
        }

        private static Dictionary<string, List<Car>> ArrangeByBrand(List<Car> allCars)
        {
            Dictionary<string, List<Car>> byBrand = 
                new Dictionary<string, List<Car>>();

            foreach (Car car in allCars)
            {
                if (!byBrand.ContainsKey(car.Brand))
                {
                    byBrand[car.Brand] = new List<Car>();
                }
                byBrand[car.Brand].Add(car);
            }

            return byBrand;
        }

        private static Dictionary<string, List<Car>> ArrangeByModel(List<Car> allCars)
        {
            Dictionary<string, List<Car>> byModel = 
                new Dictionary<string, List<Car>>();

            foreach (Car car in allCars)
            {
                if (!byModel.ContainsKey(car.Model))
                {
                    byModel[car.Model] = new List<Car>();
                }
                byModel[car.Model].Add(car);
            }

            return byModel;
        }

        private static Dictionary<string, List<Car>> ArrangeByColor(List<Car> allCars)
        {
            Dictionary<string, List<Car>> byColor = 
                new Dictionary<string, List<Car>>();

            foreach (Car car in allCars)
            {
                if (!byColor.ContainsKey(car.Color))
                {
                    byColor[car.Color] = new List<Car>();
                }
                byColor[car.Color].Add(car);
            }

            return byColor;
        }

        //this method will hardcode and immitate request by several properties
        //hardcoded request by brand:BMW, color: gray, year:2010-2014, price:from 0 to 100000, 
        private static List<Car> MakeReques(
            Dictionary<string, List<Car>> byBrand, Dictionary<string, List<Car>> byColor,
            OrderedSet<Car> byYear, OrderedSet<Car> byPrice)
        {
            OrderedSet<Car> brandResult = new OrderedSet<Car>(byBrand["BMW"]);
            OrderedSet<Car> colorResult = new OrderedSet<Car>(byColor["gray"]);

            ICollection<Car> carsYear = byYear.Range(
                new Car("unknown", "unknown", "unknown", 2010, 999), true, 
                new Car("unknown", "unknown", "unknown", 2014, 999), true);
            OrderedSet<Car> yearResult = new OrderedSet<Car>(carsYear);

            ICollection<Car> carsPrice = byPrice.Range(
                     new Car("unknown", "unknown", "unknown", 0, 0), true, 
                     new Car("unknown", "unknown", "unknown", 3000, 100000), true);
            OrderedSet<Car> priceResult = new OrderedSet<Car>(carsPrice);

            OrderedSet<Car> result = new OrderedSet<Car>(brandResult);
            result.IntersectionWith(colorResult);
            result.IntersectionWith(yearResult);
            result.IntersectionWith(priceResult);

            return new List<Car>(result);
        }
    }
}
