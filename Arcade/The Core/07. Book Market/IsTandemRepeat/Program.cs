using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Determine whether the given string can be obtained by one concatenation of some string to itself.
// Example:
//          For inputString = "tandemtandem", the output should be
//          isTandemRepeat(inputString) = true;
//          For inputString = "qqq", the output should be
//          isTandemRepeat(inputString) = false;
//          For inputString = "2w2ww", the output should be
//          isTandemRepeat(inputString) = false.

namespace IsTandemRepeat
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(isTandemRepeat("tandemtandem"));
            Console.ReadKey();
        }

        // Returns true if inputString is a concatenation of two equal to each other strings
        static bool isTandemRepeat(string inputString)
        {
            return inputString.Substring(0, inputString.Length / 2) == inputString.Substring(inputString.Length / 2);
        }
    }
}
