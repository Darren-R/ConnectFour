namespace Game
{
    public class Menu
    {
        public static int GameMenu()
        {
            Console.WriteLine();

            Console.WriteLine("Connect Four Menu:");
            Console.WriteLine("1: Make a move");
            Console.WriteLine("2: Access help menu");
            Console.WriteLine("3: Undo move");
            Console.WriteLine("4: Save game");
            Console.WriteLine("5: Quit");

            int choice = UserChoice.NumberRequested("Menu Choice");
            {
                switch(choice)
                {
                    case 1:
                        return choice = UserChoice.NumberRequested("a piece between 1 and 7");
                    case 2:
                        Console.WriteLine("In development");
                        GameMenu();
                        break;
                    case 3:
                        Console.WriteLine("In development");
                        GameMenu();
                        break;
                    case 4:
                        Game testGame = new Game("Y", "T", false);
                        SaveOrLoad savingGame = new SaveOrLoad();
                        savingGame.saveGame(testGame);
                        Console.WriteLine("\nGame is now saved");
                        GameMenu();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
            return choice;
        }
    }
}
