using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawRectangle
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static char[][] drawRectangle(char[][] canvas, int[] rectangle)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                    canvas[rectangle[j * 2 + 1]][rectangle[i * 2]] = '*';

                for (int x = rectangle[1] + 1; x < rectangle[3]; x++)
                    canvas[x][rectangle[2 * i]] = '|';
                for (int y = rectangle[0] + 1; y < rectangle[2]; y++)
                    canvas[rectangle[2 * i + 1]][y] = '-';
            }

            return canvas;
        }

    }
}
