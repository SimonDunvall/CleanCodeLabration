using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class MenuController
    {
        private IUI ui;
        private Menu menu;
        private ScoreBoard scoreBoard;

        public MenuController(IUI ui, Menu menu, ScoreBoard scoreBoard)
        {
            this.ui = ui;
            this.menu = menu;
            this.scoreBoard = scoreBoard;
        }

        internal void Run()
        {
            bool IsGameChosen;
            do
            {
                ui.DisplayString("Do you want to play Moogame or Mastermind?\n");
                string input = ui.GetString().Trim().ToLower();
                IsGameChosen = choseGame(input);
            } while (!IsGameChosen);
            menu.StartGame(ui, scoreBoard);
        }

        private bool choseGame(string input)
        {
            if (input == "moogame")
            {
                menu.SetGame(new MooGame(ui));
                return true;
            }
            else if (input == "mastermind")
            {
                menu.SetGame(new MasterMind(ui));
                return true;
            }
            return false;
        }
    }
}