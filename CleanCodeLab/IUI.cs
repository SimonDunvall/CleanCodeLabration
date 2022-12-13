using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public interface IUI
    {
        string GetString();
        void WriteString(string s);
        void Quit();
    }
}