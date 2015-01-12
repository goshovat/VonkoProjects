using System;
using System.Collections.Generic;

namespace GeometricShapes
{
    class Triangle:Shape
    {
        public Triangle(double width, double height)
        {
            base.width = width;
            base.height = height;
        }

        public double Width
        {
            get { return base.width; }
            set { base.width = value; }
        }

        public double Height
        {
            get { return base.height; }
            set { base.height = value; }
        }

        public override double CalculateSurface()
        {
            return base.width * base.height / 2;
        }
    }
}
