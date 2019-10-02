using GameNightGenerator.Data;
using System.Collections.Generic;

namespace GameNightGenerator
{
    public interface IDataAccess
    {
        IEnumerable<ILeaderboard> GetLeaderboards();
    }
}