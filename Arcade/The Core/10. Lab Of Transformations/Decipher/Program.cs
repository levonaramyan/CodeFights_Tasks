using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
