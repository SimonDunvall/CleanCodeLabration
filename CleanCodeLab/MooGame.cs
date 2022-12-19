namespace CleanCodeLab
{

    public class MooGame : IGameLogic
    {
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

        public string CheckGuess(string code, string guess)
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

        public string ExampleGuess()
        {
            return "1234";
        }

        public string CorrectGuess()
        {
            return "BBBB,";
        }
    }
}