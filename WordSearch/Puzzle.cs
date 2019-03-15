using System;
using System.Text.RegularExpressions;

namespace WordSearch
{
    public class Puzzle
    {
        public static bool Validate(string text)
        {
            bool result = true;

            result &= ValidateCharacters(text);

            return result;
        }

        public static bool ValidateCharacters(string text)
        {
            Regex r = new Regex(@"[^A-Z,\r\n]");
            return !r.IsMatch(text);
        }
    }
}