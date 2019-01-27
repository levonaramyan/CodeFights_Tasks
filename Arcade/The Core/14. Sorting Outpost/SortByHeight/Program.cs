using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Some people are standing in a row in a park. There are trees between them which cannot be moved.
// Your task is to rearrange the people by their heights in a non-descending order
// without moving the trees. People can be very tall!
// Example
//          For a = [-1, 150, 190, 170, -1, -1, 160, 180], the output should be
//          sortByHeight(a) = [-1, 150, 160, 170, -1, -1, 180, 190].

namespace SortByHeight
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[] sortByHeight(int[] a)
        {
            int peopleCount = 0;
            int aLen = a.Length;
            for (int i = 0; i < aLen; i++)
            {
                if (a[i] > -1) peopleCount++;
            }

            int[] aPeople = new int[peopleCount];

            int j = 0;
            for (int i = 0; i < aLen; i++)
            {
                if (a[i] > -1)
                {
                    aPeople[j] = a[i];
                    j++;
                }
            }

            Array.Sort(aPeople);

            j = 0;
            for (int i = 0; i < aLen; i++)
            {
                if (a[i] > -1)
                {
                    a[i] = aPeople[j];
                    j++;
                }
            }

            return a;
        }

    }
}
