namespace GameNightGenerator.Data
{
    public class Player : IPlayer
    {

        public Player(string name, int points, int gamesPlayed)
        {
            Name = name;
            Points = points;
            GamesPlayed = gamesPlayed;
        }

        public string Name { get; }
        public int Points { get; }
        public int GamesPlayed { get; }
    }
}
