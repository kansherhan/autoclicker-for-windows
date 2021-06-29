using System;

namespace AutoClicker.Worker
{
    public abstract class WorkerBase
    {
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

        public int Tick { get; protected set; }
        public int TickIncrement { get; protected set; }

        public WorkerType WorkerType { get; }

        private bool isFinish;

        public event EventHandler Finished;

        protected WorkerBase(WorkerType type, int increment)
        {
            WorkerType = type;

            IsFinish = false;

            Tick = 0;

            TickIncrement = increment;
        }

        public virtual void Work() => Tick += TickIncrement;

        public virtual void Stop() => IsFinish = true;
    }

    public enum WorkerType
    {
        Clicker,
        Recorder
    }
}