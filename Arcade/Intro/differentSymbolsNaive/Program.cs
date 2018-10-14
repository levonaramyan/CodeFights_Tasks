using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a string, find the number of different characters in it.

namespace differentSymbolsNaive
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(differentSymbolsNaive("blablabla"));
            Console.ReadKey();
        }

        // The method returns the number of non repeating characters in string s
        static int differentSymbolsNaive(string s)
        {
            // Initializing a new array of chars, which will contain a list of non repeating chars
            char[] symbs = new char[s.Length];
            symbs[0] = s[0];
            int j = 1;

            // calculating the number of non repeatings
            for (int i = 1; i < s.Length; i++)
            {
                bool isRep = false;
                for (int k = 0; k < j; k++)
                {
                    if (s[i] == symbs[k])
                    {
                        isRep = true;
                        break;
                    }                    
                }

                if (!isRep)
                {
                    symbs[j] = s[i];
                    j++;
                }
            }

            return j;
        }
    }
}
