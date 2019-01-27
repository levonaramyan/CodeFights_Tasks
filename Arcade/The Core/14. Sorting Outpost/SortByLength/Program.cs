using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given an array of strings, sort them in the order of increasing lengths.
// If two strings have the same length, their relative order must be the same as in the initial array.
// Example
//          For
//          inputArray = ["abc",
//                        "",
//                        "aaa",
//                        "a",
//                        "zz"]
//          the output should be
//          sortByLength(inputArray) = ["",
//                                      "a",
//                                      "zz",
//                                      "abc",
//                                      "aaa"]

namespace SortByLength
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string[] sortByLength(string[] inputArray)
        {
            for (int i = 1; i < inputArray.Length; i++)
            {
                int j = i;
                int iLen = inputArray[j].Length;
                while (j >= 1)
                {
                    int bLen = inputArray[j - 1].Length; ;
                    if (iLen < bLen)
                    {
                        string temp = inputArray[j];
                        inputArray[j] = inputArray[j - 1];
                        inputArray[j - 1] = temp;
                        j--;
                    }
                    else break;
                }
            }

            return inputArray;

        }

    }
}
