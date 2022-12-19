namespace CleanCodeLab
{
    public interface IGameLogic
    {
        string checkGuess(string code, string guess);
        string correctGuess();
        string exampleGuess();
        string generateRandomCode();
    }
}