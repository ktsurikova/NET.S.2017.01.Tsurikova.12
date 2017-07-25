using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsTests
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x; Y = y;
        }
    }

    public class PointXComparer : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            if (ReferenceEquals(x, null)) throw new ArgumentNullException($"{nameof(x)} is null");
            if (ReferenceEquals(y, null)) throw new ArgumentNullException($"{nameof(y)} is null");
            return x.X - y.X;
        }
    }
}
