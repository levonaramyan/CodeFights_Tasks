using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a string, replace each its character by the next one in the English alphabet (z would be replaced by a).

namespace alphabeticShift
{
    class Program
    {
        static void Main(string[] args)
        {
            // testing and printing the result
            Console.WriteLine(alphabeticShift("abcghkoihz"));
            Console.ReadKey();

        }

        // The method returns alphabetically shifted text
        static string alphabeticShift(string inputString)
        {
            // intitializing variables
            int length = inputString.Length;
            string newText = "";

            // converting and concatenating to newText
            for (int i = 0; i < length; i++)
            {
                if (inputString[i] == 'z')
                {
                    newText += 'a';
                }
                else
                {
                    newText += Convert.ToChar(Convert.ToInt32(inputString[i]) + 1);
                }
            }

            return newText;

        }
    }
}
