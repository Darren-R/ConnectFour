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
                        HelpMenu();
                        break;
                    case 3:
                        Console.WriteLine("\nIn development");
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
                    default:
                        Console.WriteLine("\nEnter Valid Choice");
                        GameMenu();
                        break;
                }
            }
            return choice;
        }
        public static void HelpMenu()
        {
            Console.WriteLine("\n###CONNECT FOUR###");
            Console.WriteLine("\nConnect Four (also known as Four Up, Plot Four, Find Four, Captain's Mistress, " +
                "Four in a Row, Drop Four, and Gravitrips in the Soviet Union) is a two-player connection board game, " +
                "in which the players choose a color and then take turns dropping colored tokens into a seven-column, six-row " +
                "vertically suspended grid. The pieces fall straight down, occupying the lowest available space within the column. " +
                "The objective of the game is to be the first to form a horizontal, vertical, or diagonal line of four of one's own tokens.\n" +
                "Connect four is a solved game, lets see if you can figure it out. \n");
            Console.WriteLine("In the in game menu we have the following choices;" +
                "\nTo access each choice you press the number on the left\n" +
                "\n1: Make a move. In this move we press the column where we would like to drop our piece from the top of the board." +
                "\n2: Access help menu. This is where we are now." +
                "\n3: Undo move. This takes back your previous move" +
                "\n4: Save game. This saves a game, you will be able to load it again on the game load screen" +
                "\n5: Quit. Immediately exit game.");
            GameMenu();
        }
    }
}
