using System;


namespace Helper
{
    public class Coordinate : IComparable<Coordinate>
    {

        private int x;
        private int y;


        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }


        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }


        public int CompareTo(Coordinate other)
        {
            return Math.Sign(Math.Sqrt(X * X + Y * Y) - Math.Sqrt(other.X * other.X + other.Y * other.Y));
        }

        public override string ToString()
        {
            return $"[{X}, {Y}]";
        }

    }

}
