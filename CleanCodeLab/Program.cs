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
            Controller controller = new Controller(ui);
            controller.RunGame();
        }
    }
}