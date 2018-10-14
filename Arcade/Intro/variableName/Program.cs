using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Correct variable names consist only of English letters, digits and underscores
// and they can't start with a digit.
// PROBLEM: Check if the given string is a correct variable name.

namespace variableName
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(variableName(")BBBaasadada14"));

            Console.ReadKey();
        }

        // The method returns whether the string is in normal variable format
        // En-letters+digits+underscore, and first is not a digit
        static bool variableName(string name)
        {
            name = name.ToLower();
            int firstSym;
            bool isNormalName = true;
            string symbOK = "_qwertyuiopasdfghjklzxcvbnm1234567890";

            // checking if the first symbol is digit
            bool firstIsDigit = int.TryParse(Convert.ToString(name[0]), out firstSym);
            isNormalName = !firstIsDigit;

            // checking if all symbs are digit, letters, underscores
            if (isNormalName)
            {
                foreach (char i in name)
                {
                    bool isOK = false;
                    foreach (char j in symbOK)
                    {
                        if (i == j) isOK = true;
                    }

                    if (!isOK)
                    {
                        isNormalName = false;
                        break;
                    }
                }
            }

            return isNormalName;
        }
    }
}
