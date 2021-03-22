namespace AdventOfCode2020.Utils
{
    using System;

    public class Coordinate : IComparable
    {
        public int X { get; }

        public int Y { get; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

        public override bool Equals(object obj)
        {
            if (obj is Coordinate otherCoordinate)
            {
                return otherCoordinate.X.Equals(X) && otherCoordinate.Y.Equals(Y);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            if (obj is Coordinate other)
            {
                if (other.Equals(this))
                {
                    return 0;
                }
            }

            return -1;
        }

        public static int ManhattanDistance(Coordinate origin, Coordinate destination)
        {
            if (origin.Equals(destination))
            {
                return 0;
            }

            return Math.Abs(destination.X - origin.X) + Math.Abs(destination.Y - origin.Y);
        }

        public static Coordinate Zero => new Coordinate(0, 0);

        public static Coordinate operator +(Coordinate a, Vector b)
        {
            return new Coordinate(a.X + b.X, a.Y + b.Y);
        }
    }
}
