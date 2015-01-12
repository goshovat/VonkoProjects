namespace TimerClass
{
    using System;

    public class EventListener
    {
        private Timer timer;
        private Action<object, EventArgs> methodPassed;

        public EventListener(Timer timer, Action<object, EventArgs> methodPassed)
        {
            this.timer = timer;
            this.methodPassed = methodPassed;
            timer.Tick += new TimerEventHandler(methodPassed);
        }

        public void Detach()
        {
            this.timer.Tick -= new TimerEventHandler(this.methodPassed);
            this.timer = null;
        }
    }
}
