namespace Game
{
    class Program
    {
        public static void Main(string[] args)
        {
            Game newGame = new Game("X", "O");
            newGame.startGame();
        }
    }
}