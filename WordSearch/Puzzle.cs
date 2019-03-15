using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordSearch
{
    public class Puzzle
    {
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
    }
}