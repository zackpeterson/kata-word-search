using System;
using System.IO;
using System.Reflection;
using static WordSearch.Puzzle;

namespace WordSearch
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filename;
            if(args.Length >= 1)
            {
                filename = args[0];
            }
            else
            {
                filename = "puzzle-01-given-example.txt";
            }

            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = directory + "/" + filename;
            string text;
            try
            {
                text = File.ReadAllText(path);
            }
            catch
            {
                Console.WriteLine("failed to load file");
                Console.WriteLine("path: " + path);
                return;
            }

            Puzzle puzzle;
            try
            {
                puzzle = new Puzzle(text);
            }
            catch
            {
                Console.WriteLine("failed to parse puzzle");
                return;
            }

            string solutionString = SolutionToString(puzzle.Solution);
            Console.Write(solutionString);
        }
    }
}
