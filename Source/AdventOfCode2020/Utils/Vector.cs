namespace AdventOfCode2020.Utils
{
    public class Vector
    {
        public int X { get; }

        public int Y { get; }

        public int Z { get; }

        public int W { get; }

        public Vector(int x, int y, int z = 0, int w = 0)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X+b.X, a.Y+b.Y, a.Z+b.Z, a.W + b.W);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
        }

        public static Vector operator *(Vector vector, int scalar)
        {
            return new Vector(vector.X * scalar, vector.Y * scalar, vector.Z * scalar, vector.W * scalar);
        }

        public override string ToString()
        {
            return $"({X},{Y},{Z},{W})";
        }

        public override bool Equals(object obj)
        {
            var other = (Vector)obj;

            if (other == null)
            {
                return false;
            }

            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z) && W.Equals(other.W);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode() + W.GetHashCode();
        }

        public static Vector North => new Vector(0, 1);
        public static Vector South => new Vector(0, -1);
        public static Vector West => new Vector(-1, 0);
        public static Vector East => new Vector(1, 0);
        public static Vector Up => new Vector(0, 0, 1);
        public static Vector Down => new Vector(0, 0, -1);
        public static Vector HyperNorth => new Vector(0, 0, 0, 1);
        public static Vector HyperSouth => new Vector(0, 0, 0, -1);
    }
}
