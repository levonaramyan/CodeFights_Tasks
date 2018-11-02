using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given an array of integers, replace all the occurrences of elemToReplace with substitutionElem.
// Example:
//          For inputArray = [1, 2, 1], elemToReplace = 1, and substitutionElem = 3, the output should be
//          arrayReplace(inputArray, elemToReplace, substitutionElem) = [3, 2, 3].

namespace ArrayReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            int[] test = new int[] { 1, 2, 1 };
            int elemToReplace = 1;
            int substitutionElem = 3;
            int[] res = arrayReplace(test, elemToReplace, substitutionElem);
            foreach (int i in res) Console.Write(i + " ");
            Console.ReadKey();
        }

        // Replaces all the occurances of elemToReplace into substitutionElem in inputArray[]
        static int[] arrayReplace(int[] inputArray, int elemToReplace, int substitutionElem)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] == elemToReplace)
                    inputArray[i] = substitutionElem;
            }

            return inputArray;

        }
    }
}
