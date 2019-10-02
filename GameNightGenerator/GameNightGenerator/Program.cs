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
            var textFileAccessor = new TextFileDataAccess(@"C:\Users\Mario\Desktop\HTMLGenerator\HTMLGenerator\Sample");
            //var randomGame = new RandomGamePicker().GetRandomGame(textFileAccessor);
            var leaderboards = textFileAccessor.GetLeaderboards();
            var output = new HTMLGenerator().GenerateHTMLPageFromLeaderBoards(leaderboards);
            Console.Write(output);
            Console.ReadLine();
        }
    }
}
