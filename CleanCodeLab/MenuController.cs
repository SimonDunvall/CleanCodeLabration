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
            string choosenGame;
            do
            {
                ui.DisplayString("Do you want to play Moogame or Mastermind?\n");
                choosenGame = ui.GetString().Trim().ToLower();
                IsGameChosen = choseGame(choosenGame);
            } while (!IsGameChosen);
            menu.RunGame(ui, choosenGame);
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