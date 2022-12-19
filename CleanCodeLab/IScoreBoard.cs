namespace CleanCodeLab
{
    public interface IScoreBoard
    {
        void AddData(string playerName, int nGuess);
        void DisplayData();
    }
}