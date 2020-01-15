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
        Dictionary<string, int> lettersToInts = new Dictionary<string, int>
        {
            {"A",  1 },
            {"B", 2 },
            {"C", 3 },
            {"D", 4 },
            {"E", 5 },
            {"F", 6 },
            {"G", 7 },
            {"H", 8 },
            {"I", 9 },
            {"J", 10 },
            {"K", 11 },
            {"L", 12 },
            {"M", 13 },
            {"N", 14 },
            {"O", 15 },
            {"P", 16 },
            {"Q", 17 },
            {"R", 18 },
            {"S", 19 },
            {"T", 20 },
        };
        Dictionary<int, string> intsToLetters = new Dictionary<int, string>
        {
            { 1, "A" },
            { 2, "B" },
            { 3, "C" },
            { 4, "D" },
            { 5, "E" },
            { 6, "F" },
            { 7, "G" },
            { 8, "H" },
            { 9, "I" },
            { 10, "J" },
            { 11, "K" },
            { 12, "L" },
            { 13, "M" },
            { 14, "N" },
            { 15, "O" },
            { 16, "P" },
            { 17, "Q" },
            { 18, "R" },
            { 19, "S" },
            { 20, "T" },
        };

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

            for(int s = 0; s < rows + 1; s++)
            {
                if(s == 0)
                {
                    Console.Write("  ");
                }
                else if(s < rows)
                {
                    Console.Write(s + " ");
                }
                else
                {
                    Console.WriteLine(s);
                }
            }

            for (int i = 0; i < rows; i++)
            {
                Console.Write(intsToLetters[i + 1] + " ");
                for (int j = 0; j < columns; j++)
                {
                    if (j == columns - 1)
                    {
                        Console.WriteLine(" " + board[i,j]);
                    }
                    else
                    {
                        if(j > 9)
                        {
                            Console.Write($" {board[i, j]} ");
                        }
                        else
                        {
                            Console.Write($"{board[i, j]} ");
                        }
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
