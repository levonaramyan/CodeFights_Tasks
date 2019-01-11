using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// How many strings equal to a can be constructed using letters from the string b?
// Each letter can be used only once and in one string only.
// Example
//          For a = "abc" and b = "abccba", the output should be
//          stringsConstruction(a, b) = 2.
//          We can construct 2 strings a with letters from b.

namespace StringsConstruction
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(stringsConstruction("abc","abcabc"));
            Console.ReadKey();
        }

        static int stringsConstruction(string a, string b)
        {
            int cases = b.Length; // maximum possible repeats, if a.Length = 1

            // Finding minimum repeating character (from a) in string b
            foreach (char i in a)
            {
                int eqCounta = 0;
                int eqCountb = 0;

                // the number of char i in a
                foreach (char h in a)
                {
                    if (i == h) eqCounta++;
                }

                // the number of char i in b
                foreach (char j in b)
                {
                    if (i == j) eqCountb++;
                }

                // Repeats could be no more than eqCountb / eqCounta
                if (eqCountb / eqCounta < cases) cases = eqCountb / eqCounta;
            }

            return cases;
        }
    }
}
