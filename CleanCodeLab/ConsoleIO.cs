using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class ConsoleIO : IUI
    {
        public string GetString()
        {
            string? s = Console.ReadLine();
            if (s == null)
                return "";
            else
                return s;
        }

        public void WriteString(string s)
        {
            Console.WriteLine(s);
        }
    }
}