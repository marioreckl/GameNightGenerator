using System;
using System.Collections.Generic;
using GameNightGenerator.Data;
using System.IO;
using System.Linq;

namespace GameNightGenerator
{
    public class TextFileDataAccess : IDataAccess
    {
        private readonly string _directory;

        public TextFileDataAccess(string directory)
        {
            _directory = directory;
        }
        private ILeaderboard GetLeaderboard(FileInfo file)
        {
            using (StreamReader sr = new StreamReader(file.FullName))
            {
                string currentLine = sr.ReadLine();
                string gameName = currentLine;
                List<IPlayer> players = new List<IPlayer>();
                
                while (!string.IsNullOrEmpty(currentLine = sr.ReadLine()))
                {
                    var player = currentLine.Split(',');
                    players.Add(new Player(player[0], int.Parse(player[1]), int.Parse(player[2])));
                }
                players.OrderBy(x => x.Average);
                return new Leaderboard(gameName, players);
            }
        }

        public IEnumerable<ILeaderboard> GetLeaderboards()
        {
            List<ILeaderboard> leaderboards = new List<ILeaderboard>();
            var gameFiles = new DirectoryInfo(_directory).GetFiles("*", 0);
            foreach (var gameFile in gameFiles)
            {
                leaderboards.Add(GetLeaderboard(gameFile));
                
            }
            return leaderboards;
        }
    }
}
