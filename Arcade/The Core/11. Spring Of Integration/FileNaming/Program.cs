using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You are given an array of desired filenames in the order of their creation.
// Since two files cannot have equal names, the one which comes later will have an addition
// to its name in a form of (k), where k is the smallest positive integer
// such that the obtained name is not used yet.
// PROBLEM: Return an array of names that will be given to the files.
// Example:
//          For names = ["doc", "doc", "image", "doc(1)", "doc"], the output should be
//          fileNaming(names) = ["doc", "doc(1)", "image", "doc(1)(1)", "doc(2)"].

namespace FileNaming
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string[] fileNaming(string[] names)
        {
            int length = names.Length;
            string tempName = "";
            for (int i = 1; i < length; i++)
            {
                bool lookBack = true;
                int k = 0;
                while (lookBack == true)
                {
                    lookBack = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (k == 0) tempName = names[i];
                        if (names[i] == names[j])
                        {
                            k++;
                            names[i] = $"{tempName}({k})";
                            lookBack = true;
                        }
                    }
                }
            }

            return names;
        }
    }
}
