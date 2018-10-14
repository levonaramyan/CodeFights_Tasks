using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zigzag
{
    class Program
    {
        static void Main(string[] args)
        {
            // This program returns the maximum length of zigzag.
            // A sequence of integers is called a zigzag sequence if each of its elements
            // is either strictly less than all its neighbors or strictly greater than all its neighbors.

            // defining a test array
            int[] a = new int[] { 4,4,5, 4,3 };

            // Printing the result for our test array a[] 
            Console.WriteLine(checkZigzag(a));
            Console.ReadKey();
        }

        // The method returns the maximum length of zigzag subarray in array a[]
        static int checkZigzag (int[] a)
        {
            //Defining some variables           
            int aLen = a.Length; //length of input array a[]

            // maxsum[] will contain an array with maximum leghts of subarrays
            int[] maxsum = new int[aLen]; 
            for (int i = 0; i < aLen; i++) maxsum[i] = 1;

            //calculating the maximum legths of subarrays, which starts from position j.
            for (int j = 0; j < aLen - 1; j++)
            {
                int coef = Math.Sign(a[j] - a[j+1]); //determines the biggest of first two elements
                for (int i = j; i <= aLen - 2; i++)
                {
                    if (a[i] * coef * Math.Pow((-1), (i-j)) > a[i + 1] * coef * Math.Pow((-1), (i-j)))
                    {
                        maxsum[j] += 1;
                    }
                    else
                    {
                        break;
                    }
                }                
            }

            // Returning the maximum value (legth) of calculated subarrays
            return maxsum.Max();
        }
    }
}
