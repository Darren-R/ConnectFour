
namespace Game
{
    [Serializable]
    class ConnectFourGame : Game
    {
        private ConnectFourBoard board;
        private List<ConnectFourBoard> previousBoards = new List<ConnectFourBoard>();

        public override IGameBoards saveGame()
        {
            return board;
        }
        public bool winConditions(int col) 
        {
            String winId = playerOneTurn ? IdOne : IdTwo;
            return board.winCondition(col, winId);
        }
        public ConnectFourGame(String playerOne, String playerTwo, bool computer)
        {
            board = new ConnectFourBoard();
            IdOne = playerOne;
            IdTwo = playerTwo;
            computerPlayer = computer;


            var rand = new Random();

            playerOneTurn = rand.Next(2) == 1;
        }

        public void startGame()
        {
            bool gameIsRunning = true;
            while (gameIsRunning)
            {
                int choice;
                board.printBoard();
                String Id;
                if (playerOneTurn)
                {
                    Id = IdOne;
                    Console.WriteLine("\nPlayer One's turn");
                    choice = ConnectFourMenu.GameMenu();
                }
                else if (computerPlayer == true && !playerOneTurn)
                {
                    Id = IdTwo;
                    Console.WriteLine("\nComputer Player Two's turn");
                    var rand = new Random();
                    choice = rand.Next(2, 7);
                }
                else
                {
                    Id = IdTwo;
                    Console.WriteLine("\nPlayer Two's turn");
                    choice = ConnectFourMenu.GameMenu();
                }

                if (choice == 0)
                {
                    if(previousBoards.Count > 0)
                    {
                        board = null;
                        board = new ConnectFourBoard();
                        board = previousBoards[previousBoards.Count - 1];
                        if(previousBoards.Any())
                        {
                            previousBoards.RemoveAt(previousBoards.Count - 1);
                        }
                        continue;
                    }
                    else if (previousBoards.Count == 0)
                    {
                        board = null;
                        board = new ConnectFourBoard();
                    }
                    else
                    {
                        continue;
                    }
                    
                }

                bool availableMove = board.placePiece(choice - 1, Id);
                if (availableMove)
                {
                    ConnectFourBoard copy = Undo.DeepClone(board);
                    previousBoards.Add(copy);

                    if (winConditions(choice - 1))
                    {
                        board.printBoard();
                        Console.WriteLine();
                        gameIsRunning = false;
                        if (playerOneTurn)
                        {
                            Console.WriteLine("Player one wins!!");
                            
                        }
                        else if (computerPlayer == true && !playerOneTurn)
                        {
                            Console.WriteLine("Computer Player two wins!!");
                        }
                        else
                        {
                            Console.WriteLine("Player two wins!!");
                        }
                    }
                    playerOneTurn = !playerOneTurn;
                }
            }
        }
    }
}
