using System;

namespace Point3D
{
    using System;
    using System.IO;

    public static class Point3DMain
    {
        static void Main()
        {
            Point3D point1 = new Point3D(3, 4, 5);
            Point3D point2 = new Point3D(2, 1, 9);
            Point3D point3 = new Point3D(5, -787, 9);
            Point3D point4 = new Point3D(-2, -1.4, -99);

            //test distance calculator
            double distance = Distance3DCalculator.CalculateDistance(point1, point2);
            Console.WriteLine("{0:N2}", distance);

            //test the methods of path
            Path path = new Path();
            path.AddPoint(point1);
            path.AddPoint(point2);
            path.AddPoint(point3);
            path.AddPoint(point4);
            path.RemovePoint(point1);

            try
            {
                PathStorage.SavePath(path, "path.txt");
                Path samePath = PathStorage.LoadPath("path.txt");
            }
            catch (IOException ioExc)
            {
                Console.WriteLine( ioExc.Message);
            }
        }
    }
}
