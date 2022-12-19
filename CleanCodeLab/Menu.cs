using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        internal void StartGame(IUI ui, string game)
        {
            if (gameLogic == null)
            {
                throw new NullReferenceException();
            }
            ScoreBoard s = new ScoreBoard(ui, game);
            GameController controller = new GameController(ui, s, gameLogic);
            controller.Run();
        }
    }
}