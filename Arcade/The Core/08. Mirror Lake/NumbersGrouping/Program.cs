using System;
using System.Collections.Generic;
using System.Linq;

// You are given an array of integers that you want distribute between several groups.
// The first group should contain numbers from 1 to 104, the second should contain those
// from 10^4 + 1 to 2 * 10^4, ..., the 100th one should contain numbers from 99 * 10^4 + 1 to 10^6 and so on.
// All the numbers will then be written down in groups to the text file in such a way that:
//          the groups go one after another;
//          each non-empty group has a header which occupies one line;
//          each number in a group occupies one line.
//          Calculate how many lines the resulting text file will have.
// Example:
//          For a = [20000, 239, 10001, 999999, 10000, 20566, 29999], the output should be
//          numbersGrouping(a) = 11.
//          The numbers can be divided into 4 groups:
//              239 and 10000 go to the 1st group (1 ... 10^4);
//              10001 and 20000 go to the second 2nd(10^4 + 1 ... 2 * 10^4);
//              20566 and 29999 go to the 3rd group(2 * 10^4 + 1 ... 3 * 10^4);
//              groups from 4 to 99 are empty;
//              999999 goes to the 100th group(99 * 10^4 + 1 ... 10^6).
//          Thus, there will be 4 groups(i.e.four headers) and 7 numbers,
//          so the file will occupy 4 + 7 = 11 lines.

namespace NumbersGrouping
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            int[] a = new int[] { 20000, 239, 10001, 999999, 10000, 20566, 29999 };
            Console.WriteLine(numbersGrouping(a));
            Console.ReadKey();
        }

        // Returns a numbers of raws, according to number grouping
        static int numbersGrouping(int[] a)
        {
            // Initializing a list of empty groups
            List<int> groupsList = new List<int>();
            for (int i = 0; i < 100000; i++)
            {
                groupsList.Add(0);
            }

            int len = a.Length;

            // for each number in a[], increment the appropriate group counter in groupsList
            // if the number is the first in the group, then additionally count also the header
            for (int i = 0; i < len; i++)
            {
                int index = (a[i] - 1) / 10000;
                if (groupsList[index] == 0)
                    groupsList[index] += 2;
                else
                    groupsList[index]++;
            }

            return groupsList.Sum();
        }
    }
}
