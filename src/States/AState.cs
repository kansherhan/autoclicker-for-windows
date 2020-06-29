using AutoClicker.Data.Click;

namespace AutoClicker.States
{
    public abstract class AState
    {
        public int Interval { get; set; }

        public bool IsFinish { get; private set; }

        public Datas Data { get; set; }

        public EState EState { get; set; }

        public AState()
        {
            this.Interval = 0;
            this.IsFinish = false;
        }

        public virtual void Work()
        {
            Interval++;
        }

        public virtual void OnFinish()
        {
            this.IsFinish = true;
        }
    }
}