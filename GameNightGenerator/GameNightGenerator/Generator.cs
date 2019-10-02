using GameNightGenerator.Data;
using System.Collections.Generic;

namespace GameNightGenerator
{
    public class Generator
    {
        public string GenerateHTMLPageFromLeaderBoards(IEnumerable<ILeaderboard> leaderboards) {
            string outputString = null;
            foreach (var leaderboard in leaderboards)
            {
                outputString += GenerateHTMLLeaderBoards(leaderboard);
            }
            return outputString;
        }

        public string GenerateHTMLLeaderBoards(ILeaderboard leaderboard) {
            string outputString = $"\n<!-- START OF {leaderboard.GameName} -->\n";
            outputString += "<div class=score-table>\n";
            outputString += $"\t<h1>{leaderboard.GameName}</h1>\n";

            outputString += "\t<table class=\"table table-striped table-dark\">\n";
            outputString += "\t\t<thead>\n\t\t\t<tr>\n";

            string[] tableHeaders = new string[]{ "Position", "Name", "Games Played", "Points", "Avg."};
            foreach (var tableHeader in tableHeaders)
            {
                outputString += $"\t\t\t\t<th scope=\"col\">{tableHeader}</th>\n";
            }

            outputString += "\t\t\t</tr>\n";
            outputString += "\t\t</thead>\n\t\t<tbody>\n";

            int position = 1;
            foreach (var player in leaderboard.Players)
            {
                outputString += "\t\t\t<tr> \n";
                outputString += $"\t\t\t\t<td>{position++}</td>\n";
                outputString += $"\t\t\t\t<td>{player.Name}</td>\n";
                outputString += $"\t\t\t\t<td>{player.GamesPlayed}</td>\n";
                outputString += $"\t\t\t\t<td>{player.Points}</td>\n";
                outputString += $"\t\t\t\t<td>{player.Average}</td>\n";
            }
            outputString = outputString + "\t\t\t</tr>\n";

            return outputString + $"\t\t</tbody>\n\t</table>\n</div>\n<!--END OF {leaderboard.GameName} -->\n";

        }
    }
}
