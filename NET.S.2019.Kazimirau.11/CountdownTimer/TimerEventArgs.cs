using System;

namespace CountdownTimer
{
    public class TimerEventArgs : EventArgs
    {
        public DateTime Time { get; set; }
        public int Milliseconds { get; set; }
    }
}
