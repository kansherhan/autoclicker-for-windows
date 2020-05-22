namespace AutoCliker
{
    public class ClickData
    {
        public int Tick;

        public CursorPosition CursorPosition;

        public Mouse Mouse;

        public ClickData(int tick, Mouse mouse, CursorPosition cursorPosition)
        {
            Tick = tick;
            Mouse = mouse;
            CursorPosition = cursorPosition;
        }
    }
}
