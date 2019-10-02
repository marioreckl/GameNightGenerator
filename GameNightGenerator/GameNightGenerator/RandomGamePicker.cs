using System;
using System.Collections.Generic;
using System.Text;

namespace GameNightGenerator
{
    public class RandomGamePicker
    {
        public string GetRandomGame(IDataAccess dataAccess) {
            var games = dataAccess.GetAvaiableGames();
            var rand = new Random();
            return games[rand.Next(games.Length)];
        }
    }
}
