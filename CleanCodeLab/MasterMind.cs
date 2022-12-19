using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class MasterMind : IGameLogic
    {
        public string checkGuess(string code, string guess)
        {
            string result = "|";
            string[] guessedColors = guess.Split(new string[] { ", " }, StringSplitOptions.None);
            string[] codeColors = code.Split(new string[] { ", " }, StringSplitOptions.None);
            for (int index = 0; index < 5; index++)
            {
                if (codeColors[index] == guessedColors[index].ToLower())
                {
                    result += "B|";
                }
                else if (codeColors.Contains(guessedColors[index].ToLower()))
                {
                    result += "C|";
                }
                else
                {
                    result += " |";
                }
            }
            return result;
        }

        public string generateRandomCode()
        {
            Random rnd = new Random();
            string[] colors = { "red", "green", "white", "orange", "black", "blue", "yellow", "brown" };
            List<string> code = new List<string>();
            while (code.Count() < 5)
            {
                int index = rnd.Next(colors.Count());
                string choosenColor = colors[index];
                code.Add(choosenColor);
            }
            return ToString(code);
        }

        private string ToString(List<string> code)
        {
            return string.Join(", ", code);
        }

        public string exampleGuess()
        {
            return "black, white, red, blue, orange";
        }

        public string correctGuess()
        {
            return "|B|B|B|B|B|";
        }
    }
}