using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolleyballPositions
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string[][] volleyballPositions(string[][] formation, int k)
        {
            int ch = k % 6;
            int[,] f = new int[,] { { 0, 3, 0 }, { 4, 0, 2 }, { 0, 6, 0 }, { 5, 0, 1 } };
            string[] names = new string[6];

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 3; j++)
                    if (f[i, j] > 0)
                        names[(f[i, j] - 1 + k) % 6] = formation[i][j];

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 3; j++)
                    if (f[i, j] > 0)
                    {
                        formation[i][j] = names[f[i, j] - 1];
                    }

            return formation;

        }

    }
}
