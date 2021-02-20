using AutoClicker.Data;
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

            mouse.OnMouseChanged += OnMouseChanged;
        }

        private void OnMouseChanged(MouseType mouseType)
        {
            data.AddData(Interval, mouseType, Cursor.Position);
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