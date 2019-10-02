using System;
namespace GameNightGenerator.DataAccess.Writer
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(string toPrint)
        {
            Console.WriteLine(toPrint);
        }
    }
}
