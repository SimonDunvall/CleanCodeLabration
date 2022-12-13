using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class Controller
    {
        private IUI ui;

        public Controller(IUI ui)
        {
            this.ui = ui;
        }

        public void RunGame()
        {
            bool playOn = true;
            ui.WriteString("Enter your user name:\n");
            string playerName = ui.GetString();

            while (playOn)
            {
                string numberCode = make4DigitNumber();


                ui.WriteString("New game:\n");
                //comment out or remove next line to play real games!
                ui.WriteString("For practice, number is: " + numberCode + "\n");
                string guess = ui.GetString();

                int nGuess = 1;
                string checkedGuess = checkGuess(numberCode, guess);
                ui.WriteString(checkedGuess + "\n");
                while (checkedGuess != "BBBB,")
                {
                    nGuess++;
                    guess = ui.GetString();
                    ui.WriteString(guess + "\n");
                    checkedGuess = checkGuess(numberCode, guess);
                    ui.WriteString(checkedGuess + "\n");
                }
                StreamWriter output = new StreamWriter("result.txt", append: true);
                output.WriteLine(playerName + "#&#" + nGuess);
                output.Close();
                showScoreBoard(ui);
                ui.WriteString("Correct, it took " + nGuess + " guesses\nContinue?");
                string answer = ui.GetString();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    ui.Quit();
                }
            }
        }
        static string make4DigitNumber()
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

        static string checkGuess(string numberCode, string guess)
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

        static void showScoreBoard(IUI ui)
        {
            StreamReader input = new StreamReader("result.txt");
            List<PlayerData> results = new List<PlayerData>();
            string line;
            while ((line = input.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string playerName = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                PlayerData pd = new PlayerData(playerName, guesses);
                int pos = results.IndexOf(pd);
                if (pos < 0)
                {
                    results.Add(pd);
                }
                else
                {
                    results[pos].Update(guesses);
                }


            }
            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            ui.WriteString("Player   games average");
            foreach (PlayerData p in results)
            {
                ui.WriteString(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
            }
            input.Close();
        }
    }


}