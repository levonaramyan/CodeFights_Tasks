using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffledArray
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[] shuffledArray(int[] shuffled)
        {
            Array.Sort(shuffled);
            int len = shuffled.Length;
            int[] res = new int[shuffled.Length - 1];
            bool isFound = false;
            for (int i = len - 1; !isFound && i >= 0; i--)
            {
                int index = 0;
                int sum = 0;
                for (int j = 0; j < len; j++)
                {
                    if (i != j)
                    {
                        sum += shuffled[j];
                        res[index] = shuffled[j];
                        index++;
                    }

                }

                isFound = sum == shuffled[i];
            }
            return res;

        }

    }
}
