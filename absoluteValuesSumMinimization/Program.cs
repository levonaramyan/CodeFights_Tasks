using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a sorted array of integers a, find an integer x from a such that the value of
// abs(a[0] - x) + abs(a[1] - x) + ... + abs(a[a.length - 1] - x)
// is the smallest possible(here abs denotes the absolute value).
// If there are several possible answers, output the smallest one.

namespace absoluteValuesSumMinimization
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing and testing
            int[] a = new int[] {2,4,7 };
            Console.WriteLine(absoluteValuesSumMinimization(a));
            Console.ReadKey();
        }

        // The method returns the element of a[], which has min abs distance
        static int absoluteValuesSumMinimization(int[] a)
        {
            // initializing variables, and an array which will contain sum abs distances
            int aLen = a.Length;
            int[] absDist = new int[aLen];
            int minAbs = 0;
            int resNum = 0;

            // calculating sum abs distances and returning them to absDist[]
            for (int i = 0; i < aLen; i++)
            {
                absDist[i] = 0;
                for (int j = 0; j < aLen; j++)
                {
                    absDist[i] += Math.Abs(a[j] - a[i]);
                }
            }

            minAbs = absDist.Min(); // the minimum abs distance sum

            // finding and returning the corresponding elemnt in array a[]
            for (int i = 0; i < aLen; i++)
            {
                if (minAbs == absDist[i])
                {
                    resNum = a[i];
                    break;
                }
            }

            return resNum;

        }



    }
}
