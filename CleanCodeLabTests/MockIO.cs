using CleanCodeLab;

namespace CleanCodeLabTests
{
    public class MockIO : IUI
    {
        public void DisplayString(string s)
        {
            throw new NotImplementedException();
        }

        public string GetString()
        {
            return "1253";
        }
    }
}