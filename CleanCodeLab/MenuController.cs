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

        public MenuController(IUI ui, Menu menu)
        {
            this.ui = ui;
            this.menu = menu;
        }

        internal void Run()
        {
            bool IsGameChosen;
            string input;
            do
            {
                ui.DisplayString("Do you want to play Moogame or Mastermind?\n");
                input = ui.GetString().Trim().ToLower();
                IsGameChosen = choseGame(input);
            } while (!IsGameChosen);
            menu.StartGame(ui, input);
        }

        private bool choseGame(string input)
        {
            if (input == "moogame")
            {
                menu.SetGame(new MooGame());
                return true;
            }
            else if (input == "mastermind")
            {
                menu.SetGame(new MasterMind());
                return true;
            }
            return false;
        }
    }
}