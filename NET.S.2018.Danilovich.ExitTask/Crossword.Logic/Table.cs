using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword.Logic
{
    public class Table
    {
        private char[,] board = new char[11, 11];

        public List<string> HorizontalWords = new List<string> { "перелом", "подвывих", "закрытый", "ушиб"};
        public List<Coordinate> HorizontalCoordinates  = new List<Coordinate>
        {
            new Coordinate(2, 0),
            new Coordinate(3, 4),
            new Coordinate(0, 7),
            new Coordinate(2, 9)
        };

        public List<string> VerticalWords = new List<string> { "шина", "вывих", "открытый" };
        public List<Coordinate> VerticalCoordinates = new List<Coordinate>
            {
                new Coordinate(1, 4),
                new Coordinate(4, 6),
                new Coordinate(7, 0)
            };

        public void FillBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = '*';
                }
            }
        }

        public void ShowBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    System.Console.Write("{0}{1}", board[i,j],' ');
                }
                System.Console.WriteLine();

            }
        }
        public void GenerateVerticalWords()
        {
            for(int i = 0; i < VerticalWords.Count; i++)
            {
                char[] array = VerticalWords[i].ToCharArray();
                int x = VerticalCoordinates[i].CoordX;
                int y = VerticalCoordinates[i].CoordY;

                for(int j = 0; j < array.Length; j++)
                {
                    board[x, y + j] = array[j];
                }
            }
        }

        public void GenerateHorizontalWords()
        {
            for (int i = 0; i < HorizontalWords.Count; i++)
            {
                char[] array = HorizontalWords[i].ToCharArray();
                int x = HorizontalCoordinates[i].CoordX;
                int y = HorizontalCoordinates[i].CoordY;

                for (int j = 0; j < array.Length; j++)
                {
                    board[x + j, y] = array[j];
                }
            }
        }
    };
}
    