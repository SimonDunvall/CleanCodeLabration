using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class GameLogic
    {
        public string make4DigitNumber()
        {
            Random randomGenerator = new Random();
            string numberCode = "";
            while (numberCode.Length < 4)
            {
                string randomDigit;
                do
                {
                    randomDigit = randomGenerator.Next(10).ToString();
                } while (numberCode.Contains(randomDigit));
                numberCode += randomDigit;
            }
            return numberCode;
        }

        public string checkGuess(string numberCode, string guess)
        {
            int numberOfCs = 0, numberOfBs = 0;
            guess += "    ";     // if player entered less than 4 chars
            foreach (char digit in guess)
            {
                if (numberCode.Contains(digit))
                {
                    int index = guess.IndexOf(digit);
                    if (numberCode[index] == digit)
                    {
                        numberOfBs++;
                    }
                    else
                    {
                        numberOfCs++;
                    }
                }
            }
            return "BBBB".Substring(0, numberOfBs) + "," + "CCCC".Substring(0, numberOfCs);
        }
    }
}