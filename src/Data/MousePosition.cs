using System.Drawing;

namespace AutoClicker.Data
{
    public class MousePosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public MousePosition()
        {
            X = 0;
            Y = 0;
        }

        public MousePosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static explicit operator Point(MousePosition position)
        {
            return new Point(position.X, position.Y);
        }

        public static implicit operator MousePosition(Point point)
        {
            return new MousePosition(point.X, point.Y);
        }
    }
}
