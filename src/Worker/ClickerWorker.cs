using AutoClicker.Data;
using AutoClickerMouse = AutoClicker.Data.Mouse;
using System.Windows.Forms;

namespace AutoClicker.Worker
{
    public class ClickerWorker : AbstractWorker
    {
        private Click selectClick;

        private ClickData data;

        public ClickerWorker(ClickData data, int intervalIncrement) : base(intervalIncrement)
        {
            WorkerType = WorkerType.Clicker;

            selectClick = data.Pop();
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
                        Cursor.Position = selectClick.CursorPosition;
                        AutoClickerMouse.Click(selectClick.MouseType, selectClick.CursorPosition);

                        selectClick = data.Pop();
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