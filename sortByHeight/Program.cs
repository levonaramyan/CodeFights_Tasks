using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortByHeight
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Some people are standing in a row in a park. There are trees between them which cannot be moved.
             * Your task is to rearrange the people by their heights in a non-descending order
             * without moving the trees. People can be very tall!
             * For a = [-1, 150, 190, 170, -1, -1, 160, 180], the output should be
             * sortByHeight(a) = [-1, 150, 160, 170, -1, -1, 180, 190]*/

            // defining a test array
            int[] a = new int[] { -1, 150, 190, 170, -1, -1, 160, 180 };
            foreach (int k in a) Console.Write(k + " ");
            a = sortByHeight(a);
            Console.WriteLine();
            Console.WriteLine("After rearrangement it will be: ");

            // Printing the rearranged array
            foreach (int k in a) Console.Write(k + " ");
            
            Console.ReadKey();
        }

        // The method returns an array where the non -1 values are sorted by ascending
        static int[] sortByHeight(int[] a)
        {
            //defining variables
            int peopleCount = 0;            
            int aLen = a.Length;

            //counting the number of non -1 values in a[]
            for (int i = 0; i < aLen; i++)
            {
                if (a[i] > -1) peopleCount++;
            }

            //defining a new array aPeople[], which will contain only the height of people
            int[] aPeople = new int[peopleCount];

            //Putting the heigths of the people in aPeople[]
            int j = 0;
            for (int i = 0; i < aLen; i++)
            {
                if (a[i] > -1)
                {
                    aPeople[j] = a[i];
                    j++;
                }
            }

            // Sorting aPeople[] by heights
            Array.Sort(aPeople);

            // Finding the locations of people height in a[] and rearrange by ascending height
            j = 0;
            for (int i = 0; i < aLen; i++)
            {
                if (a[i] > -1)
                {
                    a[i] = aPeople[j];
                    j++;
                }
            }

            // returning the rearranged array
            return a;
            
        }
    }
}
