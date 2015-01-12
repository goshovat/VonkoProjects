using System;
using System.Collections.Generic;

namespace Articles
{
    class Article : IComparable<Article>
    {
        private string name;
        private string manufacturer;
        private ulong barcode;
        private double price;

        public Article(string name, string manufacturer, double price)
        {
            this.name = name;
            this.manufacturer = manufacturer;
            this.price = price;

            int code1 = this.name.GetHashCode();
            int code2 = this.manufacturer.GetHashCode();
            this.barcode = (ulong)(code1 + code2);
        }

        public string Name
        {
            get { return this.name; }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
        }

        public double Price
        {
            get { return this.price; }
        }

        public ulong Barcode
        {
            get { return this.barcode; }
        }

        public int CompareTo(Article other)
        {
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return this.Name + " " + this.Manufacturer + " " + this.Price + "lv. " 
                + "ID:" + this.Barcode;
        }
    }
}
