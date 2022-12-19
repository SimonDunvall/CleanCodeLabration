namespace CleanCodeLab
{
    public interface IGameLogic
    {
        string checkGuess(string numberCode, string guess);
        string GenerateRandomCode();
        int RunGame(string numberCode);
    }
}