using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingSum
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int crossingSum(int[][] matrix, int a, int b)
        {
            int x = matrix.Length;
            int y = matrix[0].Length;
            int sum = -matrix[a][b];
            for (int i = 0; i < x; i++)
                sum += matrix[i][b];
            for (int i = 0; i < y; i++)
                sum += matrix[a][i];
            return sum;

        }
    }
}
