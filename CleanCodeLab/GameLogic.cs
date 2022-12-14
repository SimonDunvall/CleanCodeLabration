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
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(10);
                string randomDigit = "" + random;
                while (numberCode.Contains(randomDigit))
                {
                    random = randomGenerator.Next(10);
                    randomDigit = "" + random;
                }
                numberCode = numberCode + randomDigit;
            }
            return numberCode;
        }

        public string checkGuess(string numberCode, string guess)
        {
            int numberOfCs = 0, numberOfBs = 0;
            guess += "    ";     // if player entered less than 4 chars
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (numberCode[i] == guess[j])
                    {
                        if (i == j)
                        {
                            numberOfBs++;
                        }
                        else
                        {
                            numberOfCs++;
                        }
                    }
                }
            }
            return "BBBB".Substring(0, numberOfBs) + "," + "CCCC".Substring(0, numberOfCs);
        }
    }
}