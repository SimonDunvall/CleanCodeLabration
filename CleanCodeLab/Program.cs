using System;
using System.IO;
using System.Collections.Generic;

namespace MooGame
{
    class MainClass
    {

        public static void Main(string[] args)
        {

            bool playOn = true;
            Console.WriteLine("Enter your user name:\n");
            string playerName = Console.ReadLine();

            while (playOn)
            {
                string numberCode = make4DigitNumber();


                Console.WriteLine("New game:\n");
                //comment out or remove next line to play real games!
                Console.WriteLine("For practice, number is: " + numberCode + "\n");
                string guess = Console.ReadLine();

                int nGuess = 1;
                string checkedGuess = checkGuess(numberCode, guess);
                Console.WriteLine(checkedGuess + "\n");
                while (checkedGuess != "BBBB,")
                {
                    nGuess++;
                    guess = Console.ReadLine();
                    Console.WriteLine(guess + "\n");
                    checkedGuess = checkGuess(numberCode, guess);
                    Console.WriteLine(checkedGuess + "\n");
                }
                StreamWriter output = new StreamWriter("result.txt", append: true);
                output.WriteLine(playerName + "#&#" + nGuess);
                output.Close();
                showScoreBoard();
                Console.WriteLine("Correct, it took " + nGuess + " guesses\nContinue?");
                string answer = Console.ReadLine();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    playOn = false;
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

        static void showScoreBoard()
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
            Console.WriteLine("Player   games average");
            foreach (PlayerData p in results)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
            }
            input.Close();
        }
    }
}