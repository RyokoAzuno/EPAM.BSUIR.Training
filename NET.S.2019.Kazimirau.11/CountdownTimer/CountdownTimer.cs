using System;
using System.Threading;

namespace CountdownTimer
{
    /// <summary>
    /// Class that represents a countdown timer
    /// </summary>
    public class CountdownTimer
    {
        private int _milliseconds;

        public CountdownTimer(int milliseconds = 10000)
        {
            _milliseconds = milliseconds;
        }

        /// <summary>
        /// Countdown event
        /// </summary>
        public event EventHandler<TimerEventArgs> CountdownEvent;

        /// <summary>
        /// Rise event method
        /// </summary>
        public void SimulateCountdown()
        {
            TimerEventArgs e = new TimerEventArgs();

            while (_milliseconds >= 0)
            {
                Console.Clear();
                Console.WriteLine($"{_milliseconds / 1000} sec");
                Thread.Sleep(1000);
                _milliseconds -= 1000;
            }

            e.Time = DateTime.Now;
            e.Milliseconds = _milliseconds;
            e.Message = "Timer was stopped!!";
            OnTimer(e);
        }

        protected virtual void OnTimer(TimerEventArgs e)
        {
            Volatile.Read(ref CountdownEvent)?.Invoke(this, e);
        }
    }
}
