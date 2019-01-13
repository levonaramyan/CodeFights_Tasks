using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreSimilar
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static bool areSimilar(int[] a, int[] b)
        {
            int arrLength = a.Length;
            int[] index = new int[2] { 0, 0 };
            int tempSwap;
            bool isSwapEnough = true;

            int j = 0;
            for (int i = 0; i < arrLength && j <= 1; i++)
            {
                if (a[i] != b[i])
                {
                    index[j] = i;
                    j++;
                }
            }

            tempSwap = a[index[0]];
            a[index[0]] = a[index[1]];
            a[index[1]] = tempSwap;

            for (int i = 0; i < arrLength; i++)
            {
                if (a[i] != b[i])
                {
                    isSwapEnough = false;
                    break;
                }
            }

            return isSwapEnough;
        }

    }
}
