using AutoClicker.Data.Click;
using System.Drawing;
using System.Windows.Forms;

namespace AutoClicker.States
{
    public class WorkingState : AState
    {
        public WorkingState(Datas Data) : base()
        {
            this.Data = Data;
            this.EState = EState.Working;
        }

        public override void Work()
        {
            if (IsFinish == true) return;

            if (Data.ClickDatas.Count <= 0)
            {
                this.OnFinish();
                return;
            }

            var click = Data.GetClickData();

            if (click.Milisecond >= Interval)
            {
                Cursor.Position = (Point)click.CursorPosition;
                Clicker.MouseClicked(click.EMouse, click.CursorPosition);
            }

            base.Work();
        }
    }
}