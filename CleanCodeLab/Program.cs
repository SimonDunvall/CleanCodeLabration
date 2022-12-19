using System;
using System.IO;
using System.Collections.Generic;

namespace CleanCodeLab
{
    class Program
    {

        public static void Main(string[] args)
        {
            IUI ui = new ConsoleIO();
            ScoreBoard scoreBoard = new ScoreBoard(ui);
            Menu menu = new Menu();
            MenuController controller = new MenuController(ui, menu, scoreBoard);
            controller.Run();
        }
    }
}