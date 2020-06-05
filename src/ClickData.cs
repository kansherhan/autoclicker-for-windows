namespace AutoClicker
{
    public class ClickData
    {
        public int Milisecond { get; set; }

        public CursorPosition CursorPosition { get; set; }

        public Mouse Mouse { get; set; }

        public ClickData(CursorPosition cursorPosition, Mouse mouse)
        {
            Mouse = mouse;

            CursorPosition = cursorPosition;
        }

        public ClickData(int tick, Mouse mouse, CursorPosition cursorPosition)
        {
            Milisecond = tick;

            Mouse = mouse;

            CursorPosition = cursorPosition;
        }
    }
}
