using System;
using System.Collections.Generic;

namespace SearchEngine
{
    class Car : IComparable<Car>
    {
        private string brand;
        private string model;
        private string color;
        private int year;
        private double price;

        public Car(string brand, string model, string color,
            int year, double price)
        {
            this.brand = brand;
            this.model = model;
            this.color = color;
            this.year = year;
            this.price = price;
        }

        public string Brand
        {
            get { return this.brand; }
        }

        public string Model
        {
            get { return this.model; }
        }

        public string Color
        {
            get { return this.color; }
        }

        public int Year
        {
            get { return this.year; }
        }

        public double Price
        {
            get { return this.price; }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}",
                this.brand, this.model, this.color, this.year, this.price);
        }

        public int CompareTo(Car other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}
