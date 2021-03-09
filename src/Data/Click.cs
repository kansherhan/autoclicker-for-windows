using System.Drawing;

namespace AutoClicker.Data
{
    public class Click
    {
        public int Milisecond { get; set; }

        public Position CursorPosition { get; set; }

        public MouseType MouseType { get; set; }

        public Click(int milisecond, MouseType mouseType, Point cursorPosition)
        {
            Milisecond = milisecond;

            MouseType = mouseType;

            CursorPosition = cursorPosition;
        }
    }
}