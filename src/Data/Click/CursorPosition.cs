using System.Drawing;

namespace AutoClicker.Data.Click
{
    public class CursorPosition
    {
        public int X;
        public int Y;

        public CursorPosition()
        {
            X = 0;
            Y = 0;
        }

        public CursorPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            var position = obj as CursorPosition;
            return position != null &&
                   X == position.X &&
                   Y == position.Y;
        }

        public static bool operator ==(CursorPosition left, CursorPosition right)
        {
            return (left.X == right.X && left.Y == right.Y) ? true : false;
        }

        public static bool operator !=(CursorPosition left, CursorPosition right)
        {
            return (left == right) ? true : false;
        }

        public static implicit operator CursorPosition(Point point)
        {
            return new CursorPosition(point.X, point.Y);
        }

        public static explicit operator Point(CursorPosition position)
        {
            return new Point(position.X, position.Y);
        }
    }
}