namespace MobilePhone
{
    using System;

    public class Display
    {
        private double size;
        private int colors;
   
        public Display(double size, int colors)
        {
            this.Size = size;
            this.Colors = colors;
        }
        public Display() : this(3, 1) { }

        public double Size
        {
            get { return this.size; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Error! Display size must be positive");
                this.size = value;
            }
        }
        public int Colors
        {
            get { return this.colors; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Error! Display number of colors must be positive");

                this.colors = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} inches, {1} colors",
                this.Size, this.Colors);
        }
    }
}
