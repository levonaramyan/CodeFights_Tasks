using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Once Mary heard a famous song, and a line from it stuck in her head. That line was
// "Will you still love me when I'm no longer young and beautiful?". Mary believes that
// a person is loved if and only if he/she is both young and beautiful, but this is
// quite a depressing thought, so she wants to put her belief to the test.

// PROBLEM: Knowing whether a person is young, beautiful and loved, find out if they contradict Mary's belief.

// A person contradicts Mary's belief if one of the following statements is true:

// they are young and beautiful but not loved;
// they are loved but not young or not beautiful.

namespace WillYou
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(willYou(true, true,false));
            Console.ReadKey();
        }


        // Returns true if the the parameters contradicts to the mentioned above belief.
        static bool willYou(bool young, bool beautiful, bool loved)
        {
            bool res = false;
            if (loved)
            {
                if (!young || !beautiful) res = false;
                else res = true;
            }
            else
            {
                if (young && beautiful) res = false;
                else res = true;
            }

            return (!res);
        }
    }
}
