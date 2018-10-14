using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Construct a square matrix with a size N × N containing integers from 1 to N * N
// in a spiral order, starting from top-left and in clockwise direction.

// Example:
// For n = 3, the output should be

// spiralNumbers(n) = [[1, 2, 3],
//                     [8, 9, 4],
//                     [7, 6, 5]]

namespace spiralNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing
            int n = 7;
            var test = spiralNumbers(n);

            // Printing the resulting test matrix
            for (int i = 0; i<n;i++)
            {
                for (int j = 0; j<n;j++)
                {
                    Console.Write($"{test[i][j]}\t");
                }
                Console.WriteLine();
            }

            Console.ReadKey();

        }

        // The method returns a matrix, with spiral order of numbers
        static int[][] spiralNumbers(int n)
        {
            // Creating and initializing the matrix
            int[][] matrix = new int[n][];
            for (int k = 0; k < n; k++)
            {
                matrix[k] = new int[n]; 
            }

            int iter = 1; // will be the number which will be stored in coming element of matrix
            int i = 0; // the starting i position in matrix
            int j = 0; // the starting j position in matrix
            bool iIsActive = false; // if true, we will consider the order through i, else through j.
            int iDirection = 1; // shows the pos/neg (1/-1) direction of the order in i
            int jDirection = 1; // the same in j

            // while it is not stored the last item in matrix, go.
            while (iter <= n*n)
            {
                matrix[i][j] = iter;
                iter++;

                // if j is active and the next item through j is filled, or out of matrix
                // switch to i, and reverse the direction of j
                if (!iIsActive) 
                {
                    if (j + jDirection == n || j + jDirection == -1 || matrix[i][j + jDirection] != 0)
                    {
                        iIsActive = true;
                        jDirection *= -1;
                        i += iDirection;
                    }
                    else j += jDirection; // if the next is not filled, then just go through j
                }

                // if i is active and the next item through i is filled, or out of matrix
                // switch to j, and reverse the direction of i
                else
                {
                    if (i + iDirection == n || i + iDirection == -1 || matrix[i+iDirection][j] != 0)
                    {
                        iIsActive = false;
                        iDirection *= -1;
                        j += jDirection;
                    }
                    else i += iDirection; // if the next is not filled, then just go through i
                }
            }
            return matrix;
        }
    }
}
