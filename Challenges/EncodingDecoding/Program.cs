using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ************************************** Reverse Challenge ********************************************
// A reverse challenge is a special type of challenge, where no description is provided!
// You have to solve two challenges in one: find out what the author wants from you and write a solution.

// Test 1:
//         Input: message: "abc"
//         Expected Output: "616365"
// Test 2:
//         Input: message: ""
//         Expected Output: Empty
// Test 3:
//         Input: message: "616365"
//         Expected Output: "abc"
// Test 4:
//         Input: message: "aaa"
//         Expected Output: "616263"
// Test 5:
//         Input: message: "Hi"
//         Expected Output: "486a"
// Test 6:
//         Input: message: "5a"
//         Expected Output: "Z"
// Test 7:
//         Input: message: "666666"
//         Expected Output: "fed"
// Test 8:
//         Input: message: "ALL CAPS"
//         Expected Output: "414d4e234746565a"
// Test 9:
//         Input: message: "You are awesome"
//         Expected Output: "5970772365776b2769806f7e7b7a73"




namespace EncodingDecoding
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(encodingDecoding("5970772365776b2769806f7e7b7a73"));
            Console.ReadKey();
        }

        // Returns decoded message, if it was encoded, and vice-versa
        static string encodingDecoding(string message)
        {
            string decoded = "";
            bool isEnc = IsEncoded(message);

            // If the string is original message, then encode it as follows:
            // write a hexadecimal number of each (character + character position)
            for (int i = 0; !isEnc && i < message.Length; i++)
            {
                char c = message[i];
                decoded += ((int)c + i).ToString("X").ToLower();
            }

            // If the string is encoded, then decode it as follows: get each two characters (hexadecimal numbers) of a string,
            // convert to decimal and subtract the position in string, then get the corresponding unicode character
            for (int i = 0; isEnc && i < message.Length / 2; i++)
            {
                decoded += (char)(Convert.ToInt32(message.Substring(2 * i, 2).ToUpper(), 16) - i);
            }

            return decoded;
        }


        // Checking if the string is encoded, and represents a sequence of hexadecimal numbers
        static bool IsEncoded(string s)
        {
            if (s.Length % 2 > 0) return false;
            bool isEnc = true;
            for (int i = 0; isEnc && i < s.Length / 2; i++)
            {
                if (!char.IsDigit(s[2 * i]) && !(char.IsDigit(s[2 * i + 1]) || (s[2 * i + 1] >= 'a' && s[2 * i + 1] <= 'f')))
                    isEnc = false;
            }

            return isEnc;
        }
    }
}
