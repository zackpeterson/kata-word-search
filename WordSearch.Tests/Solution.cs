using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordSearch;

namespace WordSearch.Tests
{
    [TestClass]
    public class Solution
    {
        [TestMethod]
        public void Puzzle_ShouldHaveWords_WhenConstructed()
        {
            string message = "the Words property should be populated";
            string text = @"AB,DEF
                            A,B,C
                            D,E,F
                            G,H,I".Replace(" ", "");
            List<string> expected = new List<string> {"AB", "DEF"};
            Puzzle p = new Puzzle(text);
            List<string> actual = p.Words;
            CollectionAssert.AreEqual(actual, expected, message);
        }
    }
}