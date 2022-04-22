using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    class Game
    {
        public Board board;
        private String IdOne;
        private String IdTwo;
        private bool playerOneTurn;
        private bool computerPlayer;
        private List<Board> previousBoards = new List<Board>();

        public List<Board> PreviousBoards
        {
            get { return previousBoards; }
            set { previousBoards = value; }
        }
        
        public List<Board> getList()
        { 
            return previousBoards;
        }
        
        public bool winConditions(int col) 
        {
            String winId = playerOneTurn ? IdOne : IdTwo;
            return board.winCondition(col, winId);
        }
        public Game(String playerOne, String playerTwo, bool computer)
        {
            board = new Board();
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
                    choice = Menu.GameMenu();
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
                    choice = Menu.GameMenu();
                }
                if (choice == 0)
                {
                    if(previousBoards.Count > 0)
                    {
                        board = null;
                        board = new Board();
                        board = previousBoards[previousBoards.Count - 1];
                        board.printBoard();
                        if(previousBoards.Any())
                        {
                            previousBoards.RemoveAt(previousBoards.Count - 1);
                        }
                        continue;
                    }
                    else if (previousBoards.Count == 0)
                    {
                        board = null;
                        board = new Board();
                        board.printBoard();
                    }
                    else
                    {
                        board.printBoard();
                        continue;
                    }

                    /*
                    foreach(Board b in previousBoards)
                    {
                        b.printBoard();
                    }
                    */
                    
                }
                bool availableMove = board.placePiece(choice - 1, Id);
                if (availableMove)
                {
                    Board copy = Undo.DeepClone(board);
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
