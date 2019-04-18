using System;

namespace CountdownTimer
{
    /// <summary>
    /// Simple Listener for CountdownTimer
    /// </summary>
    public class Listener
    {
        // Pass the CountdownTimer object to the constructor
        public Listener(CountdownTimer timer)
        {
            timer.TimerEvent += Listen;
        }

        // Listener unregister itself so that it no longer receives notifications
        public void Unregister(CountdownTimer timer)
        {
            timer.TimerEvent -= Listen;
        }

        // This is the method the CountdownTimer will call
        // when the countdown timer stop
        private void Listen(object sender, TimerEventArgs e)
        {
            Console.WriteLine($"{e.Message} at {e.Time}");
        }
    }
}
