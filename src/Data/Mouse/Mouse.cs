namespace AutoClicker.Data.Mouse
{
    public class Mouse
    {
        public EMouse EMouse { get; set; }

        public int MouseDownCode { get; private set; }
        public int MouseUpCode { get; private set; }

        public Mouse(EMouse eMouse, int mouseDownCode, int mouseUpCode)
        {
            EMouse = eMouse;
            MouseDownCode = mouseDownCode;
            MouseUpCode = mouseUpCode;
        }

        public override bool Equals(object obj)
        {
            var mouse = obj as Mouse;
            return mouse != null &&
                   EMouse == mouse.EMouse;
        }
    }
}