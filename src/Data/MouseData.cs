namespace AutoClicker.Data
{
    public class MouseData
    {
        public MouseType MouseType { get; private set; }

        public int DownCode { get; private set; }
        public int UpCode { get; private set; }

        public MouseData(MouseType eMouse, int downCode, int upCode)
        {
            MouseType = eMouse;

            DownCode = downCode;
            UpCode = upCode;
        }
    }
}
