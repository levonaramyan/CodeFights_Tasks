using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseNumbersSum
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int houseNumbersSum(int[] inputArray)
        {
            int i = 0;
            int sum = 0;
            while (inputArray[i] > 0)
            {
                sum += inputArray[i];
                i++;
            }

            return sum;

        }
    }
}
