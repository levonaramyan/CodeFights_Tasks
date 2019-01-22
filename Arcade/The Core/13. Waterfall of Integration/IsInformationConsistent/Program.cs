using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Court is in session. We got a group of witnesses who have all taken an oath to tell the truth.
// The prosecutor is pointing at the defendants one by one and asking each witnesses
// a simple question - "guilty or not?". The witnesses are allowed to respond in one of the following three ways:
// I am sure he/she is guilty.
// I am sure he/she is innocent.
// I have no idea.
// The prosecutor has a hunch that one of the witnesses might not be telling the truth
// so she decides to cross-check all of their testimonies and see if the information gathered is consistent,
// i.e.there are no two witnesses A and B and a defendant C such that A says C is guilty while B says C is innocent.
// Example:
//          For
//          evidences = [[0, 1, 0, 1],
//                       [-1, 1, 0, 0],
//                       [-1, 0, 0, 1]]
//          the output should be
//          isInformationConsistent(evidences) = true;
//
//          For
//          evidences = [[1, 0],
//                       [-1, 0],
//                       [1, 1],
//                       [1, 1]]
//          the output should be
//          isInformationConsistent(evidences) = false.

namespace IsInformationConsistent
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static bool isInformationConsistent(int[][] evidences)
        {
            bool isOK = true;
            for (int j = 0; isOK && j < evidences[0].Length; j++)
                for (int i = 0; isOK && i < evidences.Length - 1; i++)
                    for (int k = i + 1; isOK && k < evidences.Length; k++)
                        isOK = evidences[i][j] * evidences[k][j] != -1;

            return isOK;

        }

    }
}
