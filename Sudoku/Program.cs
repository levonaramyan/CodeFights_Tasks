using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Sudoku is a number-placement puzzle. The objective is to fill a 9 × 9 grid
// with digits so that each column, each row, and each of the nine 3 × 3 sub-grids
// that compose the grid contains all of the digits from 1 to 9.

// PROBLEM: This algorithm should check if the given grid of numbers represents a correct solution to Sudoku.

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing a test matrix
            int[][] test = new int[9][];
            test[0] = new int[]{ 1, 3, 2, 5, 4, 6, 9, 8, 7 };
            test[1] = new int[]{ 4, 6, 5, 8, 7, 9, 3, 2, 1 };
            test[2] = new int[]{ 7, 9, 8, 2, 1, 3, 6, 5, 4 };
            test[3] = new int[]{ 9, 2, 1, 4, 3, 5, 8, 7, 6 };
            test[4] = new int[]{ 3, 5, 4, 7, 6, 8, 2, 1, 9 };
            test[5] = new int[]{ 6, 8, 7, 1, 9, 2, 5, 4, 3 };
            test[6] = new int[]{ 5, 7, 6, 9, 8, 1, 4, 3, 2 };
            test[7] = new int[]{ 2, 4, 3, 6, 5, 7, 1, 9, 8 };
            test[8] = new int[]{ 8, 1, 9, 3, 2, 4, 7, 6, 5 };

            // Testing and printing theresult (true/false: correct/incorrect)
            Console.WriteLine(sudoku(test));
            Console.ReadKey();
        }

        // The method returns true, if the numbers in input matrix are distributed
        // according to the terms of sudoku
        static bool sudoku(int[][] grid)
        {
            int[] column = new int[9]; // will contain the numbers in considered column
            bool[] columnOK = new bool[9]; // [i]-th elem, if the i-th column has all the digits 
            bool[] rowOK = new bool[9]; // [i]-th elem, if the i-th row has all the digits 
            int[] matrix = new int[9]; // will contain the elements of considered 3x3 submatrix
            bool[] matrixOK = new bool[9]; // [i]-th elem, if the i-th matrix has all the digits 
            int countOK = 0; // counting if [i]-th matrixOK[] && columnOK[] && rowOK[], are true
            bool continueToCheck = true; // will be true, while the program will not find inappropriate col/row/matr

            for (int i = 0; i < 9 && continueToCheck; i++)
            {
                rowOK[i] = containsAllDigits(grid[i]); // checking [i]-th row
                for (int j = 0; j < 9; j++)
                {
                    column[j] = grid[j][i]; // getting the elements of column[i]
                    matrix[j] = grid[(i / 3) * 3 + j / 3][(i % 3) * 3 + j % 3]; // getting the elements of matrix[i]
                }
                columnOK[i] = containsAllDigits(column); // checking [i]-th column
                matrixOK[i] = containsAllDigits(matrix); // checking [i]-th matrix

                // if all [i]-th checks are true, countinue the checking, else, stop and return the result
                if (rowOK[i] && columnOK[i] && matrixOK[i]) countOK++;
                else continueToCheck = false;
            }

            return countOK == 9;
        }

        // The method checks, whether the input array contains all the digits from 1 to 9
        static bool containsAllDigits(int[] inputArray)
        {
            int countTrue = 0;
            bool[] contains = new bool[9];
            for (int i = 0; i<inputArray.Length;i++)
                contains[inputArray[i] - 1] = true;
            for (int i = 0; i < 9; i++)
                if (contains[i]) countTrue++;

            return countTrue == 9;
        }
    }
}
