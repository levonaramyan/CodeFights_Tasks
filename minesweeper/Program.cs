using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// In the popular Minesweeper game you have a board with some mines and those cells that don't contain
// a mine have a number in it that indicates the total number of mines in the neighboring cells.
// Starting off with some arrangement of mines we want to create a Minesweeper game setup.

namespace minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing a test matrix
            bool[][] test = new bool[3][];
            test[0] = new bool[3]{true,false,false };
            test[1] = new bool[3] { false, true, false };
            test[2] = new bool[3] { false, false, false };

            // applying the test and printing the result
            int[][] res = minesweeper(test);
            foreach(int[] i in res)
            {
                foreach (int j in i)
                {
                    Console.Write($"{j} ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        // The method returns a new matrix of ints, which contains a number of bombs in neighbouring cells 
        static int[][] minesweeper(bool[][] matrix)
        {
            // Creating a duplicate of matrix, with frame "false"
            int x = matrix.Length + 2;
            int y = matrix[0].Length + 2;
            bool[][] bigMatrix = new bool[x][];            

            for (int i = 0; i < x; i++)
            {
                bigMatrix[i] = new bool[y];
                for (int j = 0; j < y;j++)
                {
                    if ((i == 0) || (i == x - 1) || (j == 0) || (j == y - 1))
                    {
                        bigMatrix[i][j] = false;
                    }
                    else bigMatrix[i][j] = matrix[i - 1][j - 1];
                }
            }

            // Calculating the number of neighboaring bombs
            int[][] bombs = new int[x-2][];
            for (int i = 0; i < x-2; i++)
            {
                bombs[i] = new int[y - 2];
                for (int j = 0; j < y - 2; j++)
                {                    
                    if (bigMatrix[i+1][j+1])
                    {
                        bombs[i][j] = -1;
                    }else bombs[i][j] = 0;

                    for (int h = -1; h <=1; h++)
                    {
                        for (int k = -1; k <= 1; k++)
                        {
                            bombs[i][j] += Convert.ToInt32(bigMatrix[1 + i + h][1 +j + k]);                            
                        }
                    }
                }
            }

            return bombs;
        }
    }
}
