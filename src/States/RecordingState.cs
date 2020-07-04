using AutoClicker.Data.Click;
using AutoClicker.Data.Mouse;
using System.Windows.Forms;

namespace AutoClicker.States
{
    public class RecordingState : AState
    {
        public RecordingState() : base()
        {
            this.Data = new Datas();
            this.EState = EState.Recording;
        }

        public override void Work()
        {
            if (IsFinish == true) return;

            var mouse = Clicker.IsMouseDown();

            if (mouse != EMouse.None)
            {
                Data.AddData(Interval, mouse, Cursor.Position);
            }

            base.Work();
        }

        public override void OnFinish()
        {
            Data.Save();

            base.OnFinish();
        }
    }
}