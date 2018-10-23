using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// PROBLEM: Reverse the order of the bits in a given integer.
// Example:
//          For a = 97, the output should be
//          mirrorBits(a) = 67.
//          97 equals to 1100001 in binary, which is 1000011 after mirroring, and that is 67 in base 10.

namespace MirrorBits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(mirrorBits(97));
            Console.ReadKey();
        }

        // Returns a new int, where the order of bits is a reversed one from number a.
        static int mirrorBits(int a)
        {
            string revStr = new String(Convert.ToString(a, 2).Reverse().ToArray());
            int rev = Convert.ToInt32(revStr, 2);
            return rev;
        }

    }
}
