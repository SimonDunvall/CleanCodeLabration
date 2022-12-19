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
            IDataBase scoreBoard = new ScoreBoard(ui, game);
            GameController controller = new GameController(ui, scoreBoard, gameLogic);
            controller.StartGame();
        }
    }
}