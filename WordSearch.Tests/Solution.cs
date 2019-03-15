using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordSearch;
using static WordSearch.Puzzle;

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

        [TestMethod]
        public void Puzzle_ShouldHaveGrid_WhenConstructed()
        {
            string message = "the Grid property should be populated";
            string text = @"AB,DEF
                            A,B,C
                            D,E,F
                            G,H,I".Replace(" ", "");
            char[,] expected = new char[,] { {'A', 'B', 'C'}, {'D', 'E', 'F'}, {'G', 'H', 'I'} };
            Puzzle p = new Puzzle(text);
            char[,] actual = p.Grid;
            CollectionAssert.AreEqual(actual, expected, message);
        }

        [TestMethod]
        public void IsRoom_ShouldReturnTrue_WhenTheWordFits()
        {
            string message = "determine if a word of a given length that starts from a given position and continues toward a given direction will fit in a puzzle of a given size";

            int fitwordlength = 3;
            int fitgridRowCount = 5;
            int fitgridColumnCount = 5;
            (int y, int x) fitposition = (2,2);
            Direction fitdirection = Direction.North;
            bool fitresult = Puzzle.IsRoom(fitwordlength, fitgridRowCount, fitgridColumnCount, fitposition, fitdirection);
            Assert.IsTrue(fitresult, message);

            int unfitwordlength = 4;
            int unfitgridRowCount = 4;
            int unfitgridColumnCount = 4;
            (int y, int x) unfitposition = (0, 0);
            Direction unfitdirection = Direction.West;
            bool unfitresult = Puzzle.IsRoom(unfitwordlength, unfitgridRowCount, unfitgridColumnCount, unfitposition, unfitdirection);
            Assert.IsFalse(unfitresult, message);
        }
    }
}