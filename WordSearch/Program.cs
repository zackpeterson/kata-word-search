using System;
using System.IO;
using System.Reflection;

namespace WordSearch
{
    public class Program
    {
        static void Main(string[] args)
        {
            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filename = "puzzle-01-given-example.txt";
            string path = directory + "/" + filename;
            string text = File.ReadAllText(path);

            bool isValid = Puzzle.Validate(text);
        }
    }
}
