using System;
using System.Collections.Generic;

namespace GeometricShapes
{
    class GeometricShapesTest
    {
        static void Main()
        {
            Triangle triangle = new Triangle(4, 5);
            Rectangle rectangle = new Rectangle(10, 8);
            Circle circle = new Circle(7);

            List<Shape> shapes = CreateShapes(triangle, rectangle, circle);

            List<double> areas = CalculateAreas(shapes);

            PrintArease(areas);
        }

        private static List<Shape> CreateShapes(Triangle triangle, Rectangle rectangle, Circle circle)
        {
            List<Shape> shapes = new List<Shape>();
            shapes.Add(triangle);
            shapes.Add(rectangle);
            shapes.Add(circle);

            return shapes;
        }

        private static List<double> CalculateAreas(List<Shape> shapes)
        {
            List<double> areas = new List<double>();

            foreach (Shape shape in shapes)
            {
                areas.Add(shape.CalculateSurface());
            }

            return areas;
        }

        private static void PrintArease(List<double> areas)
        {
            for (int i = 0; i < areas.Count; i++)
            {
                Console.WriteLine("The are of figure {0} is: {1:N2}", i + 1, areas[i]);
            }
        }

    }
}
