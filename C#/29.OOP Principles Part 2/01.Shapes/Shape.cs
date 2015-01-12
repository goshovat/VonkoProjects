namespace Shapes
{
    using System;

    public abstract class Shape
    {
        protected Shape(double width, double height)
        {
            if (width < 0)
                throw new ArgumentException("The width must be positive.");

            if (height < 0)
                throw new ArgumentException("The height must be positive.");

            this.Width = width;
            this.Height = height;
        }

        public double Width { get; private set; }
        public double Height { get; private set; }

        public abstract double CalclulateSurface();
    }
}
