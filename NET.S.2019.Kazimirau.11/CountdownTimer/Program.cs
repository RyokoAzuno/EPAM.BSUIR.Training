using System;

namespace CountdownTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            Listener listener1 = new Listener(timer);
            Listener listener2 = new Listener(timer);

            timer.SimulateCountdown();

            Console.ReadLine();
        }
    }
}
