using System;

namespace RouletteApp
{
    // Simplified bet system
    public enum RouletteBet
    {
        Zero = 0,
        Red = 1,
        Black = 2
    }

    public class RouletteEventArgs : EventArgs
    {
        public RouletteBet Bet { get; set; }
        public int Attempt { get; set; }
    }
}
