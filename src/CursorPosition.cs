using System.Drawing;

namespace AutoClicker
{
    public class CursorPosition
    {
        public int X;
        public int Y;

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

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
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
