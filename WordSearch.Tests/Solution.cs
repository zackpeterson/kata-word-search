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
            char[,] expected = new char[,] { {'A', 'B', 'C'},
                                             {'D', 'E', 'F'},
                                             {'G', 'H', 'I'} };
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

        [TestMethod]
        public void Candidates_ShouldReturnStrings_WhenWordsFit()
        {
            string message = "find all possible strings of a given length from a given position in every direction of a given grid.";
            int wordlength = 3;
            char[,] grid = new char[,] { {'A', 'B', 'C'},
                                         {'D', 'E', 'F'},
                                         {'G', 'H', 'I'} };
            (int y, int x) position = (0, 0);
            List<FoundWord> actual = Candidates(wordlength, grid, position);

            List<FoundWord> expected = new List<FoundWord>();
            FoundWord east = new FoundWord();
            east.Word = "ABC";
            east.Positions = new List<(int y, int x)> {(0, 0), (0, 1), (0, 2)};
            expected.Add(east);
            FoundWord southeast = new FoundWord();
            southeast.Word = "AEI";
            southeast.Positions = new List<(int y, int x)> {(0, 0), (1, 1), (2, 2)};
            expected.Add(southeast);
            FoundWord south = new FoundWord();
            south.Word = "ADG";
            south.Positions = new List<(int y, int x)> {(0, 0), (1, 0), (2, 0)};
            expected.Add(south);

            Assert.AreEqual(expected[0].Word, actual[0].Word, message);
            CollectionAssert.AreEqual(expected[0].Positions, actual[0].Positions, message);

            Assert.AreEqual(expected[1].Word, actual[1].Word, message);
            CollectionAssert.AreEqual(expected[1].Positions, actual[1].Positions, message);

            Assert.AreEqual(expected[2].Word, actual[2].Word, message);
            CollectionAssert.AreEqual(expected[2].Positions, actual[2].Positions, message);
        }

        [TestMethod]
        public void Solve_ShouldReturnFoundWords_WhenGivenGridSingleWordAndSinglePosition()
        {
            string message = "find all instances of a single word starting from a single position";
            string word = "BE";
            char[,] grid = new char[,] { {'A', 'B', 'C'},
                                         {'D', 'E', 'F'},
                                         {'G', 'H', 'I'} };
            (int y, int x) position = (0, 1);
            List<FoundWord> actual = Solve(word, grid, position);

            List<FoundWord> expected = new List<FoundWord>();
            FoundWord south = new FoundWord();
            south.Word = "BE";
            south.Positions = new List<(int y, int x)> {(0, 1), (1, 1)};
            expected.Add(south);

            Assert.AreEqual(expected[0].Word, actual[0].Word, message);
            CollectionAssert.AreEqual(expected[0].Positions, actual[0].Positions, message);
        }
    }
}