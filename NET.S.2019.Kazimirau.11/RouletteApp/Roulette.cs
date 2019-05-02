using System;
using System.Threading;

namespace RouletteApp
{
    /// <summary>
    /// Very simple roulette class 
    /// </summary>
    public class Roulette
    {
        public EventHandler<RouletteEventArgs> RouletteEvent;

        public void Simulate(int attempts)
        {
            RouletteEventArgs e = new RouletteEventArgs();

            Random rnd = new Random();
            for (int i = 0; i < attempts; i++)
            {
                e.Attempt = i + 1;
                e.Bet = (RouletteBet)rnd.Next(0, 3);
                OnRoulette(e);
            }
            
        }

        protected virtual void OnRoulette(RouletteEventArgs e)
        {
            Volatile.Read(ref RouletteEvent)?.Invoke(this, e);
        }
    }
}
