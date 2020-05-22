using System.Runtime.InteropServices;

namespace AutoCliker
{
    public static class Clicker
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Mouse mouse);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dsFlags, int dx, int dy, int cButtons, int dsExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;

        public static Mouse IsMouseDown()
        {
            if (GetAsyncKeyState(Mouse.LeftMouse) != 0)
            {
                return Mouse.LeftMouse;
            }
            else if (GetAsyncKeyState(Mouse.RightMouse) != 0)
            {
                return Mouse.RightMouse;
            }
            else
            {
                return Mouse.None;
            }
        }

        public static void MouseCliked(Mouse mouse, CursorPosition position)
        {
            switch (mouse)
            {
                case Mouse.LeftMouse:
                    mouse_event(MOUSEEVENTF_LEFTDOWN, position.X, position.Y, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, position.X, position.Y, 0, 0);
                    break;

                case Mouse.RightMouse:
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, position.X, position.Y, 0, 0);
                    mouse_event(MOUSEEVENTF_RIGHTUP, position.X, position.Y, 0, 0);
                    break;
            }
            
        }
    }
}
