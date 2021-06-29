using AutoClicker.Data;
using AutoClicker.Utils.Extensions;
using System.Drawing;
using System.Windows.Forms;

namespace AutoClicker.Worker.Quete
{
    public class ClickerQueteWorker : WorkerBase
    {
        private Click selectClick;
        private ClickList data;

        public ClickerQueteWorker(ClickList data, int increment) : base(WorkerType.Clicker, increment)
        {
            selectClick = data.Clicks.Pop();

            this.data = data;
        }

        public override void Work()
        {
            if (IsFinish == false)
            {
                if (data.Clicks.Count > 0)
                {
                    if (selectClick.Interval <= Tick)
                    {
                        Cursor.Position = (Point)selectClick.Cursor;
                        Mouse.Click(selectClick.MouseType, selectClick.Cursor);

                        selectClick = data.Clicks.Pop();
                    }

                    base.Work();
                }
                else Stop();
            }
        }
    }
}