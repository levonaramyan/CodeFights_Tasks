using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Yesterday you found some shoes in the back of your closet. Each shoe is described by two values:
// type indicates if it's a left or a right shoe;
// size is the size of the shoe.
// Your task is to check whether it is possible to pair the shoes you found in such a way
// that each pair consists of a right and a left shoe of an equal size.
// Example:
//          For
//          shoes = [[0, 21],
//                   [1, 23],
//                   [1, 21],
//                   [0, 23]]
//          the output should be
//          pairOfShoes(shoes) = true;
//
//          For
//          shoes = [[0, 21],
//                   [1, 23],
//                   [1, 21],
//                   [1, 23]]
//          the output should be
//          pairOfShoes(shoes) = false.

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
