using AutoClicker.Data.Click;
using AutoClicker.Data.Mouse;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AutoClicker
{
    public static class Clicker
    {
        public static Dictionary<EMouse, Mouse> Mouses;

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(EMouse mouse);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dsFlags, int dx, int dy, int cButtons, int dsExtraInfo);

        static Clicker()
        {
            Mouses = new Dictionary<EMouse, Mouse>()
            {
                {
                    EMouse.LeftMouse,
                    new Mouse(EMouse.LeftMouse, 0x02, 0x04)
                },
                {
                    EMouse.RightMouse,
                    new Mouse(EMouse.RightMouse, 0x08, 0x10)
                }
            };
        }

        public static bool GetAsyncMouseState(EMouse mouse)
        {
            return GetAsyncKeyState(mouse) != 0;
        }

        public static EMouse IsMouseDown()
        {
            if (GetAsyncMouseState(EMouse.LeftMouse)) return EMouse.LeftMouse;
            else if (GetAsyncMouseState(EMouse.RightMouse)) return EMouse.RightMouse;
            else return EMouse.None;
        }

        public static void MouseClicked(EMouse eMouse, CursorPosition position)
        {
            var mouse = Mouses[eMouse];

            mouse_event(mouse.MouseDownCode, position.X, position.Y, 0, 0);
            mouse_event(mouse.MouseUpCode, position.X, position.Y, 0, 0);
        }
    }
}
