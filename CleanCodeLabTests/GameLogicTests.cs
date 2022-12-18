using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CleanCodeLab;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanCodeLabTests.Tests
{
    [TestClass]
    public class GameLogicTests
    {
        [TestMethod]
        public void RandomNumbersAreUnique()
        {
            GameLogic gameLogic = new GameLogic();
            string value = gameLogic.make4DigitNumber();
            bool IsUnique = IsStringUnique(value);
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
        public void NumberCodeIsRightLength()
        {
            GameLogic gameLogic = new GameLogic();
            string value = gameLogic.make4DigitNumber();
            Assert.AreEqual(4, value.Length);
        }

        [TestMethod]
        public void CheckIfStringOnlyContainsNumbers()
        {
            GameLogic gameLogic = new GameLogic();
            string value = gameLogic.make4DigitNumber();
            Assert.IsTrue(Regex.IsMatch(value, "^[0-9]+$"));
        }

        [TestMethod]
        public void GuessIsRight()
        {
            GameLogic gameLogic = new GameLogic();
            string numberCode = Mock4DigitNumber();
            string guess = Mock4DigitNumber();
            string value = gameLogic.checkGuess(numberCode, guess);
            Assert.AreEqual("BBBB,", value);
        }

        [TestMethod]
        public void GuessGivesPredictedOutCome()
        {
            GameLogic gameLogic = new GameLogic();
            IUI MockUI = new MockIO();
            string numberCode = Mock4DigitNumber();
            string guess = MockUI.GetString();
            string value = gameLogic.checkGuess(numberCode, guess);
            Assert.AreEqual("BB,C", value);
        }

        private string Mock4DigitNumber()
        {
            return "1234";
        }
    }
}