using System;
using System.IO;
using System.Collections.Generic;

namespace CleanCodeLab
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.RunGame();
        }
    }
}