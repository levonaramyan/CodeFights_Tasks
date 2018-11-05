using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareDigitsSequence
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static int squareDigitsSequence(int a0)
        {
            int[] a = new int[30];
            a[0] = a0;
            int i = 0;
            bool isRepeated = false;
            while (!isRepeated)
            {
                i++;
                a[i] = sumOfDigits(a[i - 1]);
                for (int j = 0; j <= i - 1; j++)
                {
                    if (a[i] == a[j]) isRepeated = true;
                }
            }

            return i + 1;

        }

        static int sumOfDigits(int n)
        {
            int sum = 0;

            while (n > 0)
            {
                sum += (n % 10) * (n % 10);
                n /= 10;
            }

            return sum;
        }

    }
}
