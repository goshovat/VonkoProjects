namespace TimerClass
{
    using System;

    class TimerClassMain
    {
        static void Main()
        {
            int seconds = 3000;
            int numberExecutions = 4;
            Action<object, EventArgs> method1 = WriteToConsole;
            Action<object, EventArgs> method2 = SecondMethod;

            Timer timer = new Timer(seconds, numberExecutions);
            EventListener listener1 = new EventListener(timer, method1);
            EventListener listener2 = new EventListener(timer, method2);
            timer.StartTimer();

            if (timer.Counter == 4)
            {
                listener1.Detach();
                listener2.Detach();
            }
        }

        private static void WriteToConsole(object obj, EventArgs e)
        {
            Console.WriteLine("3 seconds passed.");
        }

        private static void SecondMethod(object obj, EventArgs e)
        {
            Console.WriteLine("I'm the second method in the event :)");
        }
    }
}
