using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    public class Car :IComparable<Car>
    {
        private string brand;
        private string model;
        private double price;

        public Car(string brand, string model, int price)
        {
            this.brand = brand;
            this.model = model;
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

        public double Price
        {
            get { return this.price; }
        }

        public int CompareTo(Car other)
        {
            return this.price.CompareTo(other.price);
        }

        public override string ToString()
        {
            return this.brand + " " + this.model + " " + this.price + "лв.";
        }
    }
}
