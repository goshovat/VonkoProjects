namespace Point3D
{
    using System;
    using System.IO;
    using System.Linq;

    public static class PathStorage
    {
        public static void SavePath(Path path, string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);

            using (writer)
            {
                foreach (Point3D point in path)
                {
                    string line = string.Format("{0}, {1}, {2}", 
                        point.X, point.Y, point.Z);
                    writer.WriteLine(line);
                }
            }
        }

        public static Path LoadPath(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);

            Path path = new Path();
            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    double[] coordinates = 
                        Array.ConvertAll(line.Split(','), s => double.Parse(s));
                    Point3D currentPoint = new Point3D(coordinates[0], coordinates[1], coordinates[2]);
                    path.AddPoint(currentPoint);

                    line = reader.ReadLine(); //everytime forget this and go in infinite loop :)
                }
                return path;
            }
        }
    }
}
