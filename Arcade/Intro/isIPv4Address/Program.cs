using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// IPv4 addresses are represented in dot-decimal notation, which consists of
// four decimal numbers, each ranging from 0 to 255 inclusive,
// separated by dots, e.g., 172.16.254.1.
// PROBLEM: Given a string, find out if it satisfies the IPv4 address naming rules.

namespace isIPv4Address
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing a test string and printing whether it is corresponding to IPv4 standards
            string ip = "14.192.0.3";
            Console.WriteLine(isIPv4Address(ip));
            Console.ReadKey();
        }


        // The method returns true, if inputString corresponds to IP standards:
        // Num.Num.Num.Num , where Num is in range [0,255]
        static bool isIPv4Address(string inputString)
        {
            bool areDotsOK = IPDotFormIsOK(inputString); // true, if dots are ok
            bool areNumsOK = IPNumFormIsOK(inputString, areDotsOK); // true, if both dots and nums are ok

            bool isIPv4 = areNumsOK && areDotsOK; // true, if all of the standards are ok

            return isIPv4;
        }

        // The method returns true, if the dots in inputString are distributed
        // according to IP Standards: *.*.*.*
        static bool IPDotFormIsOK(string inputString)
        {
            // initializing initial variables
            int legth = inputString.Length; // the length of inputString
            int dotsCount = 0; // will be the total count of "."-s in inputString

            // initializing conditional bool variables
            bool dotAtBeginning = inputString.StartsWith("."); // Checks if inputString starts with dot
            bool dotAtEnd = inputString.EndsWith("."); // Checks if inputString ends with dot
            bool twoDots = inputString.Contains(".."); // Checks if two adjacent dots are found
            bool numOfDotsIs3 = true;
            bool dotFormOK;

            // Checking if there are only 3 dots in inputString
            foreach (char i in inputString)
            {
                if (i == '.') ++dotsCount;
            }
            if (dotsCount != 3) numOfDotsIs3 = false;

            // Getting true, if input String don't start/end with dots,
            // it has 3 dots which are not adjacent
            dotFormOK = !dotAtBeginning && !dotAtEnd && !twoDots && numOfDotsIs3;

            return dotFormOK;
        }

        // The method returns true, if the dots are ok and the substrings between them
        // are Numbers in Range [0,255] : Num Num Num Num
        static bool IPNumFormIsOK (string inputString, bool dotsAreOK)
        {
            int minIP = 0;
            int maxIP = 255;
            bool allNumerical = true;
            bool allInRange = true;
            bool numFormOK = dotsAreOK;

            // checking if all the values between dots are nums, and are in range [0, 250]
            if (numFormOK)
            {
                string inputDotSubstring = inputString;
                for (int i = 1; i <= 3; i++)
                {
                    int dotPos = inputDotSubstring.IndexOf('.');
                    int substLen = inputDotSubstring.Length;
                    string ipNumString = inputDotSubstring.Remove(dotPos, (substLen - dotPos));
                    int ipNum;

                    // Check if each value between dots is numerical
                    allNumerical = int.TryParse(ipNumString, out ipNum);
                    if (!allNumerical)
                    {
                        break;
                    }
                    else
                    {
                        // Check if each value between dots lies in range [0,255]
                        allInRange = (ipNum >= minIP) && (ipNum <= maxIP);
                    }

                    if (!allInRange) break;

                    inputDotSubstring = inputDotSubstring.Substring(dotPos + 1);

                    // Checking the last num separately
                    if (i == 3)
                    {
                        allNumerical = int.TryParse(inputDotSubstring, out ipNum);
                        if (!allNumerical)
                        {
                            break;
                        }
                        else
                        {                            
                            allInRange = (ipNum >= minIP) && (ipNum <= maxIP);
                        }
                    }
                }
            }

            // True if both dots and nums are in IPv4 adress standard
            numFormOK = numFormOK && allInRange && allNumerical;

            return numFormOK;

        }

    }
}
