using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Let's call two integers A and B friends if each integer from the array divisors is either a divisor
// of both A and B or neither A nor B. If two integers are friends, they are said to be in the same clan.
// How many clans are the integers from 1 to k, inclusive, broken into?
// Example:
//          For divisors = [2, 3] and k = 6, the output should be
//          numberOfClans(divisors, k) = 4.
//          The numbers 1 and 5 are friends and form a clan, 2 and 4 are friends and form a clan,
//          and 3 and 6 do not have friends and each is a clan by itself.
//          So the numbers 1 through 6 are broken into 4 clans.

namespace NumberOfClans
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            int[] divisors = new int[] { 2, 3 };
            int k = 6;
            Console.WriteLine(numberOfClans(divisors,k));
            Console.ReadKey();
        }

        static int numberOfClans(int[] divisors, int k)
        {
            int[] clans = new int[k]; // could be no more than k clans
            for (int i = 0; i < k; i++)
            {
                clans[i] = -1;
            }

            // When finding a new clan, then incrementing the index and keeping the element
            int index = 0;
            for (int i = 1; i <= k; i++)
            {
                int j = 0;
                bool isNewClan = true;
                while (j < k && clans[j] >= 0)
                {
                    if (AreFriends(divisors, i, clans[j]))
                    {
                        isNewClan = false;
                        break;
                    }
                    j++;
                }

                if (isNewClan)
                {
                    clans[index] = i;
                    index++;
                }

            }

            return index;

        }

        // Returns true, if A and B are friends
        static bool AreFriends(int[] divisors, int A, int B)
        {
            bool areFriends = true;
            for (int i = 0; areFriends && i < divisors.Length; i++)
            {
                areFriends = (A % divisors[i] == 0) == (B % divisors[i] == 0);
            }

            return areFriends;
        }
    }
}
