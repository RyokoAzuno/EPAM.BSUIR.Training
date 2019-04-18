using System;

namespace CountdownTimer
{
    /// <summary>
    /// Type that will hold any additional information that
    /// should be sent to receivers of the event notification
    /// </summary>
    public class TimerEventArgs : EventArgs
    {
        public DateTime Time { get; set; }
        public int Milliseconds { get; set; }
        public string Message { get; set; }
    }
}
