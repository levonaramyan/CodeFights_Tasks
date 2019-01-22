using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// In the popular Minesweeper game you have a board with some mines and those cells that don't
// contain a mine have a number in it that indicates the total number of mines in the neighboring cells.
// Starting off with some arrangement of mines we want to create a Minesweeper game setup.
// Example:
//          For
//          matrix = [[true, false, false],
//                    [false, true, false],
//                    [false, false, false]]
//          the output should be
//          minesweeper(matrix) = [[1, 2, 1],
//                                 [2, 1, 1],
//                                 [1, 1, 1]]
//          Check out the image below for better understanding:
//          https://codefightsuserpics.s3.amazonaws.com/tasks/minesweeper/img/example.png?_tm=1530801982661



namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[][] minesweeper(bool[][] matrix)
        {
            int x = matrix.Length + 2;
            int y = matrix[0].Length + 2;
            bool[][] bigMatrix = new bool[x][];


            for (int i = 0; i < x; i++)
            {
                bigMatrix[i] = new bool[y];
                for (int j = 0; j < y; j++)
                {
                    if ((i == 0) || (i == x - 1) || (j == 0) || (j == y - 1))
                    {
                        bigMatrix[i][j] = false;
                    }
                    else bigMatrix[i][j] = matrix[i - 1][j - 1];
                }
            }

            int[][] bombs = new int[x - 2][];
            for (int i = 0; i < x - 2; i++)
            {
                bombs[i] = new int[y - 2];
                for (int j = 0; j < y - 2; j++)
                {
                    if (bigMatrix[i + 1][j + 1])
                    {
                        bombs[i][j] = -1;
                    }
                    else bombs[i][j] = 0;

                    for (int h = -1; h <= 1; h++)
                    {
                        for (int k = -1; k <= 1; k++)
                        {
                            bombs[i][j] += Convert.ToInt32(bigMatrix[1 + i + h][1 + j + k]);
                        }
                    }
                }
            }
            return bombs;

        }

    }
}
