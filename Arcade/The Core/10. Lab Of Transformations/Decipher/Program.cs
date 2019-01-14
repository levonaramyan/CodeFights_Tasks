using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Consider the following ciphering algorithm:
//      For each character replace it with its code.
//      Concatenate all of the obtained numbers.
// Given a ciphered string, return the initial one if it is known that it consists only of lowercase letters.
// Note: here the character's code means its decimal ASCII code, the numerical representation
// of a character used by most modern programming languages.
// Example:
//          For cipher = "10197115121", the output should be
//          decipher(cipher) = "easy".
//          Explanation: charCode('e') = 101, charCode('a') = 97, charCode('s') = 115 and charCode('y') = 121.

namespace Decipher
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string decipher(string cipher)
        {
            char newChar = ' ';
            string res = "";
            while (cipher.Length > 0)
            {
                int charLen = cipher[0] == '1' ? 3 : 2;
                newChar = (char)('a' - 97 + (cipher.Length == charLen ? int.Parse(cipher) :
                                             int.Parse(cipher.Remove(charLen))));
                res += newChar;
                cipher = cipher.Length == charLen ? "" : cipher.Substring(charLen);
            }
            return res;
        }
    }
}
