using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Proper nouns always begin with a capital letter, followed by small letters.
// Correct a given proper noun so that it fits this statement.

// Example
//          For noun = "pARiS", the output should be
//          properNounCorrection(noun) = "Paris";
//          For noun = "John", the output should be
//          properNounCorrection(noun) = "John".

namespace ProperNounCorrection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(properNounCorrection("pARIS"));
            Console.ReadKey();
        }

        // Returns a new string with correctet letter cases
        static string properNounCorrection(string noun)
        {
            return $"{$"{noun[0]}".ToUpper()}{noun.Substring(1).ToLower()}";
        }
    }
}
