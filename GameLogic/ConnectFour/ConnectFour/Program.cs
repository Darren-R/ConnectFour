namespace Game
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Start Menu");
            Console.WriteLine("1: Play with humans");
            Console.WriteLine("2: Play with AI");
            Console.WriteLine("3: Load previous game");
            Console.WriteLine("4: Quit\n");

            int choice = UserChoice.NumberRequested("Menu Choice");
            switch (choice)
            {
                case 1:
                    Game newGame = new Game("X", "O");
                    newGame.startGame();
                    break;
                case 2:
                    Console.WriteLine("In development");
                    break;
                case 3:
                    Console.WriteLine("In development");
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}