using System;
using System.Threading;

namespace CountdownTimer
{
    public class Timer
    {
        public event EventHandler<TimerEventArgs> TimerEvent;
        private int _milliseconds;

        public Timer(int milliseconds = 10000)
        {
            _milliseconds = milliseconds;
        }
        protected virtual void OnTimer(TimerEventArgs e)
        {
            Volatile.Read(ref TimerEvent)?.Invoke(this, e);
        }

        public void SimulateCountdown()
        {
            TimerEventArgs e = new TimerEventArgs();

            while (_milliseconds >= 0)
            {
                Thread.Sleep(1000);
                e.Time = DateTime.Now;
                e.Milliseconds = _milliseconds;
                OnTimer(e);
                _milliseconds -= 1000;
            }
            Console.WriteLine("Timer was stopped!!");
        }
    }
}
