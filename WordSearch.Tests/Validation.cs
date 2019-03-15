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

        [TestMethod]
        public void ValidateWordsExist_ShouldReturnTrue_WhenWordsExist()
        {
            string message = "there must be words";

            string[] emptywords = new string[] { };
            bool emptyresult = Puzzle.ValidateWordsExist(emptywords);
            Assert.IsFalse(emptyresult, message);

            string[] populatedwords = new string[] {"ONE", "TWO", "THREE"};
            bool populatedresult = Puzzle.ValidateWordsExist(populatedwords);
            Assert.IsTrue(populatedresult, message);
        }

        [TestMethod]
        public void Validate_ShouldReturnFalse_WhenNoWordsExist()
        {
            string message = "there must be words";
            string text = @"
                           A,B,C
                           D,E,F
                           G,H,I";
            bool result = Puzzle.Validate(text);
            Assert.IsFalse(result, message);
        }
    }
}