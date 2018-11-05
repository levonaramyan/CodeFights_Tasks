using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Consider a sequence of numbers a0, a1, ..., an, in which an element is equal to the sum of
// squared digits of the previous element. The sequence ends once an element that has already been
// in the sequence appears again.

// PROBLEM: Given the first element a0, find the length of the sequence.
// Example:
//          For a0 = 16, the output should be
//          squareDigitsSequence(a0) = 9.
//          Here's how elements of the sequence are constructed:

//          a0 = 16
//          a1 = 12 + 62 = 37
//          a2 = 32 + 72 = 58
//          a3 = 52 + 82 = 89
//          a4 = 82 + 92 = 145
//          a5 = 12 + 42 + 52 = 42
//          a6 = 42 + 22 = 20
//          a7 = 22 + 02 = 4
//          a8 = 42 = 16, which has already occurred before (a0)
//          Thus, there are 9 elements in the sequence.

//          For a0 = 103, the output should be
//          squareDigitsSequence(a0) = 4.
//          The sequence goes as follows: 103 -> 10 -> 1 -> 1, 4 elements altogether.

namespace SquareDigitsSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(squareDigitsSequence(16));
            Console.ReadKey();
        }

        // Returns the number of elements of square digits sequence, starting from a0
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

        // Returns the sum of digits squares
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
