namespace TimerClass
{
    using System;
    using System.Threading;

    public delegate void TimerEventHandler(object sender, EventArgs e);

    public class Timer
    {
        private int seconds;
        private int numberExecutions;
        public event TimerEventHandler Tick;

        public Timer(int seconds, int numberExecutions)
        {
            if (seconds < 0)
                throw new ArgumentException("The seconds must be positive.");

            if (numberExecutions < 0)
                throw new ArgumentException("The number of executions must be positive.");

            this.seconds = seconds;
            this.numberExecutions = numberExecutions;
        }

        public int Counter { get; private set; }

        protected virtual void Trigger(EventArgs e)
        {
            if (this.Tick != null)
            {
                Thread.Sleep(3000);

                while (true)
                {
                    Tick(this, e);
                    this.Counter++;
                    if (this.Counter == this.numberExecutions)
                        break;

                    Thread.Sleep(3000);
                }
            }
        }

        public void StartTimer()
        {
            this.Trigger(null);
        }
    }
}
