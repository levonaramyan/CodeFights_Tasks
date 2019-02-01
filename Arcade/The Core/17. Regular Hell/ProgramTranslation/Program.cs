using System;
using System.Text.RegularExpressions;

// Implement the missing code, denoted by ellipses. You may not modify the pre-existing code.
// As an avid user of CodeSignal, you find it frustrating that there are no debugging
// and recovery tasks in your favorite language, PHP.You decide to help the platform
// by translating solutions in JavaScript into PHP.
// You quickly discover that this approach is quite convenient: sometimes all you have
// to do is substitute the function arguments by adding the $ sign in front of them.
// At first you do this manually, but soon realize that it won't get you far enough.
// Now you need to implement a function that, given a solution written in JavaScript
// and its args, adds a $ sign in front of each args[i] (unless there is already a dollar sign present).
// Given a solution in JavaScript and its args, return the almost-PHP solution.
// Example:
//          For
//          solution = 
//              "function add($n, m) {\t
//                 return n + $m;\t
//          }"
//          and args = ["n", "m"], the output should be
//          programTranslation(solution, args) =
//              "function add($n, $m) {\t
//                 return $n + $m;\t
//               }"

namespace ProgramTranslation
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string programTranslation(string solution, string[] args)
        {
            string argumentVariants = String.Join("|", args);
            string pattern = string.Format(@"\$?(?<![a-zA-Z0-0_])({0})(?![a-zA-Z0-0_])", argumentVariants);
            string sub = @"$$$1";
            return Regex.Replace(solution, pattern, sub);
        }
    }
}
