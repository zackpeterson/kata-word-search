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

        [TestMethod]
        public void ValidateWordsNotTooShort_ShouldReturnTrue_WhenWordsAreLongEnough()
        {
            string message = "words cannot be shorter than 2 letters";
            
            string[] blankwords = new string[] {""};
            bool blankresult = Puzzle.ValidateWordsNotTooShort(blankwords);
            Assert.IsFalse(blankresult, message);
            
            string[] singleletterwords = new string[] {"A"};
            bool singleletterresult = Puzzle.ValidateWordsNotTooShort(singleletterwords);
            Assert.IsFalse(singleletterresult, message);

            string[] mulitpleletterwords = new string[] {"AB", "ABC", "ABCD"};
            bool multipleletterresult = Puzzle.ValidateWordsNotTooShort(mulitpleletterwords);
            Assert.IsTrue(multipleletterresult, message);
        }

        [TestMethod]
        public void Validate_ShouldReturnFalse_WhenWordsAreTooShort()
        {
            string message = "words cannot be shorter than 2 letters";
            string text = @"AB,C,DEF
                            A,B,C
                            D,E,F
                            G,H,I".Replace(" ", "");
            bool result = Puzzle.Validate(text);
            Assert.IsFalse(result, message);
        }
    }
}