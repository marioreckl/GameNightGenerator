using System.Collections.Generic;

namespace GameNightGenerator.Data
{
    public interface ILeaderboard
    {
        string GameName { get; }
        IEnumerable<IPlayer> Players {get;}
    }
}
