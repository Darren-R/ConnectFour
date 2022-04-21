using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    class Board
    {
        private const int Rows = 6, Columns = 7;
        public Piece[,] gameBoard = new Piece[Rows, Columns];

        public bool winCondition(int col, String winId)
        {
            bool winner = false;

            for (int row = 0; row < Rows; row++)
            { 
                if(gameBoard[row, col] != null)
                {
                    int howManyInARow = 3;

                    //Down
                    for (int winRow = row + 1; winRow < Rows; winRow++)
                    {
                        if(gameBoard[winRow, col].getId() == winId) 
                        { 
                            howManyInARow--; 
                            if(howManyInARow == 0)
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
                    //Across
                    for(int winCol = col - 3; winCol <= Columns; winCol++)
                    {
                        if(winCol < 0)
                        {
                            continue;
                        }
                        if (winCol >= Columns)
                        {
                            break;
                        }
                        if(gameBoard[row, winCol] != null && gameBoard[row, winCol].getId() == winId)
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

                    //Left Diagonal
                    for(int winRow = row - 3, winCol = col -3; winRow <= row + 3 && winCol <= col + 3; winRow++,winCol++)
                    {
                        if(winRow < 0 || winCol < 0)
                        {
                            continue;
                        }
                        if(winRow >= Rows || winCol >= Columns)
                        {
                            break;
                        }

                        if (gameBoard[winRow, winCol] != null && gameBoard[winRow, winCol].getId() == winId)
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

                    //Right Diagonal
                    for (int winRow = row - 3, winCol = col + 3; winRow <= row + 3 && winCol >= col - 3; winRow++, winCol--)
                    {
                        if (winRow < 0 || winCol >= Columns)
                        {
                            continue;
                        }
                        if (winRow >= Rows || winCol < 0)
                        {
                            break;
                        }

                        if (gameBoard[winRow, winCol] != null && gameBoard[winRow, winCol].getId() == winId)
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
