using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
