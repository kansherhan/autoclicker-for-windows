using System.Drawing;

namespace AutoClicker.Utils
{
    public static class Colors
    {
        public static readonly Color Gray = Color.FromArgb(47, 55, 63);
        public static readonly Color DarkGray = Color.FromArgb(32, 42, 47);
        public static readonly Color Dark = Color.FromArgb(12, 22, 27);
        public static readonly Color BlueLight = Color.FromArgb(5, 157, 232);

        public static Color ChangedColor(Color color, float response)
        {
            return Color.White;
        }
    }
}
