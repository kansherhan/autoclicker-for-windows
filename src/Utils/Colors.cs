using System.Drawing;

namespace AutoClicker.Utils
{
    public static class Colors
    {
        public static readonly Color Gray = Color.FromArgb(47, 55, 63);
        public static readonly Color DarkGray = Color.FromArgb(32, 42, 47);
        public static readonly Color Dark = Color.FromArgb(12, 22, 27);
        public static readonly Color BlueLight = Color.FromArgb(5, 157, 232);

        public static Color ChangeColorBrightness(Color color, float correctionFactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            return Color.FromArgb(color.A, ((byte)red), ((byte)green), ((byte)blue));
        }
    }
}
