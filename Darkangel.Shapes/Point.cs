using System;
using System.Collections.Generic;

namespace Darkangel.Shapes
{
    using TOrd = UInt32;

    public class Point: IComparable<Point>, IEquatable<Point>
    {
        public readonly TOrd X;
        public readonly TOrd Y;

        public Point(TOrd x, TOrd y)
        {
            X = x;
            Y = y;
        }

        public int CompareTo(Point other)
        {
            if (other is null) return 1;
            var l1 = (X * X + Y * Y);
            var l2 = (other.X * other.X + other.Y * other.Y);
            return l1.CompareTo(l2);
        }
        public bool Equals(Point other)
        {
            if (other is null) return false;
            return (X == other.X) && (Y == other.Y);
        }
        public static Point operator +(Point point, TOrd val) =>
            new(point.X + val, point.Y + val);
        public static Point operator +(TOrd val, Point point) =>
            new(point.X + val, point.Y + val);
        public static Point operator -(Point point, TOrd val) =>
            new(point.X - val, point.Y - val);
        public static Point operator *(Point point, TOrd val) =>
            new(point.X * val, point.Y * val);
        public static Point operator /(Point point, TOrd val) =>
            new(point.X / val, point.Y / val);

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(Point p1, Point p2)
        {
            return !p1.Equals(p2);
        }
        public static bool operator >=(Point p1, Point p2)
        {
            return p1.CompareTo(p2) >= 0;
        }
        public static bool operator <=(Point p1, Point p2)
        {
            return p1.CompareTo(p2) <= 0;
        }
        public static bool operator >(Point p1, Point p2)
        {
            return p1.CompareTo(p2) > 0;
        }
        public static bool operator <(Point p1, Point p2)
        {
            return p1.CompareTo(p2) < 0;
        }
    }
}
