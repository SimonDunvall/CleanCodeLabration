using System.Text.RegularExpressions;
using CleanCodeLab;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanCodeLabTests.Tests
{
    [TestClass]
    public class MooGameTests
    {
        [TestMethod]
        public void RandomNumbersAreUnique() //for GenerateRandomCode
        {
            IGameLogic gameLogic = new MooGame();
            string code = gameLogic.GenerateRandomCode();
            bool IsUnique = IsStringUnique(code);
            Assert.IsTrue(IsUnique);
        }

        private bool IsStringUnique(string s)
        {
            for (int char1Pos = 0; char1Pos < s.Length; char1Pos++)
            {
                for (int char2Pos = char1Pos + 1; char2Pos < s.Length; char2Pos++)
                {
                    if (s[char1Pos] == s[char2Pos])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        [TestMethod]
        public void NumberCodeIsRightLength() //for GenerateRandomCode
        {
            IGameLogic gameLogic = new MooGame();
            string code = gameLogic.GenerateRandomCode();
            Assert.AreEqual(4, code.Length);
        }

        [TestMethod]
        public void CheckIfStringOnlyContainsNumbers() //for GenerateRandomCode
        {
            IGameLogic gameLogic = new MooGame();
            string code = gameLogic.GenerateRandomCode();
            Assert.IsTrue(Regex.IsMatch(code, "^[0-9]+$"));
        }

        [TestMethod]
        public void GuessIsRight()
        {
            IGameLogic gameLogic = new MooGame(); //for CheckGuess
            string code = Mock4DigitNumber();
            string guess = Mock4DigitNumber();
            string checkedGuess = gameLogic.CheckGuess(code, guess);
            Assert.AreEqual("BBBB,", checkedGuess);
        }

        [TestMethod]
        public void GuessGivesPredictedOutCome() //for CheckGuess
        {
            IUI MockUI = new MockIO();
            IGameLogic gameLogic = new MooGame();
            string code = Mock4DigitNumber();
            string guess = MockUI.GetString();
            string checkedGuess = gameLogic.CheckGuess(code, guess);
            Assert.AreEqual("BB,C", checkedGuess);
        }

        private string Mock4DigitNumber()
        {
            return "1234";
        }
    }
}