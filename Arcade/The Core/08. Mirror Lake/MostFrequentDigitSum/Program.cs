using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostFrequentDigitSum
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int mostFrequentDigitSum(int n)
        {
            int len = 0;
            int n1 = n;
            int n2 = n;
            int maxNum = -1;
            while (n > 0)
            {
                n = n - SumOfDigits(n);
                len++;
            }

            int[] list1 = new int[len];
            int index = 0;
            while (n1 > 0)
            {
                n1 = n1 - SumOfDigits(n1);
                list1[index] = n1;
                index++;
            }

            for (int i = 0; i < len; i++)
            {
                list1[i] = SumOfDigits(list1[i]);
                if (list1[i] > maxNum) maxNum = list1[i];
            }

            int[] countsList = new int[maxNum + 1];

            for (int i = 0; i < len; i++)
            {
                countsList[list1[i]]++;
            }

            int freqElem = 0;
            int maxCount = 0;
            for (int i = 0; i <= maxNum; i++)
            {
                if (countsList[i] >= maxCount)
                {
                    maxCount = countsList[i];
                    freqElem = i;
                }
            }

            return (n2 / 10 == 0) ? n2 : freqElem;
        }

        static int SumOfDigits(int a)
        {
            int res = 0;

            while (a > 0)
            {
                res += a % 10;
                a /= 10;
            }

            return res;
        }
    }
}
