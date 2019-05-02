namespace RouletteApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Roulette roulette = new Roulette();
            Player p1 = new Player(roulette, RouletteBet.Black, "Mike");
            Player p2 = new Player(roulette, RouletteBet.Red, "Ann");
            Player p3 = new Player(roulette, RouletteBet.Zero, "Jane");

            roulette.Simulate(3);
        }
    }
}
