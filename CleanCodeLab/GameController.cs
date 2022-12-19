using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class GameController
    {
        private IUI ui;
        private ScoreBoard scoreBoard;
        private IGameLogic gameLogic;

        public GameController(IUI ui, ScoreBoard s, IGameLogic g)
        {
            this.ui = ui;
            scoreBoard = s;
            gameLogic = g;
        }

        public void Run()
        {
            string answer;

            ui.DisplayString("Enter your user name:\n");
            string playerName = ui.GetString();

            do
            {
                display();

                int nGuess = handleGame();

                handleStatistics(playerName, nGuess);

                ui.DisplayString("Correct, it took " + nGuess + " guesses\nContinue?");
                answer = ui.GetString();
            } while (answer != null && answer != "" && answer.Substring(0, 1) != "n");
        }

        private void display()
        {
            ui.DisplayString("New game:");
            ui.DisplayString($"guess example: {gameLogic.exampleGuess()} \n");
        }

        private void handleStatistics(string playerName, int nGuess)
        {
            scoreBoard.AddData(playerName, nGuess);
            scoreBoard.showScoreBoard();
        }

        private int handleGame()
        {
            string code = gameLogic.GenerateRandomCode();

            //comment out or remove next line to play real games!
            ui.DisplayString("For practice, code is: " + code + "\n");

            int nGuess = gameLogic.RunGame(code);

            return nGuess;
        }
    }
}