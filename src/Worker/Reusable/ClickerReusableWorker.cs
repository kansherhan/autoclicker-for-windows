using AutoClicker.Data;
using System.Linq;

namespace AutoClicker.Worker.Reusable
{
    public class ClickerReusableWorker : WorkerBase
    {
        private int iterationIndex;
        private int clickIndex;

        private readonly int iteration;
        private readonly int maxInterval;

        private readonly ClickList data;

        public ClickerReusableWorker(ClickList data, int iteration, int increment)
            : base(WorkerType.Clicker, increment)
        {
            this.iteration = iteration;

            iterationIndex = 0;
            clickIndex = 0;

            var clicks = data.Clicks.OrderBy(c => c.Interval).ToArray();
            maxInterval = clicks.Max(c => c.Interval);

            this.data = new ClickList(clicks);
        }

        public override void Work()
        {
            if (IsFinish)
            {
                if (data.Clicks.Count > 0 && iterationIndex < iteration)
                {
                    if (maxInterval >= Tick)
                    {
                        var click = data[clickIndex];

                        if (click.Interval <= Tick)
                        {
                            clickIndex += 1;

                            Mouse.Click(click.MouseType, click.Cursor);
                        }
                    }
                    else
                    {
                        iterationIndex += 1;
                    }
                }
                else Stop();
            }
        }
    }
}