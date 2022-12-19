namespace CleanCodeLab
{
    class PlayerData
    {
        public string Name { get; private set; }
        public int NGames { get; private set; }
        public string Game { get; set; }
        public int totalGuess;


        public PlayerData(string name, int guesses, string game)
        {
            this.Name = name;
            NGames = 1;
            totalGuess = guesses;
            this.Game = game;
        }

        public void Update(int guesses)
        {
            totalGuess += guesses;
            NGames++;
        }

        public double Average()
        {
            return (double)totalGuess / NGames;
        }

        public override bool Equals(Object p)
        {
            return Name.Equals(((PlayerData)p).Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}