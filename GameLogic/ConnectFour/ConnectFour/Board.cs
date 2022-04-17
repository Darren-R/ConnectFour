using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Board
    {
        private const int Rows = 6, Columns = 7;
        public Piece[,] gameBoard = new Piece[Rows, Columns];

        public bool winCondition(int col, String winId)
        {
            bool winner = false;

            for (int i = 0; i < Rows; i++)
            {
                if(gameBoard[i, col] != null)
                {
                    int howManyInARow = 3;
                    for (int checkVertical = i + 1; checkVertical < Rows; checkVertical++)
                    {
                        if (gameBoard[checkVertical, col].getId() == winId)
                        {
                            howManyInARow--;
                            if (howManyInARow == 0)
                            {
                                winner = true;
                            }
                        }
                        else
                        {
                            howManyInARow = 3;
                        }
                    }
                    howManyInARow = 4;
                    for(int checkHorizontal = col - 3; checkHorizontal <= Columns; checkHorizontal++)
                    {
                        if(checkHorizontal < 0)
                        {
                            continue;
                        }
                        if(checkHorizontal >= Columns)
                        {
                            break;
                        }
                        if (gameBoard[i, checkHorizontal] != null && gameBoard[i, checkHorizontal].getId() == winId)
                        {
                            howManyInARow--;
                            if (howManyInARow == 0)
                            {
                                winner = true;
                            }
                        }
                        else
                        {
                            howManyInARow = 4;
                        }
                    }
                    howManyInARow = 4;

                    
                    break;
                }
            }
            return winner;
        }
        public bool placePiece(int colPlacing, String playerId)
        {
            if (colPlacing >= 0 && colPlacing < Columns)
            { 
                if(gameBoard[0, colPlacing] == null)
                {
                    for(int i = Rows - 1; i >= 0; i--)
                    {
                        if(gameBoard[i, colPlacing] == null)
                        {
                            gameBoard[i, colPlacing] = new Piece();
                            gameBoard[i, colPlacing].setId(playerId);
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    System.Console.WriteLine("Please input valid move");
                    return false;
                }
            }
            else
            {
                System.Console.WriteLine("Please input valid move");
                return false;
            }
        }
        public void printBoard()
        {
            Console.WriteLine("##CONNECT FOUR##");
            Console.WriteLine();
            for (int i = 0; i < Rows; i++)
            {
                Console.Write("|");
                for (int j = 0; j < Columns; j++)
                { 
                    if(gameBoard[i, j] == null)
                    {
                        Console.Write('_');
                    }
                    else
                    {
                        Console.Write(gameBoard[i,j].getId());
                    }
                    Console.Write("|");
                }
                if (i + 1 == Rows)
                {
                    Console.WriteLine();
                    for (int j = 0; j < Columns; j++)
                    {
                        Console.Write(" {0}", j + 1);
                    }
                }

                Console.WriteLine();
            }
        }
        public Board()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    gameBoard[i, j] = null;
                }
            }
        }
        public static int getColumns() { return Columns; }
        public static int getRows() { return Rows; }
    }
}
