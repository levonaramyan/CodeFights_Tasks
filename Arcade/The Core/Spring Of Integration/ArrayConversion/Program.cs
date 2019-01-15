using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayConversion
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int arrayConversion(int[] inputArray)
        {
            bool iter = false;
            while (inputArray.Length > 1)
            {
                inputArray = RecConv(inputArray, iter);
                iter = !iter;
            }

            return inputArray[0];

        }

        static int[] RecConv(int[] arr, bool even)
        {
            int[] conv = new int[arr.Length / 2];
            for (int i = 0; i < conv.Length; i++) conv[i] = even ? arr[2 * i] * arr[2 * i + 1] : arr[2 * i] + arr[2 * i + 1];
            return conv;
        }
    }
}
