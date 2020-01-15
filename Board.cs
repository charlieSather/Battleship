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
        //public void DrawShips(Ship ships)
        //{
        //    foreach(Ship ship in ships)
        //    {
        //        foreach (string coord in ship.coordinates)
        //        {
        //            board[map[coord].Item1, map[coord].Item2] = 'S';
        //        }
        //    }
        //}
        public void DrawShip(Ship ship)
        {
            foreach(string coord in ship.coordinates)
            {
                board[map[coord].Item1, map[coord].Item2] = 'S';
            }
        }


        //public void DrawShip(Ship ship)
        //{
        //    foreach(string coord in ship.coordinates)
        //    {
        //        board[lettersToIndex[coord[0].ToString()], int.Parse(coord[1].ToString()) - 1] = 'S';
        //    }

        //}

        public bool DoCoordinatesLink(string coordinateOne, string coordinateTwo, Ship ship)
        {
            bool linked = false;

            try
            {
                if (coordinateOne[0] == coordinateTwo[0])
                {
                    if (Math.Abs(int.Parse(coordinateTwo[1].ToString()) - int.Parse(coordinateOne[1].ToString())) < ship.size)
                    {
                        linked = true;
                    }
                }
                else if (int.Parse(coordinateOne[1].ToString()) == int.Parse(coordinateTwo[1].ToString()))
                {
                    if (Math.Abs(lettersToIndex[coordinateTwo[0].ToString()] - lettersToIndex[coordinateOne[0].ToString()]) < ship.size)
                    {
                        linked = true;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
              
            return linked;
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

    }
}
