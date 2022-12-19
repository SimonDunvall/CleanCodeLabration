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
            IGameLogic mooGame = new MooGame(ui);
            IGameLogic masterMind = new MasterMind(ui);
            GameController controller = new GameController(ui, scoreBoard, masterMind);
            controller.Run();
        }
    }
}