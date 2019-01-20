using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapDiagonals
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[][] swapDiagonals(int[][] matrix)
        {
            int len = matrix.Length;
            int[][] res = new int[len][];
            for (int i = 0; i < len; i++)
            {
                res[i] = new int[len];
                for (int j = 0; j < len; j++)
                    res[i][j] = matrix[i][j];
                res[i][i] = matrix[i][len - 1 - i];
                res[i][len - 1 - i] = matrix[i][i];
            }
            return res;

        }

    }
}
