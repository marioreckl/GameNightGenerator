using GameNightGenerator.Data;

namespace GameNightGenerator
{
    public interface IDataAccess
    {
        ILeaderboard GetLeaderboard();
    }
}