using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricShapes
{
    class Circle: Shape
    {
        public Circle(double radius)
        {
            base.width = radius;
            base.height = radius;
        }

        public double Radius 
        {
            get 
            { 
                return base.width; 
            }
            set
            {
                base.width = value;
                base.height = value;
            }
        }

        public override double CalculateSurface()
        {
            return Math.PI * base.width * base.width;
        }
    }
}
