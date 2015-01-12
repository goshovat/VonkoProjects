using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricShapes
{
    public abstract class Shape
    {
        protected double width;
        protected double height;

        public abstract double CalculateSurface();
    }
}
