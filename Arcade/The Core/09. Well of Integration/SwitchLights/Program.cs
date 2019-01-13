using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// N candles are placed in a row, some of them are initially lit. For each candle
// from the 1st to the Nth the following algorithm is applied: if the observed candle
// is lit then states of this candle and all candles before it are changed to the opposite.
// Which candles will remain lit after applying the algorithm to all candles
// in the order they are placed in the line?
// Example:
//          For a = [1, 1, 1, 1, 1], the output should be
//          switchLights(a) = [0, 1, 0, 1, 0].
//
//          For a = [0, 0], the output should be
//          switchLights(a) = [0, 0].
//          The candles are not initially lit, so their states are not altered by the algorithm.

namespace SwitchLights
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[] switchLights(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == 1)
                {
                    for (int j = i; j >= 0; j--)
                    {
                        a[j] = 1 - a[j];
                    }
                }
            }

            return a;

        }
    }
}
