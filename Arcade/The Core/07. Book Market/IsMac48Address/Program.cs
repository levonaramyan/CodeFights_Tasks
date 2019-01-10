using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// A media access control address (MAC address) is a unique identifier assigned to network interfaces
// for communications on the physical network segment.
// The standard(IEEE 802) format for printing MAC-48 addresses in human-friendly form is
// six groups of two hexadecimal digits(0 to 9 or A to F), separated by hyphens(e.g. 01-23-45-67-89-AB).
// PROBLEM: Your task is to check by given string inputString whether it corresponds to MAC-48 address or not.
// Example:
//          For inputString = "00-1B-63-84-45-E6", the output should be
//          isMAC48Address(inputString) = true;
//          For inputString = "Z1-1B-63-84-45-E6", the output should be
//          isMAC48Address(inputString) = false;
//          For inputString = "not a MAC-48 address", the output should be
//          isMAC48Address(inputString) = false.

namespace IsMac48Address
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            string test = "Z1-1B-63-84-45-E6";
            Console.WriteLine(IsMac48Address_Regex(test));
            Console.ReadKey();
        }

        // With Regex
        static bool IsMac48Address_Regex(string inputString)
        {
            string m = @"[\dA-F]{2}";
            string pattern = $"^{m}-{m}-{m}-{m}-{m}-{m}$";
            return Regex.IsMatch(inputString, pattern);
        }

        // Standard solution
        static bool isMAC48Address(string inputString)
        {
            int length = inputString.Length;
            bool isMac = false;

            if (length % 3 == 2)
            {
                // Checking elements: 0-9, A-F
                for (int i = 0; i < length / 3 + 1; i++)
                {
                    char c1 = inputString[3 * i];
                    char c2 = inputString[3 * i + 1];
                    if (char.IsDigit(c1) || (char.IsUpper(c1) && c1 >= 'A' && c1 <= 'F')
                        && (char.IsDigit(c2) || (char.IsUpper(c2) && c2 >= 'A' && c2 <= 'F')))
                        isMac = true;
                    else
                    {
                        isMac = false;
                        break;
                    }
                }

                // Checking separator '-'
                if (isMac)
                {
                    for (int i = 2; i < length; i += 3)
                    {
                        if (inputString[i] != '-')
                        {
                            isMac = false;
                            break;
                        }
                    }
                }
            }

            return isMac;
        }
        
    }
}
