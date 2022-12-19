namespace CleanCodeLab
{
    public interface IGameLogic
    {
        string checkGuess(string code, string guess);
        string GenerateRandomCode();
        int RunGame(string code);
    }
}