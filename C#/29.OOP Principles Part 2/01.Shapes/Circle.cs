namespace Shapes
{
    using System;

    public class Circle : Shape
    {
        public Circle(double radius)
            : base(radius, radius) { }

        public override double CalclulateSurface()
        {
            return Math.PI * base.Width * base.Height;
        }

        public override string ToString()
        {
            return string.Format("Triangle: width {0}, height {1}", base.Width, base.Height);
        }
    }
}
