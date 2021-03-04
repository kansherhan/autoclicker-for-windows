using AutoClicker.Data;
using AutoClickerMouse = AutoClicker.Data.Mouse;
using System.Windows.Forms;
using System.Drawing;

namespace AutoClicker.Worker
{
    public class ClickerWorker : AbstractWorker
    {
        private Click selectClick;

        private ClickData data;

        public ClickerWorker(ClickData data, int intervalIncrement) : base(intervalIncrement)
        {
            WorkerType = WorkerType.Clicker;

            selectClick = data.GetClickAndRemoveHim();
            this.data = data;
        }

        public override void Work()
        {
            if (IsFinish == false)
            {
                if (data.Clicks.Count > 0)
                {
                    if (selectClick.Milisecond <= Interval)
                    {
                        var position = (Point)selectClick.CursorPosition;

                        Cursor.Position = position;
                        AutoClickerMouse.Click(selectClick.MouseType, position);

                        selectClick = data.GetClickAndRemoveHim();
                    }

                    base.Work();
                }
                else
                {
                    Finish();
                }
            }
        }
    }
}