using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCommanders.Math2
{
    /// <summary>
    /// Describes a 2D point. int-based version of Vector2
    /// </summary>
    public struct Point2
    {
        public int X;
        public int Y;

        public Point2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point2(Point2 other) : this(other.X, other.Y)
        {
        }

        public static Point2 operator +(Point2 p1, Point2 p2)
        {
            return new Point2(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point2 operator -(Point2 p1, Point2 p2)
        {
            return new Point2(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static Point2 operator -(Point2 p)
        {
            return new Point2(-p.X, -p.Y);
        }

        public static bool operator ==(Point2 p1, Point2 p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=(Point2 p1, Point2 p2)
        {
            return p1.X != p2.X || p1.Y != p2.Y;
        }

        public static implicit operator Vector2(Point2 p)
        {
            return new Vector2(p.X, p.Y);
        }

        public static int DotProduct(Point2 p1, Point2 p2)
        {
            return p1.X * p2.X + p1.Y * p2.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;

            if (obj.GetType() != typeof(Point2))
                return false;

            var p2 = (Point2)obj;

            return this == p2;
        }

        public override int GetHashCode()
        {
            int res = 31;

            res = res * 17 + X;
            res = res * 17 + Y;

            return res;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
