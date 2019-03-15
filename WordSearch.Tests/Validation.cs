using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordSearch;

namespace WordSearch.Tests
{
    [TestClass]
    public class Validation
    {
        [DataTestMethod]
        [DataRow("A", true)]
        [DataRow(",", true)]
        [DataRow("\r\n", true)]
        [DataRow("a", false)]
        [DataRow(" ", false)]
        [DataRow("1", false)]
        public void ValidateCharacters_ShouldReturnTrue_WhenAllCharactersAreAllowed(string text, bool expected)
        {
            string message = "allow only capital letters A through Z, commas, carriage return and line feed";
            bool actual = Puzzle.ValidateCharacters(text);
            Assert.AreEqual(expected, actual, message);
        }

        [TestMethod]
        public void Validate_ShouldReturnFalse_WhenAnyCharactersAreDisallowed()
        {
            string message = "allow only capital letters A through Z, commas, carriage return and line feed";
            string text = @"AB,DEF
                            A,B,1
                            D,E,F
                            G,H,I".Replace(" ", "");
            bool result = Puzzle.Validate(text);
            Assert.IsFalse(result, message);
        }
    }
}