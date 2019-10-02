namespace GameNightGenerator.Data
{
    public interface IPlayer
    {
        string Name { get; }
        int Points { get; }
        int GamesPlayed { get; }
        double Average { get; }
    }
}
