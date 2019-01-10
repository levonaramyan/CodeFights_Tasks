using System;

// Some file managers sort filenames taking into account case of the letters, others compare strings
// as if all of the letters are of the same case. That may lead to different ways of filename ordering.
// Call two filenames an unstable pair if their ordering depends on the case.
// To compare two filenames a and b, find the first position i at which a[i] ≠ b[i]. If a[i] < b[i],
// then a<b. Otherwise a > b.If such position doesn't exist, the shorter string goes first.
// PROBLEM: Given two filenames, check whether they form an unstable pair.
// Example:
//          For filename1 = "aa" and filename2 = "AAB", the output should be
//          isUnstablePair(filename1, filename2) = true.
//          Because "AAB" < "aa", but "AAB" > "AA".

//          For filename1 = "A" and filename2 = "z", the output should be
//          isUnstablePair(filename1, filename2) = false.
//          Both "A" < "z" and "a" < "z".

namespace IsUnstablePair
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(isUnstablePair("aa","AAB"));
            Console.ReadKey();
        }

        // Returns tru if two strings are unstable pair
        static bool isUnstablePair(string filename1, string filename2)
        {
            bool comp1 = string.Compare(filename2, filename1, StringComparison.Ordinal) > 0;
            bool comp2 = string.Compare(filename2.ToUpper(), filename1.ToUpper(), StringComparison.Ordinal) < 0;
            bool comp3 = string.Compare(filename2, filename1, StringComparison.Ordinal) < 0;
            bool comp4 = string.Compare(filename2.ToLower(), filename1.ToLower(), StringComparison.Ordinal) > 0;

            return comp1 ? comp2 : (comp3 ? comp4 : false);
        }
    }
}
