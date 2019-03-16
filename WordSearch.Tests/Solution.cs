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

        [TestMethod]
        public void Solve_ShouldReturnFoundWords_WhenGivenGridAndSingleWord()
        {
            string message = "searches all positions to find all instances of a single word";
            string word = "BE";
            char[,] grid = new char[,] { {'A', 'B', 'C'},
                                         {'D', 'E', 'F'},
                                         {'G', 'H', 'I'} };
            List<FoundWord> actual = Solve(word, grid);

            List<FoundWord> expected = new List<FoundWord>();
            FoundWord south = new FoundWord();
            south.Word = "BE";
            south.Positions = new List<(int y, int x)> {(0, 1), (1, 1)};
            expected.Add(south);

            Assert.AreEqual(expected[0].Word, actual[0].Word, message);
            CollectionAssert.AreEqual(expected[0].Positions, actual[0].Positions, message);
        }

        [TestMethod]
        public void Solve_ShouldReturnFoundWords_WhenGivenGridAndSeveralWords()
        {
            string message = "searches all positions to find all instances of a single word";
            List<string> words = new List<string>{"AB", "AD", "BE", "HE", "HI"};
            char[,] grid = new char[,] { {'A', 'B', 'C'},
                                         {'D', 'E', 'F'},
                                         {'G', 'H', 'I'} };
            List<FoundWord> actual = Solve(words, grid);

            List<FoundWord> expected = new List<FoundWord>();
            FoundWord ab = new FoundWord();
            ab.Word = "AB";
            ab.Positions = new List<(int y, int x)> {(0, 0), (0, 1)};
            expected.Add(ab);
            FoundWord ad = new FoundWord();
            ad.Word = "AD";
            ad.Positions = new List<(int y, int x)> {(0, 0), (1, 0)};
            expected.Add(ad);
            FoundWord be = new FoundWord();
            be.Word = "BE";
            be.Positions = new List<(int y, int x)> {(0, 1), (1, 1)};
            expected.Add(be);
            FoundWord he = new FoundWord();
            he.Word = "HE";
            he.Positions = new List<(int y, int x)> {(2, 1), (1, 1)};
            expected.Add(he);
            FoundWord hi = new FoundWord();
            hi.Word = "HI";
            hi.Positions = new List<(int y, int x)> {(2, 1), (2, 2)};
            expected.Add(hi);

            Assert.AreEqual(expected[0].Word, actual[0].Word, message);
            CollectionAssert.AreEqual(expected[0].Positions, actual[0].Positions, message);

            Assert.AreEqual(expected[1].Word, actual[1].Word, message);
            CollectionAssert.AreEqual(expected[1].Positions, actual[1].Positions, message);

            Assert.AreEqual(expected[2].Word, actual[2].Word, message);
            CollectionAssert.AreEqual(expected[2].Positions, actual[2].Positions, message);

            Assert.AreEqual(expected[3].Word, actual[3].Word, message);
            CollectionAssert.AreEqual(expected[3].Positions, actual[3].Positions, message);

            Assert.AreEqual(expected[4].Word, actual[4].Word, message);
            CollectionAssert.AreEqual(expected[4].Positions, actual[4].Positions, message);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetSolvedPuzzleData), DynamicDataSourceType.Method)]
        public void Puzzle_ShouldHaveSolution_WhenConstructed(string text, List<FoundWord> expected)
        {
            string message = "puzzle should be solved correctly";
            List<FoundWord> actual = (new Puzzle(text)).Solution;
            Assert.AreEqual(expected.Count, actual.Count, message);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Word, actual[i].Word, message);
                CollectionAssert.AreEqual(expected[i].Positions, actual[i].Positions, message);
            }
        }

        public static IEnumerable<object[]> GetSolvedPuzzleData()
        {
            // 01
            string text01 = @"CIVIC,LEVEL
                              C,X,L,S,U
                              X,I,E,P,W
                              U,S,V,C,A
                              O,W,E,I,J
                              C,Y,L,F,C".Replace(" ", "");

            List<FoundWord> expected01 = new List<FoundWord>();

            FoundWord e01f01 = new FoundWord();
            e01f01.Word = "CIVIC";
            e01f01.Positions = new List<(int y, int x)> {(0, 0), (1, 1), (2, 2), (3, 3), (4, 4)};
            expected01.Add(e01f01);

            FoundWord e01f02 = new FoundWord();
            e01f02.Word = "CIVIC";
            e01f02.Positions = new List<(int y, int x)> {(4, 4), (3, 3), (2, 2), (1, 1), (0, 0)};
            expected01.Add(e01f02);

            FoundWord e01f03 = new FoundWord();
            e01f03.Word = "LEVEL";
            e01f03.Positions = new List<(int y, int x)> {(0, 2), (1, 2), (2, 2), (3, 2), (4, 2)};
            expected01.Add(e01f03);

            FoundWord e01f04 = new FoundWord();
            e01f04.Word = "LEVEL";
            e01f04.Positions = new List<(int y, int x)> {(4, 2), (3, 2), (2, 2), (1, 2), (0, 2)};
            expected01.Add(e01f04);

            // 02
            string text02 = @"JERRY,ELAINE,GEORGE,KRAMER
                              E,S,Q,Y,K,Y
                              N,G,V,H,R,R
                              I,P,R,X,A,R
                              A,D,F,O,M,E
                              L,Y,R,R,E,J
                              E,J,G,K,R,G".Replace(" ", "");

            List<FoundWord> expected02 = new List<FoundWord>();

            FoundWord e02f01 = new FoundWord();
            e02f01.Word = "JERRY";
            e02f01.Positions = new List<(int y, int x)> {(4, 5), (3, 5), (2, 5), (1, 5), (0, 5)};
            expected02.Add(e02f01);

            FoundWord e02f02 = new FoundWord();
            e02f02.Word = "JERRY";
            e02f02.Positions = new List<(int y, int x)> {(4, 5), (4, 4), (4, 3), (4, 2), (4, 1)};
            expected02.Add(e02f02);

            FoundWord e02f03 = new FoundWord();
            e02f03.Word = "ELAINE";
            e02f03.Positions = new List<(int y, int x)> {(5, 0), (4, 0), (3, 0), (2, 0), (1, 0), (0, 0)};
            expected02.Add(e02f03);

            FoundWord e02f04 = new FoundWord();
            e02f04.Word = "GEORGE";
            e02f04.Positions = new List<(int y, int x)> {(5, 5), (4, 4), (3, 3), (2, 2), (1, 1), (0, 0)};
            expected02.Add(e02f04);

            FoundWord e02f05 = new FoundWord();
            e02f05.Word = "KRAMER";
            e02f05.Positions = new List<(int y, int x)> {(0, 4), (1, 4), (2, 4), (3, 4), (4, 4), (5, 4)};
            expected02.Add(e02f05);

            // 03
            string text03 = @"FRY,AMY
                              A,B,A
                              C,D,M
                              F,R,Y".Replace(" ", "");

            List<FoundWord> expected03 = new List<FoundWord>();

            FoundWord e03f01 = new FoundWord();
            e03f01.Word = "FRY";
            e03f01.Positions = new List<(int y, int x)> {(2, 0), (2, 1), (2, 2)};
            expected03.Add(e03f01);

            FoundWord e03f02 = new FoundWord();
            e03f02.Word = "AMY";
            e03f02.Positions = new List<(int y, int x)> {(0, 2), (1, 2), (2, 2)};
            expected03.Add(e03f02);

            // return
            yield return new object[] { text01, expected01 };
            yield return new object[] { text02, expected02 };
            yield return new object[] { text03, expected03 };
        }
    }
}