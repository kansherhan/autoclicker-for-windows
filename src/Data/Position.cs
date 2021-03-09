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

        public static explicit operator Point(Position position)
        {
            return new Point(position.X, position.Y);
        }

        public static implicit operator Position(Point point)
        {
            return new Position(point.X, point.Y);
        }
    }
}
