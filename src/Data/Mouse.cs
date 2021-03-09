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

        public MouseType MouseType { get; private set; }

        public event EventHandler<MouseEventArgs> MouseChanged;

        public Mouse()
        {
            MouseType = MouseType.None;
        }

        public void UpdateData()
        {
            var type = KnowMouseDown();

            if (MouseType != type)
            {
                MouseType = type;

                var args = new MouseEventArgs(MouseType);

                MouseChanged?.Invoke(this, args);
            }
        }

        public static bool GetAsyncMouseState(MouseType type)
        {
            return GetAsyncKeyState(type) != 0;
        }

        public static MouseType KnowMouseDown()
        {
            if (GetAsyncMouseState(MouseType.LeftMouse)) return MouseType.LeftMouse;
            else if (GetAsyncMouseState(MouseType.RightMouse)) return MouseType.RightMouse;
            else return MouseType.None;
        }

        public static void Click(MouseType type, Point position)
        {
            if (type != MouseType.None)
            {
                var mouse = mouses[type];

                mouse_event(mouse.DownFlag, position.X, position.Y, 0, 0);
                mouse_event(mouse.UpFlags, position.X, position.Y, 0, 0);
            }
        }
    }
}
