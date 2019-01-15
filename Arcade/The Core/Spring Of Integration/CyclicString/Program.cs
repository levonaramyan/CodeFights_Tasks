using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You're given a substring s of some cyclic string. What's the length of the smallest possible
// string that can be concatenated to itself many times to obtain this cyclic string?
// Example:
//          For s = "cabca", the output should be
//          cyclicString(s) = 3.
//          "cabca" is a substring of a cycle string "abcabcabcabc..." that can be obtained
//          by concatenating "abc" to itself.Thus, the answer is 3.

namespace CyclicString
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int cyclicString(string s)
        {
            int minLen = s.Length;
            for (int i = 0; i < s.Length - 1; i++)
            {
                string t = s.Substring(0, i + 1);
                if (IsRep(t, s) && t.Length < minLen) minLen = t.Length;
            }

            return minLen;
        }

        static bool IsRep(string a, string s)
        {
            bool isOk = true;
            for (int i = 0; isOk && i < s.Length; i++)
                if (s[i] != a[i % a.Length]) isOk = false;
            return isOk;
        }

    }
}
