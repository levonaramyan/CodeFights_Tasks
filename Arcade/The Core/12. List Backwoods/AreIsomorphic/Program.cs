using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Two two-dimensional arrays are isomorphic if they have the same number of rows
// and each pair of respective rows contains the same number of elements.
// PROBLEM: Given two two-dimensional arrays, check if they are isomorphic.
// Example:
//          For
//          array1 = [[1, 1, 1],
//                    [0, 0]]
//          and
//          array2 = [[2, 1, 1],
//                    [2, 1]]
//          the output should be
//          areIsomorphic(array1, array2) = true;
//
//          For
//          array1 = [[2],
//                    []]
//          and
//          array2 = [[2]]
//          the output should be
//          areIsomorphic(array1, array2) = false.

namespace AreIsomorphic
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static bool areIsomorphic(int[][] array1, int[][] array2)
        {
            int x1 = array1.Length;
            int x2 = array2.Length;
            bool areIsom = true;
            if (x1 != x2) return false;
            else
                for (int i = 0; areIsom && i < x1; i++)
                    if (array1[i].Length != array2[i].Length) areIsom = false;
            return areIsom;
        }
    }
}
