using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSumOfConsecutive2
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static int isSumOfConsecutive2(int n)
        {
            int numOfWays = 0;
            for (int i = 1; i <= n / 2; i++)
            {
                int tempSum = i;
                int j = i;
                while (tempSum < n)
                {
                    j++;
                    tempSum += j;
                    if (tempSum == n) numOfWays++;
                }
            }

            return numOfWays;
        }
    }
}
