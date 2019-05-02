using System;

namespace RouletteApp
{
    /// <summary>
    /// Class represents a player for roulette
    /// </summary>
    public class Player
    {
        // Player bet
        private RouletteBet _bet;
        
        // Player name
        private string _name;

        public Player(Roulette roulette, RouletteBet bet, string name)
        {
            _bet = bet;
            _name = name;
            roulette.RouletteEvent += Listen;
        }

        // Listener unregister itself so that it no longer receives notifications
        public void Unregister(Roulette roulette)
        {
            roulette.RouletteEvent -= Listen;
        }

        // This is the method the Roulette will call
        // when the roulette spinner stop
        private void Listen(object sender, RouletteEventArgs e)
        {
            if (_bet == e.Bet)
            {
                Console.WriteLine($"{_name}'s Attempt({e.Attempt})| Your bet: {_bet} - Roulette: {e.Bet}. Winner!!!");
            }
            else
            {
                Console.WriteLine($"{_name}'s Attempt({e.Attempt})| Your bet: {_bet} - Roulette:{e.Bet}. Loser!!!");
            }
        }
    }
}
