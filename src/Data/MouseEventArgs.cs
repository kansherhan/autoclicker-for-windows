using System;

namespace AutoClicker.Data
{
    public class MouseEventArgs : EventArgs
    {
        public MouseType MouseType { get; }

        public MouseEventArgs(MouseType type)
        {
            MouseType = type;
        }
    }
}
