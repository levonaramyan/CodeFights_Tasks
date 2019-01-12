using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// A step(x) operation works like this: it changes a number x into x - s(x),
// where s(x) is the sum of x's digits. You like applying functions to numbers,
// so given the number n, you decide to build a decreasing sequence of numbers:
// n, step(n), step(step(n)), etc., with 0 as the last element.
// Building a single sequence isn't enough for you, so you replace all elements
// of the sequence with the sums of their digits (s(x)). Now you're curious
// as to which number appears in the new sequence most often.
// If there are several answers, return the maximal one.
// Example:
//          For n = 88, the output should be
//          mostFrequentDigitSum(n) = 9.
//          Here is the first sequence you built: 88, 72, 63, 54, 45, 36, 27, 18, 9, 0;
//          And here is s(x) for each of its elements: 16, 9, 9, 9, 9, 9, 9, 9, 9, 0.
//          As you can see, the most frequent number in the second sequence is 9.
//
//          For n = 8, the output should be
//          mostFrequentDigitSum(n) = 8.
//          At first you built the following sequence: 8, 0
//          s(x) for each of its elements is: 8, 0
//          As you can see, the answer is 8 (it appears as often as 0, but is greater than it).

namespace MostFrequentDigitSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(mostFrequentDigitSum(88));
            Console.ReadKey();
        }

        // Returns the most frequent digit sum
        static int mostFrequentDigitSum(int n)
        {
            int len = 0;
            int n1 = n;
            int n2 = n;
            int maxNum = -1;

            // determining the length of a sequence
            while (n > 0)
            {
                n = n - SumOfDigits(n);
                len++;
            }

            // Adding elements of a sequence to array
            int[] list1 = new int[len];
            int index = 0;
            while (n1 > 0)
            {
                n1 = n1 - SumOfDigits(n1);
                list1[index] = n1;
                index++;
            }

            // Updating the list1 with the sum of digits of its elements
            for (int i = 0; i < len; i++)
            {
                list1[i] = SumOfDigits(list1[i]);
                if (list1[i] > maxNum) maxNum = list1[i]; // determining the max value in array
            }

            int[] countsList = new int[maxNum + 1]; // A list of counts of each number from 0 to the maxNum

            // counting elements
            for (int i = 0; i < len; i++)
            {
                countsList[list1[i]]++;
            }

            // Dtermining the most frequent element
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

        // Returns the sum of digits of parameter a
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
