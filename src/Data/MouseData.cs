namespace AutoClicker.Data
{
    public class MouseData
    {
        public MouseType MouseType { get; }

        public int DownFlag { get; }
        public int UpFlag { get; }

        public MouseData(MouseType type, int down, int up)
        {
            MouseType = type;

            DownFlag = down;
            UpFlag = up;
        }
    }
}
