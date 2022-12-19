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

        public void DisplayString(string s)
        {
            Console.WriteLine(s);
        }
    }
}