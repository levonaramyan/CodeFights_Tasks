using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Define an alphabet reflection as follows: a turns into z, b turns into y, c turns 
// into x, ..., n turns into m, m turns into n, ..., z turns into a.
// Define a string reflection as the result of applying the alphabet reflection to each of its characters.
// Reflect the given string.
// Example:
//          For inputString = "name", the output should be
//          reflectString(inputString) = "mznv".

namespace ReflectString
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string reflectString(string inputString)
        {
            string reflected = "";
            foreach (char i in inputString)
            {
                reflected += (char)('z' + 'a' - i);
            }
            return reflected;

        }
    }
}
