using System.Drawing;

namespace AutoClicker.Data
{
    public class Click
    {
        public int Milisecond { get; set; }

        public Point CursorPosition { get; set; }

        public MouseType MouseType { get; set; }

        public Click() { }

        public Click(int milisecond, MouseType mouseType, Point cursorPosition)
        {
            Milisecond = milisecond;

            MouseType = mouseType;

            CursorPosition = cursorPosition;
        }
    }
}
