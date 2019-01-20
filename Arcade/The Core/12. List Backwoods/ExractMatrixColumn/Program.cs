using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExractMatrixColumn
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[] extractMatrixColumn(int[][] matrix, int column)
        {
            int[] a = new int[matrix.Length];
            for (int i = 0; i < a.Length; i++)
                a[i] = matrix[i][column];
            return a;

        }
    }
}
