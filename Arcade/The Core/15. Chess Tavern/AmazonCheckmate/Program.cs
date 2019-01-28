using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonCheckmate
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[] amazonCheckmate(string king, string amazon)
        {
            int[] res = new int[4];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    string black = $"{(char)('a' + i)}{j + 1}";
                    if (black != amazon && !kingBeat(king, black))
                    {
                        int moves = 0;
                        for (int k = -1; moves == 0 && k <= 1; k++)
                            for (int h = -1; moves == 0 && h <= 1; h++)
                            {
                                string newPos = $"{(char)('a' + i + k)}{j + h + 1}";
                                moves = (newPos != black && onBoard(newPos) &&
                                         !amazonBeat(amazon, newPos, king) && !kingBeat(king, newPos)) ? 1 : 0;
                            }
                        res[0] += (amazonBeat(amazon, black, king) && moves == 0) ? 1 : 0;
                        res[1] += (amazonBeat(amazon, black, king) && moves == 1) ? 1 : 0;
                        res[2] += (!amazonBeat(amazon, black, king) && moves == 0) ? 1 : 0;
                        res[3] += (!amazonBeat(amazon, black, king) && moves == 1) ? 1 : 0;
                    }
                }
            }

            return res;
        }

        static bool amazonBeat(string a, string k, string whiteKing)
        {
            if (InBetween(a, whiteKing, k) || k == a) return false;
            int d1 = Math.Abs((int)a[0] - (int)k[0]);
            int d2 = Math.Abs((int)a[1] - (int)k[1]);
            if (d1 < 3 && d2 < 3) return true;
            if (d1 == 0 || d2 == 0) return true;
            if (d1 == d2) return true;
            return false;
        }

        static bool kingBeat(string k, string k1)
        {
            int d1 = Math.Abs((int)k[0] - (int)k1[0]);
            int d2 = Math.Abs((int)k[1] - (int)k1[1]);
            if (d1 < 2 && d2 < 2) return true;
            return false;
        }

        static bool onBoard(string p)
        {
            return (p[0] >= 'a' && p[0] <= 'h' && p[1] < '9' && p[1] > '0');
        }

        static bool InBetween(string a, string k, string k1)
        {
            bool isInBetween = false;
            bool kInDir = false;
            bool k1InDir = false;
            int s1 = (k[0] - a[0] != 0) ? Math.Sign(k[0] - a[0]) : 0;
            int s2 = (k[1] - a[1] != 0) ? Math.Sign(k[1] - a[1]) : 0;
            for (int i = 0; !k1InDir && i <= 8; i++)
            {
                k1InDir = (a[0] + i * s1 == k1[0]) && ((a[1] + i * s2 == k1[1])) ? true : k1InDir;
                kInDir = (a[0] + i * s1 == k[0]) && ((a[1] + i * s2 == k[1])) ? true : kInDir;
            }


            return k1InDir && kInDir;
        }

    }
}
