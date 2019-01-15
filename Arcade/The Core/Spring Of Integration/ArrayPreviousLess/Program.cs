using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayPreviousLess
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[] arrayPreviousLess(int[] items)
        {
            int[] res = new int[items.Length];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = -1;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (items[j] < items[i])
                    {
                        res[i] = items[j];
                        break;
                    }
                }
            }

            return res;

        }

    }
}
