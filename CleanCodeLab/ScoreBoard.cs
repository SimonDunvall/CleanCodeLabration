using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class ScoreBoard : IDataBase
    {
        private IUI ui;
        private readonly string game;

        public ScoreBoard(IUI ui, string game)
        {
            this.ui = ui;
            this.game = game;
        }

        public void DisplayData()
        {
            displayScoreBoard(getData());
        }

        public void AddData(string playerName, int nGuess)
        {
            StreamWriter output = new StreamWriter("result.txt", append: true);
            output.WriteLine(game + "#&#" + playerName + "#&#" + nGuess);
            output.Close();
        }

        private void displayScoreBoard(List<PlayerData> results)
        {
            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            ui.DisplayString("Player   games average");
            foreach (PlayerData p in results)
            {
                ui.DisplayString(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
            }
        }

        private List<PlayerData> getData()
        {
            StreamReader input = new StreamReader("result.txt");
            List<PlayerData> results = ConvertToPlayerDataList(input);
            input.Close();
            return results;
        }

        private List<PlayerData> ConvertToPlayerDataList(StreamReader input)
        {
            List<PlayerData> results = new List<PlayerData>();
            string? line;
            while ((line = input.ReadLine()) != null)
            {
                PlayerData pd = CreatePlayerFromString(line);

                if (pd.Game != game)
                {
                    continue;
                }
                int pos = results.IndexOf(pd);
                if (pos < 0)
                {
                    results.Add(pd);
                }
                else
                {
                    results[pos].Update(pd.totalGuess);
                }
            }
            return results;
        }

        private PlayerData CreatePlayerFromString(string line)
        {
            string[] gameNameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
            string game = gameNameAndScore[0];
            string playerName = gameNameAndScore[1];
            int guesses = Convert.ToInt32(gameNameAndScore[2]);
            return new PlayerData(playerName, guesses, game);
        }
    }
}