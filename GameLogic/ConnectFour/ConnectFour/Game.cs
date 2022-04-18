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

        public bool winConditions(int col) 
        {
            bool winner = false;

            String winId = playerOneTurn ? IdOne : IdTwo;

            return board.winCondition(col, winId);
        }
        public Game(String playerOne, String PlayerTwo)
        {
            board = new Board();
            IdOne = playerOne;
            IdTwo = PlayerTwo;

            var rand = new Random();

            playerOneTurn = rand.Next(2) == 1;
        }

        public void startGame()
        {
            bool gameIsRunning = true;
            while (gameIsRunning)
            {
                board.printBoard();
                String Id;
                if (playerOneTurn)
                {
                    Id = IdOne;
                    Console.WriteLine("\nPlayer One's turn");
                }
                else
                {
                    Id = IdTwo;
                    Console.WriteLine("\nPlayer Two's turn");
                }

                int choice = Menu.GameMenu();

                bool availableMove = board.placePiece(choice - 1, Id);
                if (availableMove)
                {
                    if (winConditions(choice - 1))
                    {
                        board.printBoard();
                        Console.WriteLine();
                        gameIsRunning = false;
                        if (playerOneTurn)
                        {
                            Console.WriteLine("Player one wins!!");
                            
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
