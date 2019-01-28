using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessKnightMoves
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int chessKnightMoves(string cell)
        {
            int x = cell[0] - 'a' + 1;
            int y = Convert.ToInt32($"{cell[1]}");
            int count = 0;
            for (int i = 1; i <= 2; i++)
            {
                for (int l = -1; l <= 1; l = l + 2)
                {
                    for (int j = -1; j <= 1; j = j + 2)
                    {
                        int k = j * (3 - i);
                        int h = i * l;
                        int newX = x + k;
                        int newY = y + h;

                        if (newX > 0 && newX < 9 && newY > 0 && newY < 9) count++;
                    }
                }

            }

            return count;
        }

    }
}
