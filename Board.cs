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
        public Dictionary<string, int> lettersToIndex = new Dictionary<string, int>
        {
            {"A",  0 },
            {"B", 1 },
            {"C", 2 },
            {"D", 3 },
            {"E", 4 },
            {"F", 5 },
            {"G", 6 },
            {"H", 7 },
            {"I", 8 },
            {"J", 9 },
            {"K", 10 },
            {"L", 11 },
            {"M", 12 },
            {"N", 13 },
            {"O", 14 },
            {"P", 15 },
            {"Q", 16 },
            {"R", 17 },
            {"S", 18 },
            {"T", 19 },
        };

        public Dictionary<int, string> intsToLetters = new Dictionary<int, string>
        {
            { 0, "A" },
            { 1, "B" },
            { 2, "C" },
            { 3, "D" },
            { 4, "E" },
            { 5, "F" },
            { 6, "G" },
            { 7, "H" },
            { 8, "I" },
            { 9, "J" },
            { 10, "K" },
            { 11, "L" },
            { 12, "M" },
            { 13, "N" },
            { 14, "O" },
            { 15, "P" },
            { 16, "Q" },
            { 17, "R" },
            { 18, "S" },
            { 19, "T" },
        };

        //Tuple essentially represents an object

        public Dictionary<string, (int, int)> map = new Dictionary<string, (int, int)>();

        public Board()
        {
            rows = 20;
            columns = 20;
            board = new char[rows, columns];
            setupBoard();
            initMap();
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
            Console.Clear();
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
                Console.Write(intsToLetters[i] + " ");
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

        public void DrawShip(Ship ship, (string, string) startEnd)
        {

            (int, int) startIndex = GetIndices(startEnd.Item1);
            (int, int) endIndex = GetIndices(startEnd.Item2);

            if(startIndex.Item1 == endIndex.Item1)
            {
                if (startIndex.Item2 < endIndex.Item2)
                {
                    for (int i = startIndex.Item2; i <= endIndex.Item2; i++)
                    {
                        board[startIndex.Item1, i] = ship.name[0];
                        ship.AddCoordinate("" + intsToLetters[startIndex.Item1] + (i + 1));
                    }
                }
                else
                {
                    for (int i = startIndex.Item2; i >= endIndex.Item2; i--)
                    {
                        board[startIndex.Item1, i] = ship.name[0];
                        ship.AddCoordinate("" + intsToLetters[startIndex.Item1] + (i + 1));
                    }
                }
            }
            else
            {
                if (startIndex.Item1 < endIndex.Item1)
                {
                    for (int i = startIndex.Item1; i <= endIndex.Item1; i++)
                    {
                        board[i, startIndex.Item2] = ship.name[0];
                        ship.AddCoordinate("" + intsToLetters[i] + (startIndex.Item2 + 1));
                    }
                }
                else
                {
                    for (int i = startIndex.Item1; i >= endIndex.Item1; i--)
                    {
                        board[i, startIndex.Item2] = ship.name[0];
                        ship.AddCoordinate("" + intsToLetters[i] + (startIndex.Item2 + 1));
                    }

                }
            }
        }

        public bool CanDraw(Ship ship, List<string> coordinates)
        {
            (int, int) startIndex = GetIndices(coordinates[0]);
            (int, int) endIndex = GetIndices(coordinates[1]);            
       
            if (startIndex.Item1 == endIndex.Item1)
            {
                if(Math.Abs(endIndex.Item2 - startIndex.Item2) == ship.size - 1)
                {
                    if(startIndex.Item2 < endIndex.Item2)
                    {
                        for (int i = startIndex.Item2; i <= endIndex.Item2; i++)
                        {
                            if(board[startIndex.Item1, i] != '-')
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                    else
                    {
                        for(int i = startIndex.Item2; i >= endIndex.Item2; i--)
                        {
                            if (board[startIndex.Item1, i] != '-')
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (startIndex.Item2 == endIndex.Item2)
            {
                if(Math.Abs(endIndex.Item1 - startIndex.Item1) == ship.size - 1)
                {
                    if(startIndex.Item1 < endIndex.Item1)
                    {
                        for (int i = startIndex.Item1; i <= endIndex.Item1; i++)
                        {
                            if (board[i, startIndex.Item2] != '-')
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                    else
                    {
                        for (int i = startIndex.Item1; i >= endIndex.Item1; i--)
                        {
                            if (board[i, startIndex.Item2] != '-')
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public bool CheckFirstIndex(string input)
        {
            if(input.Length <= 1)
            {
                return true;
            }
            return input[0] == input[1] ? CheckFirstIndex(input.Substring(1)) : false;
        }
        
        public (int, int) GetIndices(string coordinate)
        {
            if (map.ContainsKey(coordinate))
            {
                return map[coordinate];
            }
            else
            {
                return (0,0);
            }
        }
        public string GetCoordinate((int,int) indices)
        {
            return "" + intsToLetters[indices.Item1] + indices.Item2;
        }


        //A has ascii code 65, T has 84.
        //ascii int range (65-84)

        public void initMap()
        {
            // asciiChar reprents A in ascii code
            int asciiChar = 65;
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    map.Add(("" + (char) asciiChar).ToString() + (j + 1), (i, j));                    
                }
                asciiChar++;
            }
        }

        public bool TileIsEmpty(string coordinate)
        {
            (int, int) indices = GetIndices(coordinate);
            return board[indices.Item1, indices.Item2] == '-' ? true : false;
        }
        public void DrawHit(string coordinate)
        {
            (int, int) indices = GetIndices(coordinate);
            board[indices.Item1, indices.Item2] = 'X';
        }
        public void DrawMiss(string coordinate)
        {
            (int, int) indices = GetIndices(coordinate);
            board[indices.Item1, indices.Item2] = 'O';
        }
    }
}
