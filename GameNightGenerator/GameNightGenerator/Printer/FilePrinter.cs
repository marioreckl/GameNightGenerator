using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GameNightGenerator.DataAccess.Writer
{
    public class FilePrinter : IPrinter
    {
        private readonly string directory;

        public FilePrinter(string directory)
        {
            this.directory = directory;
        }
        public void Print(string toPrint)
        {
            File.WriteAllText($"{directory}\\output.txt", toPrint);

        }
    }
}
