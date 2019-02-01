using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// Implement the missing code, denoted by ellipses. You may not modify the pre-existing code.
// You are given a string consisting of words separated by whitespace characters,
// where the words consist only of English letters.
// Your task is to swap pairs of consecutive words and return the result.
// Example:
//          For s = "CodeFight On", the output should be
//          swapAdjacentWords(s) = "On CodeFight";
//
//          For s = "How are you today guys", the output should be
//          swapAdjacentWords(s) = "are How today you guys".

namespace SwapAdjacentWords
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string swapAdjacentWords(string s)
        {
            return Regex.Replace(s, @"([a-zA-Z]+) ([a-zA-Z]+)", @"$2 $1");
        }
    }
}
