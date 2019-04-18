using System;
using System.Threading.Tasks;

namespace CountdownTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            CountdownTimer timer = new CountdownTimer(5000);
            Listener listener1 = new Listener(timer);
            Listener listener2 = new Listener(timer);

            Task.Factory.StartNew(timer.SimulateCountdown);

            Console.ReadLine();
        }
    }
}
