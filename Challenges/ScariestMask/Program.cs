using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This Halloween, you want your costume to be so scary that onlookers will jump at the sight of you!
// You've almost got it all planned out, but you still need to find a scary mask.
// You've been told that facial symmetry is a sign of beauty, so you figure the more asymmetrical your mask is,
// the scarier it'll be!
// You're going mask shopping later today, so to make the process easier, you'd like to write an algorithm
// that can assess the scariness of a mask just by looking at a picture of it.More specifically,
// given an array of strings mask, representing what the mask looks like, your task is to return
// the number of pairs of cells that don't match up symmetrically.

// Example: For

//          mask = ["A    A",
//                  " O  O ",
//                  "= WW ="]
//          the output should be scariestMask(mask) = 0.

//          For

//          mask = ["@     ''' ",
//                  "' v**v  @'",
//                  "  A**A ' '"]
//          the output should be scariestMask(mask) = 12.

namespace ScariestMask
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing a test array of strings as a mask.
            string[] mask = new string[] { "@     ''' ",
                                           "' v**v  @'",
                                           "  A**A ' '"};

            // Printing the number of assymetric pairs in test mask
            Console.WriteLine(scariestMask(mask));
            Console.ReadKey();
        }

        // Returns the number of assymetric pairs in mask
        static int scariestMask(string[] mask)
        {
            int c = 0; // the counter of assymetric pairs
            foreach (string s in mask)
                for (int i = 0; i < s.Length / 2; i++)
                    c += (s[i] == s[s.Length - i - 1]) ? 0 : 1;
            return c;
        }
    }
}
