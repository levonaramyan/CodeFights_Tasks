using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairOfShoes
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static bool pairOfShoes(int[][] shoes)
        {
            bool isPossible = false;
            for (int i = 0; i < shoes.Length; i++)
            {
                isPossible = false;
                for (int j = 0; j < shoes.Length; j++)
                {
                    if (shoes[i][0] == 1 - shoes[j][0] && shoes[i][1] == shoes[j][1])
                    {
                        isPossible = true;
                        shoes[i][1] = 0;
                        shoes[j][1] = 0;
                        break;
                    }
                }
                if (!isPossible) break;
            }

            return shoes.Length % 2 != 0 ? false : isPossible;

        }

    }
}
