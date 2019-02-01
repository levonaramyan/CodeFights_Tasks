
using System.Text.RegularExpressions;

// Implement the missing code, denoted by ellipses. You may not modify the pre-existing code.
// Given a string s, determine if it is a subsequence of a given string t.
// Example:
//          For t = "CodeSignal" and s = "CoSi", the output should be
//          isSubsequence(t, s) = true;
//
//          For t = "CodeSignal" and s = "cosi", the output should be
//          isSubsequence(t, s) = false.

namespace IsSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static bool isSubsequence(string t, string s)
        {
            string pattern = "";
            foreach (char ch in s)
            {
                pattern += $"[{ch}].*";
            }
            Regex regex = new Regex(pattern);
            return regex.Match(t).Success;
        }
    }
}
