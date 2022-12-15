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
            GameLogic gameLogic = new GameLogic();
            Controller controller = new Controller(ui, scoreBoard, gameLogic);
            controller.RunGame();
        }
    }
}