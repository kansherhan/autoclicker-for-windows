using AutoClicker.Data;
using AutoClicker.Utils;
using System;
using System.Windows.Forms;

namespace AutoClicker.Worker.Quete
{
    public class RecorderQueteWorker : WorkerBase
    {
        private ClickList data;
        private Mouse mouse;

        public RecorderQueteWorker(int increment) : base(WorkerType.Recorder, increment)
        {
            data = new ClickList();
            mouse = new Mouse();

            mouse.MouseChanged += Mouse_MouseChanged;
        }

        private void Mouse_MouseChanged(object sender, Mouse.MouseEventArgs e)
        {
            if (e.MouseType != MouseType.None)
            {
                var click = new Click(Tick, e.MouseType, Cursor.Position);

                data.Clicks.Add(click);
            }
        }

        public override void Work()
        {
            if (IsFinish == false)
            {
                mouse.UpdateMouseState();

                base.Work();
            }
        }

        public override void Stop()
        {
            var now = DateTime.Now.ToString(IOFile.DateTimeFormat);

            var filename = string.Format("{0}/{1}.json", IOFile.QueueSaveFolder, now);

            data.Save(filename);

            base.Stop();
        }
    }
}
