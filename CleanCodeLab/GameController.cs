namespace CleanCodeLab
{
    public class GameController
    {
        private IUI ui;
        private IDataBase scoreBoard;
        private IGameLogic gameLogic;

        public GameController(IUI ui, IDataBase s, IGameLogic g)
        {
            this.ui = ui;
            scoreBoard = s;
            gameLogic = g;
        }

        public void StartGame()
        {
            string play;
            ui.DisplayString("Enter your user name:\n");
            string playerName = ui.GetString();
            do
            {
                display();
                int nGuess = handleGame();
                handleStatistics(playerName, nGuess);
                ui.DisplayString("Correct, it took " + nGuess + " guesses\nContinue?");
                play = ui.GetString();
            } while (play != null && play != "" && play.Substring(0, 1) != "n");
        }

        private void handleStatistics(string playerName, int nGuess)
        {
            scoreBoard.AddData(playerName, nGuess);
            scoreBoard.DisplayData();
        }

        private int handleGame()
        {
            string code = gameLogic.GenerateRandomCode();
            //comment out or remove next line to play real games!
            ui.DisplayString("For practice, code is: " + code + "\n");
            int nGuess = runGameLogic(code);
            return nGuess;
        }

        private int runGameLogic(string code)
        {
            int nGuess = 0;
            string checkedGuess;
            do
            {
                nGuess++;
                string guess = ui.GetString().Trim();
                ui.DisplayString(guess + "\n");
                checkedGuess = gameLogic.CheckGuess(code, guess);
                ui.DisplayString(checkedGuess + "\n");
            } while (checkedGuess != gameLogic.CorrectGuess());
            return nGuess;
        }

        private void display()
        {
            ui.DisplayString("New game:");
            ui.DisplayString($"guess example: {gameLogic.ExampleGuess()} \n");
        }
    }
}