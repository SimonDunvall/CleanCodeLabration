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
            string answer;

            ui.DisplayString("Enter your user name:\n");
            string playerName = ui.GetString();

            do
            {
                int nGuess = handleGame();

                handleStatistics(playerName, nGuess);

                ui.DisplayString("Correct, it took " + nGuess + " guesses\nContinue?");
                answer = ui.GetString();
            } while (answer != null && answer != "" && answer.Substring(0, 1) != "n");
        }

        private void handleStatistics(string playerName, int nGuess)
        {
            scoreBoard.AddData(playerName, nGuess);
            scoreBoard.showScoreBoard();
        }

        private int handleGame()
        {
            string numberCode = gameLogic.make4DigitNumber();

            ui.DisplayString("New game:\n");
            //comment out or remove next line to play real games!
            ui.DisplayString("For practice, number is: " + numberCode + "\n");
            string guess = ui.GetString();


            int nGuess = 1;
            string checkedGuess = gameLogic.checkGuess(numberCode, guess);
            ui.DisplayString(checkedGuess + "\n");

            while (checkedGuess != "BBBB,")
            {
                nGuess++;
                guess = ui.GetString();
                ui.DisplayString(guess + "\n");
                checkedGuess = gameLogic.checkGuess(numberCode, guess);
                ui.DisplayString(checkedGuess + "\n");
            }

            return nGuess;
        }
    }
}