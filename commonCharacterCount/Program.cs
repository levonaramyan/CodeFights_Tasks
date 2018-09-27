using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commonCharacterCount
{
    class Program
    {
        static void Main(string[] args)
        {
            //This program prints our the number of common characters in given s1 and s2 strings

            //defining two strings for testing
            string a = "aabcc";
            string b = "adcaa";

            //Writing the number of common characters in a and b
            Console.WriteLine(commonCharacterCount(a,b));
            Console.ReadKey();
        }

        //This method returns the number of common characters in strings s1 and s2
        static int commonCharacterCount(string s1, string s2)
        {
            //defining parameters
            int counter = 0;
            int s1Len = s1.Length; //calculating the length of s1
            int s2Len;

            //checking the common characters
            for (int i = 0; i <= s1Len - 1; i++)
            {
                s2Len = s2.Length;
                for (int j = 0; j <= s2Len - 1; j++)
                {
                    if (s1[i] == s2[j])
                    {
                        s2 = s2.Remove(j, 1); //removing the common character from s2
                        counter++; //counting the common characters
                        break;
                    }
                }
            }
            return counter;
        }
    }
}
