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
            var leaderboards = textFileAccessor.GetLeaderboards();
            var output = new Generator().GenerateHTMLPageFromLeaderBoards(leaderboards);
            Console.Write(output);
            Console.ReadLine();
        }
    }
}
