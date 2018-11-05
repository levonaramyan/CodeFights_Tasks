using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComfortableNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static int comfortableNumbers(int l, int r)
        {
            int count = 0;
            for (int a = l; a < r; a++)
            {
                for (int b = a + 1; b <= r; b++)
                {
                    if (AreComfortable(a, b)) count++;
                }
            }

            return count;


        }

        static int DigSum(int a)
        {
            int sum = 0;
            while (a != 0)
            {
                sum += a % 10;
                a /= 10;
            }

            return sum;
        }

        static bool AreComfortable(int a, int b)
        {
            int aSum = DigSum(a);
            int bSum = DigSum(b);
            return (a != b) && (a >= b - bSum) && (a <= b + bSum) && (b >= a - aSum) && (b <= a + aSum);
        }
    }
}
