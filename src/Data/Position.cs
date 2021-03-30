using System.Drawing;

namespace AutoClicker.Data
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position()
        {
            X = 0;
            Y = 0;
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static explicit operator Point(Position position) => new Point(position.X, position.Y);

        public static implicit operator Position(Point point) => new Position(point.X, point.Y);

        public static Position operator +(Position p1, Position p2) => new Position(p1.X + p2.X, p1.Y + p2.Y);

        public static Position operator -(Position p1, Position p2) => new Position(p1.X - p2.X, p1.Y - p2.Y);

        public static bool operator ==(Position p1, Position p2) => p1.X == p2.X && p1.Y == p2.Y;

        public static bool operator !=(Position p1, Position p2) => !(p1 == p2);
    }
}
