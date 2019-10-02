using GameNightGenerator.Data;
using System.Collections.Generic;

namespace GameNightGenerator
{
    public class HTMLGenerator
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
            string outputString = GenerateHeader();
            outputString += $"\n<!-- START OF {leaderboard.GameName} -->\n";
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
            outputString += "\t\t\t</tr>\n";

            outputString += $"\t\t</tbody>\n\t</table>\n</div>\n<!--END OF {leaderboard.GameName} -->\n";
            return outputString + GenerateFooter();

        }

        private string GenerateHeader() {
            return 
@"<!DOCTYPE html>
<html lang=""en"">
< head >
< meta charset = ""utf-8"" />
< meta name = ""viewport"" content = ""width=device-width, initial-scale=1, shrink-to-fit=no"" />
< meta name = ""description"" content = ""Game Nights"" />
< meta name = ""author"" content = ""Mario Reckl"" />
< title > Game Nights!</ title >
< script src = ""https://code.jquery.com/jquery-3.2.1.slim.min.js"" integrity = ""sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN"" crossorigin = ""anonymous"" ></ script >
< script src = ""https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"" integrity = ""sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q"" crossorigin = ""anonymous"" ></ script >
< script src = ""https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"" integrity = ""sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl"" crossorigin = ""anonymous"" ></ script >
< link rel = ""stylesheet"" href = ""https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"" integrity = ""sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm"" crossorigin = ""anonymous"" >
< link href = ""cssOverrides/gamenights.css"" rel = ""stylesheet"" />
</ head >
    < body > ";
        }

        private string GenerateFooter()
        {
            return
@"	</body>
</html>";
        }
    }
}
