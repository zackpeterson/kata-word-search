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

        [DataTestMethod]
        [DataRow(6, true)]
        [DataRow(5, true)]
        [DataRow(4, false)]
        public void ValidateWordsNotTooLong_ShouldReturnTrue_WhenWordsFitWithinGrid(int gridsize, bool expected)
        {
            string message = "words cannot be longer than the grid size";
            string[] words = new string[] {"ONE", "TWO", "THREE", "FOUR"};
            bool actual = Puzzle.ValidateWordsNotTooLong(words, gridsize);
            Assert.AreEqual(expected, actual, message);
        }

        [TestMethod]
        public void Validate_ShouldReturnFalse_WhenWordsDoNotFitWithinGrid()
        {
            string message = "words cannot be longer than the grid size";
            string text = @"AB,DEF,GHIJ
                            A,B,C
                            D,E,F
                            G,H,I".Replace(" ", "");
            bool result = Puzzle.Validate(text);
            Assert.IsFalse(result, message);
        }

        [TestMethod]
        public void ValidateWordsDoNotRepeat_ShouldReturnTrue_WhenWordsAreUnique()
        {
            string message = "words cannot repeat";

            string[] repeatwords = new string[] {"ONE", "TWO", "ONE", "THREE"};
            bool repeatresult = Puzzle.ValidateWordsDoNotRepeat(repeatwords);
            Assert.IsFalse(repeatresult, message);

            string[] uniquewords = new string[] {"ONE", "TWO", "THREE"};
            bool uniqueresult = Puzzle.ValidateWordsDoNotRepeat(uniquewords);
            Assert.IsTrue(uniqueresult, message);
        }

        [TestMethod]
        public void Validate_ShouldReturnFalse_WhenWordsAreRepeated()
        {
            string message = "words cannot repeat";
            string text = @"AB,DEF,AB
                            A,B,C
                            D,E,F
                            G,H,I".Replace(" ", "");
            bool result = Puzzle.Validate(text);
            Assert.IsFalse(result, message);
        }

        [TestMethod]
        public void ValidateEachLetterIsSingleCharacter_ShouldReturnTrue_WhenEachLetterIsSingleCharacter()
        {
            string message = "each letter string must be a single character long";

            string[] multipleletters = new string[] {"A", "BB", "C", "D"};
            bool multipleresult = Puzzle.ValidateEachLetterIsSingleCharacter(multipleletters);
            Assert.IsFalse(multipleresult, message);

            string[] singleletters = new string[] {"A", "B", "C", "D"};
            bool singleresult = Puzzle.ValidateEachLetterIsSingleCharacter(singleletters);
            Assert.IsTrue(singleresult, message);
        }

        [TestMethod]
        public void Validate_ShouldReturnFalse_WhenAnyLetterIsMultipleCharacters()
        {
            string message = "each letter string must be a single character long";
            string text = @"AB,DEF
                            A,B,C
                            D,EE,F
                            G,H,I".Replace(" ", "");
            bool result = Puzzle.Validate(text);
            Assert.IsFalse(result, message);
        }

        [DataTestMethod]
        [DataRow(6,false)]
        [DataRow(7,true)]
        [DataRow(8,false)]
        public void ValidateLineHasCorrectNumberOfLetters_ShouldReturnTrue_WhenGridIsSquare(int gridsize, bool expected)
        {
            string message = "each line must contain as many letters as there are rows of the grid";
            string[] letters = new string[] {"A", "B", "C", "D", "E", "F", "G"};
            bool actual = Puzzle.ValidateLineHasCorrectNumberOfLetters(letters, gridsize);
            Assert.AreEqual(expected, actual, message);
        }

        [TestMethod]
        public void Validate_ShouldReturnFalse_WhenGridIsNotSquare()
        {
            string message = "each line must contain as many letters as there are rows of the grid";

            string rectangletext = @"AB,DEF
                                     A,B,C,D
                                     E,F,G,H
                                     I,J,K,L".Replace(" ", "");
            bool rectangleresult = Puzzle.Validate(rectangletext);
            Assert.IsFalse(rectangleresult, message);

            string uneventext = @"AB,DEF
                                  A,B,C,D
                                  E,F,G
                                  H,I".Replace(" ", "");
            bool unevenresult = Puzzle.Validate(uneventext);
            Assert.IsFalse(unevenresult, message);
        }
    }
}