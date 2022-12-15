using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class Controller
    {
        private IUI ui;
        private ScoreBoard scoreBoard;
        private GameLogic gameLogic;

        public Controller(IUI ui, ScoreBoard s, GameLogic g)
        {
            this.ui = ui;
            scoreBoard = s;
            gameLogic = g;
        }

        public void RunGame()
        {
            bool playOn = true;
            string playerName = startMeny();

            while (playOn)
            {
                int nGuess = game();


                scoreBoard.Statistics(playerName, nGuess, ui);

                ui.WriteString("Correct, it took " + nGuess + " guesses\nContinue?");
                string answer = ui.GetString();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    ui.Quit();
                }
            }
        }

        private int game()
        {
            string numberCode = gameLogic.make4DigitNumber();

            dispay(numberCode);
            string guess = ui.GetString();



            int nGuess = 1;
            string checkedGuess = gameLogic.checkGuess(numberCode, guess);
            ui.WriteString(checkedGuess + "\n");

            while (checkedGuess != "BBBB,")
            {
                nGuess++;
                guess = ui.GetString();
                ui.WriteString(guess + "\n");
                checkedGuess = gameLogic.checkGuess(numberCode, guess);
                ui.WriteString(checkedGuess + "\n");
            }

            return nGuess;
        }

        private void dispay(string numberCode)
        {
            ui.WriteString("New game:\n");
            //comment out or remove next line to play real games!
            ui.WriteString("For practice, number is: " + numberCode + "\n");
        }

        private string startMeny()
        {
            ui.WriteString("Enter your user name:\n");
            return ui.GetString();
        }
    }
}