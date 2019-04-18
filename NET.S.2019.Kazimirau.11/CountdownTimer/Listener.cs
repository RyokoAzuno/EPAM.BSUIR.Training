using System;

namespace CountdownTimer
{
    public class Listener
    {
        public Listener(Timer timer)
        {
            timer.TimerEvent += Listen;
        }

        private void Listen(object sender, TimerEventArgs e)
        {
            Console.WriteLine($"{e.Time} -- {e.Milliseconds / 1000} sec.");
        }
    }
}
