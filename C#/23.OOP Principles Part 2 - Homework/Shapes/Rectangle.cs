namespace Shapes
{
    using System;

    public class Rectangle : Shape
    {
        public Rectangle(double baseWidth, double height)
            : base(baseWidth, height) { }

        public override double CalclulateSurface()
        {
            return base.Width * base.Height;
        }

        public override string ToString()
        {
            return string.Format("Rectangle: width {0}, height {1}", base.Width, base.Height);
        }
    }
}
