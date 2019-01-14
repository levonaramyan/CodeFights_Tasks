using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher26
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string cipher26(string message)
        {
            string decr = $"{message[0]}";
            int sum = message[0] - 'a';
            char newChar = ' ';
            for (int i = 1; i < message.Length; i++)
            {
                if (sum % 26 > (int)(message[i] - 'a'))
                    newChar = (char)(26 - sum % 26 + message[i]);
                else
                    newChar = (char)(message[i] - sum % 26);
                sum += newChar - 'a';
                decr += newChar;
            }

            return decr;
        }

    }
}
