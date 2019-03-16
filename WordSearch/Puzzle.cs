using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordSearch
{
    public class Puzzle
    {
        public readonly List<string> Words;
        public readonly char[,] Grid;
        public readonly List<FoundWord> Solution;

        public Puzzle(string text)
        {
            bool isValid = Puzzle.Validate(text);
            if(!isValid)
            {
                throw new Exception("puzzle text format is invalid");
            }

            // split lines on carriage return and line feed
            string[] lines = text.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );

            // split words on comma
            Words = lines[0].Split(",").ToList();

            // determine grid size
            int gridsize = lines.Length - 1;

            Grid = new char[gridsize, gridsize];
            for(int y = 0; y < gridsize; y++)
            {
                // split letters on comma
                string[] letters = lines[y + 1].Split(",");

                // put letters into grid
                for(int x = 0; x < letters.Length; x++)
                {
                    Grid[y, x] = letters[x].ToCharArray()[0];
                }
            }

            Solution = Solve(Words, Grid);
        }

        public class FoundWord
        {
            public string Word { get; set; }
            public List<(int y, int x)> Positions { get; set; }
        }

        public static List<FoundWord> Solve(List<string> words, char[,] grid)
        {
            List<FoundWord> result = new List<FoundWord>();
            foreach(string word in words)
            {
                List<FoundWord> f = Solve(word, grid);
                result.AddRange(f);
            }
            return result;
        }

        public static List<FoundWord> Solve(string word, char[,] grid)
        {
            List<FoundWord> result = new List<FoundWord>();
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    var position = (y: y, x: x);
                    List<FoundWord> f = Solve(word, grid, position);
                    result.AddRange(f);
                }
            }
            return result;
        }
        public static List<FoundWord> Solve(string word, char[,] grid, (int y, int x) position)
        {
            List<FoundWord> result = new List<FoundWord>();
            if(grid[position.y, position.x] == word.ToCharArray()[0])
            {
                List<FoundWord> candidates = Candidates(word.Length, grid, position);
                foreach (FoundWord c in candidates)
                {
                    if (c.Word == word)
                    {
                        result.Add(c);
                    }
                }
            }
            return result;
        }

        public static List<FoundWord> Candidates(int wordlength, char[,] grid, (int y, int x) position)
        {
            List<FoundWord> candidates = new List<FoundWord>();
            foreach (Direction d in Enum.GetValues(typeof(Direction)))
            {
                if (IsRoom(wordlength, grid.GetLength(0), grid.GetLength(1), position, d))
                {
                    FoundWord candidate = new FoundWord();
                    candidate.Word = String.Empty;
                    candidate.Positions = new List<(int y, int x)>();
                    for (int l = 0; l < wordlength; l++)
                    {
                        int y;
                        int x;
                        switch (d)
                        {
                            case Direction.North:
                                y = position.y - l;
                                x = position.x;
                                break;
                            case Direction.Northeast:
                                y = position.y - l;
                                x = position.x + l;
                                break;
                            case Direction.East:
                                y = position.y;
                                x = position.x + l;
                                break;
                            case Direction.Southeast:
                                y = position.y + l;
                                x = position.x + l;
                                break;
                            case Direction.South:
                                y = position.y + l;
                                x = position.x;
                                break;
                            case Direction.Southwest:
                                y = position.y + l;
                                x = position.x - l;
                                break;
                            case Direction.West:
                                y = position.y;
                                x = position.x - l;
                                break;
                            case Direction.Northwest:
                                y = position.y - l;
                                x = position.x - l;
                                break;
                            default:
                                throw new Exception("unhandled direction");
                        }
                        candidate.Word += grid[y, x];
                        candidate.Positions.Add((y, x));
                    }
                    candidates.Add(candidate);
                }
            }
            return candidates;
        }

        public enum Direction
        {
            North,
            Northeast,
            East,
            Southeast,
            South,
            Southwest,
            West,
            Northwest
        }

        public static bool IsRoom(int wordlength, int gridRowCount, int gridColumnCount, (int y, int x) position, Direction direction)
        {
            bool isRoomNorth = position.y - (wordlength - 1) >= 0;
            bool isRoomEast = position.x + (wordlength - 1) <= gridColumnCount - 1;
            bool isRoomSouth = position.y + (wordlength - 1) <= gridRowCount - 1;
            bool isRoomWest = position.x - (wordlength - 1) >= 0;
            switch (direction)
            {
                case Direction.North:
                    return isRoomNorth;
                case Direction.Northeast:
                    return isRoomNorth && isRoomEast;
                case Direction.East:
                    return isRoomEast;
                case Direction.Southeast:
                    return isRoomSouth && isRoomEast;
                case Direction.South:
                    return isRoomSouth;
                case Direction.Southwest:
                    return isRoomSouth && isRoomWest;
                case Direction.West:
                    return isRoomWest;
                case Direction.Northwest:
                    return isRoomNorth && isRoomWest;
                default:
                    throw new Exception("unhandled direction");
            }
        }

        public static bool Validate(string text)
        {
            bool result = true;

            result &= ValidateCharacters(text);

            // split lines on carriage return and line feed
            string[] lines = text.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );
            
            // determine grid size
            int gridsize = lines.Length - 1;

            // split words on comma
            string[] words = lines[0].Split(",");

            result &= ValidateWordsExist(words);
            result &= ValidateWordsNotTooShort(words);
            result &= ValidateWordsNotTooLong(words, gridsize);
            result &= ValidateWordsDoNotRepeat(words);

            char[,] grid = new char[gridsize, gridsize];
            for(int y = 0; y < gridsize; y++)
            {
                // split letters on comma
                string[] letters = lines[y + 1].Split(",");

                result &= ValidateEachLetterIsSingleCharacter(letters);
                result &= ValidateLineHasCorrectNumberOfLetters(letters, gridsize);
            }

            return result;
        }

        public static bool ValidateCharacters(string text)
        {
            Regex r = new Regex(@"[^A-Z,\r\n]");
            return !r.IsMatch(text);
        }

        public static bool ValidateWordsExist(string[] words)
        {
            return words.Length >= 1 && words[0] != String.Empty;
        }

        public static bool ValidateWordsNotTooShort(string[] words)
        {
            return words.All(word => word.Length >= 2);
        }

        public static bool ValidateWordsNotTooLong(string[] words, int gridsize)
        {
            return words.All(word => word.Length <= gridsize);
        }

        public static bool ValidateWordsDoNotRepeat(string[] words)
        {
            return words.Length == words.Distinct().Count();
        }

        public static bool ValidateEachLetterIsSingleCharacter(string[] letters)
        {
            return letters.All(letter => letter.Length == 1);
        }

        public static bool ValidateLineHasCorrectNumberOfLetters(string[] letters, int gridsize)
        {
            return letters.Length == gridsize;
        }
    }
}