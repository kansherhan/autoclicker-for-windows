namespace AutoClicker.Data
{
    public class Click
    {
        public int Interval { get; set; }

        public Position Cursor { get; set; }

        public MouseType MouseType { get; set; }

        public Click(int interval, MouseType type, Position cursor)
        {
            Interval = interval;

            MouseType = type;

            Cursor = cursor;
        }

        public override bool Equals(object obj)
        {
            if (obj is Click click)
            {
                var pos = Cursor == click.Cursor;
                var type = MouseType == click.MouseType;
                var second = Interval == click.Interval;

                return pos && type && second;
            }
            else return base.Equals(obj);
        }
    }
}
