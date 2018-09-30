using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// PROBLEM: Given an array of integers, replace all the occurrences of elemToReplace with substitutionElem.

namespace arrayReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            // initializing test variables
            int[] test = new int[] { 1, 2, 1 };
            int rep = 1;
            int sub = 3;

            // applying the method and printing result
            int[] res = arrayReplace(test, rep, sub);
            foreach (int i in res) Console.Write($"{i} ");
            Console.ReadKey();
        }

        // The method finds in array all elements with a given value and replaces with another
        static int[] arrayReplace(int[] inputArray, int elemToReplace, int substitutionElem)
        {
            int aLen = inputArray.Length;
            for (int i = 0; i < aLen; i++)
            {
                if (inputArray[i] == elemToReplace)
                    inputArray[i] = substitutionElem;
            }
            return inputArray;
        }

    }
}
