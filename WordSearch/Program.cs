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
            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filename = "puzzle-01-given-example.txt";
            string path = directory + "/" + filename;
            string text = File.ReadAllText(path);

            Puzzle puzzle = new Puzzle(text);

            foreach(FoundWord f in puzzle.Solution)
            {
                string line = f.Word + ": ";
                for(int p = 0; p < f.Positions.Count; p++)
                {
                    line += String.Format("({0},{1})", f.Positions[p].x, f.Positions[p].y);
                    if(p < f.Positions.Count - 1)
                    {
                        line += ",";
                    }
                }
                Console.WriteLine(line);
            }
        }
    }
}
