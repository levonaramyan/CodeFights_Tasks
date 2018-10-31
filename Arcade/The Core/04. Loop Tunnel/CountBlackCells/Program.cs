using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Imagine a white rectangular grid of n rows and m columns divided into two parts by a diagonal line
// running from the upper left to the lower right corner. Now let's paint the grid in two colors
// according to the following rules:

// A cell is painted black if it has at least one point in common with the diagonal;
// Otherwise, a cell is painted white.
// Count the number of cells painted black.

// Example
//          For n = 3 and m = 4, the output should be
//          countBlackCells(n, m) = 6.
//          There are 6 cells that have at least one common point with the diagonal and therefore are painted black.

//          For n = 3 and m = 3, the output should be
//          countBlackCells(n, m) = 7.
//          7 cells have at least one common point with the diagonal and are painted black.



namespace CountBlackCells
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(countBlackCells(3,4));
            Console.ReadKey();
        }

        // Returns the number of black cells, through the diagonal
        static int countBlackCells(int n, int m)
        {
            return n + m - 2 + gcd(n, m);
        }

        // Returns the number of additional cells, which are caused by passing through the corner
        static int gcd(int a, int b)
        {
            return a == 0 ? b : gcd(b % a, a);
        }
    }
}
