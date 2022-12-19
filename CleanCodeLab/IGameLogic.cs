namespace CleanCodeLab
{
    public interface IGameLogic
    {
        string CheckGuess(string code, string guess);
        string CorrectGuess();
        string ExampleGuess();
        string GenerateRandomCode();
    }
}