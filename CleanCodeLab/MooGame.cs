using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCodeLab
{

    public class MooGame : IGameLogic
    {
        private IUI ui;

        public MooGame(IUI ui)
        {
            this.ui = ui;
        }

        public string GenerateRandomCode()
        {
            Random rnd = new Random();
            string code = "";
            while (code.Count() < 4)
            {
                string randomDigit;
                do
                {
                    randomDigit = rnd.Next(10).ToString();
                } while (code.Contains(randomDigit));
                code += randomDigit;
            }
            return code;
        }

        public string checkGuess(string code, string guess)
        {
            int numberOfCs = 0, numberOfBs = 0;
            guess += "    ";     // if player entered less than 4 chars
            foreach (char digit in guess)
            {
                if (code.Contains(digit))
                {
                    int index = guess.IndexOf(digit);
                    if (code[index] == digit)
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

        public int RunGame(string code)
        {
            int nGuess = 0;
            string checkedGuess;
            do
            {
                nGuess++;
                string guess = ui.GetString().Trim();
                ui.DisplayString(guess + "\n");
                checkedGuess = checkGuess(code, guess);
                ui.DisplayString(checkedGuess + "\n");

            } while (checkedGuess != "BBBB,");

            return nGuess;
        }

        private void Input()
        {
            throw new NotImplementedException();
        }

        public string exampleGuess()
        {
            return "1234";
        }
    }
}