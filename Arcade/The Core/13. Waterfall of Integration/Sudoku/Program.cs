using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Sudoku is a number-placement puzzle. The objective is to fill a 9 × 9 grid with digits
// so that each column, each row, and each of the nine 3 × 3 sub-grids that compose the grid
// contains all of the digits from 1 to 9.
// This algorithm should check if the given grid of numbers represents a correct solution to Sudoku.
// Example
//          For the first example below, the output should be true. For the other grid,
//          the output should be false: each of the nine 3 × 3 sub-grids should contain
//          all of the digits from 1 to 9.
//          https://codefightsuserpics.s3.amazonaws.com/tasks/sudoku/img/sudoku.png?_tm=1530813787170



namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static bool sudoku(int[][] grid)
        {
            int[] column = new int[9];
            bool[] columnOK = new bool[9];
            bool[] rowOK = new bool[9];
            int[] matrix = new int[9];
            bool[] matrixOK = new bool[9];
            int countOK = 0;
            bool continueToCheck = true;
            for (int i = 0; i < 9 && continueToCheck; i++)
            {
                rowOK[i] = containsAllDigits(grid[i]);
                for (int j = 0; j < 9; j++)
                {
                    column[j] = grid[j][i];
                    matrix[j] = grid[(i / 3) * 3 + j / 3][(i % 3) * 3 + j % 3];
                }
                columnOK[i] = containsAllDigits(column);
                matrixOK[i] = containsAllDigits(matrix);

                if (rowOK[i] && columnOK[i] && matrixOK[i]) countOK++;
                else continueToCheck = false;
            }

            return countOK == 9;
        }

        static bool containsAllDigits(int[] inputArray)
        {
            int countTrue = 0;
            bool[] contains = new bool[9];
            for (int i = 0; i < inputArray.Length; i++)
                contains[inputArray[i] - 1] = true;
            for (int i = 0; i < 9; i++)
                if (contains[i]) countTrue++;

            return countTrue == 9;
        }
    }
}
