using System;
using System.Threading;

namespace CountdownTimer
{
    public class CountdownTimer
    {
        public event EventHandler<TimerEventArgs> TimerEvent;
        private int _milliseconds;

        public CountdownTimer(int milliseconds = 10000)
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
    }
}
