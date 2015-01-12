namespace Shapes
{
    using System;

    class ShapesMain
    {
        static void Main()
        {
            Shape[] shapes = new Shape[] 
            {
                new Triangle(3, 4),
                new Rectangle(5, 2),
                new Circle(4)
            };

            foreach(Shape shape in shapes)
                Console.WriteLine("{0}, surface: {1:N2}", shape.GetType().Name, shape.CalclulateSurface());
        }
    }
}
