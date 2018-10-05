using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You are given an array of desired filenames in the order of their creation.
// Since two files cannot have equal names, the one which comes later will have
// an addition to its name in a form of (k), where k is the smallest positive integer
// such that the obtained name is not used yet.

// PROBLEM: Return an array of names that will be given to the files.
// Example
// For names = ["doc", "doc", "image", "doc(1)", "doc"], the output should be
// fileNaming(names) = ["doc", "doc(1)", "image", "doc(1)(1)", "doc(2)"].

namespace fileNaming
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing a test string array, and printing the result of the test
            string[] test = new string[] { "doc", "doc", "image", "doc(1)", "doc" };
            for (int i = 0; i < test.Length; i++) Console.Write($"{test[i]}\t");
            Console.WriteLine();
            string[] result = fileNaming(test);
            for (int i = 0; i < test.Length; i++) Console.Write($"{result[i]}\t");
            Console.ReadKey();

        }

        // The method returns an array of string, where the names of docs are updated
        static string[] fileNaming(string[] names)
        {
            int length = names.Length; // array length
            string tempName = ""; // will be a temprorary name of a doc, which name was found as a repeated

            // looking through an array of strings and for each item looking back
            // and when finding a repeating name, iteratively rename it, until no repeating names found
            for (int i = 1; i < length; i++)
            {
                bool lookBack = true;
                int k = 0;
                while (lookBack == true)
                {
                    lookBack = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (k == 0) tempName = names[i]; // for ex. doc
                        if (names[i] == names[j])
                        {
                            k++;
                            names[i] = $"{tempName}({k})"; // will become doc(k)
                            lookBack = true;
                        }
                    }
                }
            }

            return names;
        }
    }
}
