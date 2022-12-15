using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class ScoreBoard
    {
        private IUI ui;

        public ScoreBoard(IUI ui)
        {
            this.ui = ui;
        }

        public void Statistics(string playerName, int nGuess)
        {
            StreamWriter output = new StreamWriter("result.txt", append: true);
            output.WriteLine(playerName + "#&#" + nGuess);
            output.Close();
            showScoreBoard(ui);
        }

        private void showScoreBoard(IUI ui)
        {
            StreamReader input = new StreamReader("result.txt");
            List<PlayerData> results = new List<PlayerData>();
            string? line;
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