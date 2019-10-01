using System.Collections.Generic;

namespace GameNightGenerator.Data
{
    public class Leaderboard : ILeaderboard
    {
        public Leaderboard(string gameName, IEnumerable<IPlayer> players)
        {
            GameName = gameName;
            Players = players;
        }

        public IEnumerable<IPlayer> Players { get; }

        public string GameName { get; }
    }
}
