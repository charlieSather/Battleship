using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectThreeBattleship
{
    class Board
    {
        int rows;
        int columns;
        char[,] board;
        // Dictionary<int, char> letters = new Dictionary<int, char>
        //{
        //   0,'A',
        // };

        public Board()
        {
            rows = 20;
            columns = 20;
            board = new char[rows, columns];
        }

        public void printBoardIndices()
        {
            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    if(j == columns - 1)
                    {
                        Console.WriteLine($"{i}{j}");
                    }
                    else
                    {
                        Console.Write($"{i}{j}, ");
                    }
                }
            }
        }

        public void printBoard()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (j == columns - 1)
                    {
                        Console.WriteLine(board[i,j]);
                    }
                    else
                    {
                        Console.Write($"{board[i, j]} ");
                    }
                }
            }
        }

        public void setupBoard()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    board[i, j] = '-';
                }
            }
        }

    }
}
