using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBishopDream
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[] chessBishopDream(int[] boardSize, int[] initPosition, int[] initDirection, int k)
        {
            int[] pos = new int[2];
            for (int i = 0; i <= 1; i++)
                pos[i] = StepsDir(initPosition[i], initDirection[i], boardSize[i], k);

            return pos;
        }

        static int StepsDir(int p, int d, int l, int k)
        {
            int r = k / l;

            if (r % 2 == 1)
            {
                p = l - 1 - p;
                d = -d;
            }

            for (int i = 1; i <= k - r * l; i++)
            {
                if ((d < 0 && p == 0) || (d > 0 && p == l - 1)) d = -d;
                else p += d;
            }

            return p;
        }

    }
}
