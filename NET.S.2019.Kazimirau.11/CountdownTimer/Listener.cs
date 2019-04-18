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
            Console.WriteLine($"{e.Message} at {e.Time}");
        }
    }
}
