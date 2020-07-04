using AutoClicker.Data.Mouse;

namespace AutoClicker.Data.Click
{
    public class ClickData
    {
        public int Milisecond { get; set; }

        public CursorPosition CursorPosition { get; set; }

        public EMouse EMouse { get; set; }

        public ClickData() { }

        public ClickData(CursorPosition cursorPosition, EMouse mouse)
        {
            EMouse = mouse;

            CursorPosition = cursorPosition;
        }

        public ClickData(int interval, EMouse mouse, CursorPosition cursorPosition)
        {
            Milisecond = interval;

            EMouse = mouse;

            CursorPosition = cursorPosition;
        }
    }
}