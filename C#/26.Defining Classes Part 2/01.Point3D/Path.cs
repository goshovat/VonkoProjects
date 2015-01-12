namespace Point3D
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Path : IEnumerable<Point3D>
    {
        private List<Point3D> path;

        public Path()
        {
            this.path = new List<Point3D>();
        }

        public void AddPoint(Point3D point)
        {
            this.path.Add(point);
        }

        public bool RemovePoint(Point3D point)
        {
            for (int i = 0; i < this.path.Count; i++)
            {
                if (this.path[i].Equals(point))
                {
                    path.Remove(path[i]);
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<Point3D> GetEnumerator()
        {
            return this.path.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
