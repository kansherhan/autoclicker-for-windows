using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace AutoClicker.Data
{
    public class Mouse
    {
        private static readonly Dictionary<MouseType, MouseData> mouses = new Dictionary<MouseType, MouseData>()
        {
            {
                MouseType.LeftMouse,
                new MouseData(MouseType.LeftMouse, 0x02, 0x04)
            },
            {
                MouseType.RightMouse,
                new MouseData(MouseType.RightMouse, 0x08, 0x10)
            }
        };

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(MouseType mouse);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dsFlags, int dx, int dy, int cButtons, int dsExtraInfo);

        public MouseType MouseState { get; private set; }

        public Action<MouseType> OnMouseChanged;

        public Mouse()
        {
            MouseState = MouseType.None;
        }

        public void UpdateData()
        {
            var mouseType = KnowMouseDown();

            if (MouseState != mouseType)
            {
                MouseState = mouseType;
                OnMouseChanged?.Invoke(mouseType);
            }
        }

        public static bool GetMouseState(MouseType mouse)
        {
            return GetAsyncKeyState(mouse) != 0;
        }

        public static MouseType KnowMouseDown()
        {
            if (GetMouseState(MouseType.LeftMouse)) return MouseType.LeftMouse;
            else if (GetMouseState(MouseType.RightMouse)) return MouseType.RightMouse;
            else return MouseType.None;
        }

        public static void Click(MouseType mouseType, Point position)
        {
            if (mouseType != MouseType.None)
            {
                var mouse = mouses[mouseType];

                if (mouse.MouseType != MouseType.None)
                {
                    mouse_event(mouse.DownCode, position.X, position.Y, 0, 0);
                    mouse_event(mouse.UpCode, position.X, position.Y, 0, 0);
                }
            }
        }
    }
}
