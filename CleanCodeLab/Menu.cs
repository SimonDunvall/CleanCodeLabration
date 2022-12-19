namespace CleanCodeLab
{
    public class Menu
    {
        private IGameLogic? gameLogic;

        public Menu()
        {
        }

        public Menu(IGameLogic gameLogic)
        {
            this.gameLogic = gameLogic;
        }


        public void SetGame(IGameLogic gameLogic)
        {
            this.gameLogic = gameLogic;
        }

        internal void RunGame(IUI ui, string game)
        {
            if (gameLogic == null)
            {
                throw new NullReferenceException();
            }
            IScoreBoard scoreBoard = new ScoreBoard(ui, game); //dp injected game so that scoreboard knows with games scoreboard to use
            GameController controller = new GameController(ui, scoreBoard, gameLogic);
            controller.StartGame();
        }
    }
}