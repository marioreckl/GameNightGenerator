using System;
using GameNightGenerator.Data;

namespace GameNightGenerator
{
    public class TextFileDataAccess : IDataAccess
    {
        private readonly string _directory;

        public TextFileDataAccess(string directory)
        {
            _directory = directory;
        }
        public ILeaderboard GetLeaderboard()
        {
            throw new NotImplementedException();
        }
    }
}
