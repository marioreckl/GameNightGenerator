using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameNightGenerator
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            GenerateLeaderBoard(@"C:\Users\Mario\Desktop\HTMLGenerator\HTMLGenerator\");
        }


        public void GenerateLeaderBoard(string directory) {
            var gameFiles = new DirectoryInfo($"{directory}Sample\\").GetFiles("*", 0);
            var leaderBoards = "";
            foreach (var gameFile in gameFiles)
            {
                var file = new StreamReader(gameFile.FullName);
                Console.WriteLine($"\n\n\n{gameFile.Name} \n");
                var leaderBoard = GenerateHTMLLeaderBoard(file);
                leaderBoards += leaderBoard;
                Console.WriteLine(leaderBoard);

                file.Close();

            }
            File.WriteAllText($"{directory}output.txt", leaderBoards);
            Console.WriteLine("\n\n\n\n\nDONE!");
            Console.ReadLine();
            Console.Clear();
        }

        public string GenerateHTMLLeaderBoard(StreamReader file)
        {

            string currentLine = file.ReadLine();
            string gameName = currentLine;
            string outputString = $"\n<!-- START OF {gameName} -->\n";
            outputString += "<div class=score-table>\n";
            outputString += $"\t<h1>{gameName}</h1>\n";

            outputString += "\t<table class=\"table table-striped table-dark\">\n";
            outputString += "\t\t<thead>\n\t\t\t<tr>\n";
            currentLine = file.ReadLine();
            var tableHeaders = currentLine.Split(',');
            foreach (var tableHeader in tableHeaders)
            {
                outputString = outputString + $"\t\t\t\t<th scope=\"col\">{tableHeader}</th>\n";
            }

            outputString += "\t\t\t</tr>\n";
            outputString += "\t\t</thead>\n\t\t<tbody>\n";

            if (int.TryParse(file.ReadLine(), out var orderByIndex))
            {
                List<string[]> players = new List<string[]>();
                var position = 1;
                while ((currentLine = file.ReadLine()) != null)
                {
                    var player = currentLine.Split(',');
                    players.Add(player);
                }

                players = players.OrderByDescending(x => float.Parse(x[orderByIndex].Replace("%", ""))).ToList();
                foreach (var player in players)
                {
                    outputString = outputString + "\t\t\t<tr> \n";
                    outputString = outputString + $"\t\t\t\t<td>{position}</td>\n";
                    position++;
                    foreach (var rowValue in player)
                    {
                        outputString = outputString + $"\t\t\t\t<td>{rowValue}</td>\n";
                    }
                    outputString = outputString + "\t\t\t</tr>\n";
                }
            }

            return outputString + $"\t\t</tbody>\n\t</table>\n</div>\n<!--END OF {gameName} -->\n";
        }
    }
}
