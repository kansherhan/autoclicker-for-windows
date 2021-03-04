using AutoClicker.Data;
using AutoClickerMouseEventArgs = AutoClicker.Data.MouseEventArgs;
using System.Windows.Forms;

namespace AutoClicker.Worker
{
    public class RecorderWorker : AbstractWorker
    {
        private ClickData data;
        private Mouse mouse;

        public RecorderWorker(int intervalIncrement) : base(intervalIncrement)
        {
            WorkerType = WorkerType.Recorder;

            data = new ClickData();
            mouse = new Mouse();

            mouse.MouseChanged += OnMouseChanged;
        }

        private void OnMouseChanged(object sender, AutoClickerMouseEventArgs e)
        {
            if (e.MouseType != MouseType.None)
            {
                data.AddData(Interval, e.MouseType, Cursor.Position);
            }
        }

        public override void Work()
        {
            if (IsFinish == false)
            {
                mouse.UpdateData();

                base.Work();
            }
        }

        public override void Finish()
        {
            data.Save();

            base.Finish();
        }
    }
}