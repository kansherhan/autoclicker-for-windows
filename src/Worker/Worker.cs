using System;

namespace AutoClicker.Worker
{
    public abstract class AbstractWorker
    {
        private bool isFinish;
        public bool IsFinish
        {
            get => isFinish;
            protected set
            {
                if (value == true)
                {
                    Finished?.Invoke(this, new EventArgs());
                }

                isFinish = value;
            }
        }

        public int Interval { get; private set; }
        public int IntervalIncrement { get; private set; }

        public WorkerType WorkerType { get; protected set; }

        public event EventHandler Finished;

        protected AbstractWorker(int intervalIncrement)
        {
            IsFinish = false;

            Interval = 0;

            IntervalIncrement = intervalIncrement;
        }

        public virtual void Work()
        {
            Interval += IntervalIncrement;
        }

        public virtual void Finish()
        {
            IsFinish = true;
        }
    }
}
