namespace Shapes
{
    using System;

    public class Triangle : Shape
    {
        public Triangle(double baseWidth, double height)
            :base(baseWidth, height) { }

        public override double CalclulateSurface()
        {
            return base.Width * base.Height / 2;
        }

        public override string ToString()
        {
            return string.Format("Triangle: width {0}, height {1}", base.Width, base.Height);
        }
    }
}
