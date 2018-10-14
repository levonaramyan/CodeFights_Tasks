using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Digit root of some positive integer is defined as the sum of all of its digits.
//You are given an array of integers. Sort it in such a way that if a comes before b
//then the digit root of a is less than or equal to the digit root of b. If two numbers
//have the same digit root, the smaller one (in the regular sense) should come first.
//For example 4 and 13 have the same digit root, however 4 < 13thus 4 comes before 13
//in any digitRoot sorting where both are present.

namespace digitRootSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // initializing a test array and printing in console
            int[] a = new int[] { 13, 20, 7, 4 };
            Console.Write("The initial array is:\t\t\t");
            foreach (int i in a) Console.Write($"{i}\t");

            // Getting a sorted by digit root array
            var aSorted = DigitRootSort(a);

            // Printing in console the sorted and digit root arrays            
            Console.Write("\nAfter sorting by digit root it is:\t");
            foreach (int i in a) Console.Write($"{i}\t");
            Console.Write("\nThe digit roots accordingly are:\t");
            foreach (int j in aSorted) Console.Write($"{DigitRoot(j)}\t");
            Console.ReadKey();  

        }

        // This method returns an array, sorted by digit roots
        static int[] DigitRootSort(int[] a)
        {
            int aLen = a.Length; // The length of an array a
            int[] aDigRoot = new int[aLen]; // An array which will contain the digit roots

            // Gets the array of digit roots
            for (int i= 0; i < aLen; i++)
            {
                aDigRoot[i] = DigitRoot(a[i]);
            }

            // rearranging arrays a and aDigitRoot according to digit root ascending
            for (int i = 1; i < aLen; i++)
            {
                bool moveObjectBack = true;
                int j = i;
                do
                {
                    if (aDigRoot[j] < aDigRoot[j - 1] || (aDigRoot[j] == aDigRoot[j - 1] && a[j] <a[j-1]))
                    {
                        int tempValue = a[j];
                        a[j] = a[j - 1];
                        a[j - 1] = tempValue;

                        tempValue = aDigRoot[j];
                        aDigRoot[j] = aDigRoot[j - 1];
                        aDigRoot[j - 1] = tempValue;
                        moveObjectBack = true;
                        --j;
                    }
                    else moveObjectBack = false;
                } while (moveObjectBack && j > 0);
            }

            return a;
        }

        // This method returns the digit root of integer a
        static int DigitRoot(int a)
        {
            string aStr = a.ToString();
            int aLen = aStr.Length;
            int digRoot = 0;
            foreach (char i in aStr) digRoot += int.Parse(i.ToString());
            return digRoot;
        }
    }
}
