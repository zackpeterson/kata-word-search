using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordSearch
{
    public class Puzzle
    {
        public readonly List<string> Words;

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