using System;

// A ciphertext alphabet is obtained from the plaintext alphabet by means of rearranging some characters.
// For example "bacdef...xyz" will be a simple ciphertext alphabet where a and b are rearranged.
// A substitution cipher is a method of encoding where each letter of the plaintext alphabet
// is replaced with the corresponding(i.e.having the same index) letter of some ciphertext alphabet.
// PROBLEM: Given two strings, check whether it is possible to obtain them from each other
//          using some (possibly, different) substitution ciphers.
// Example:
//          For string1 = "aacb" and string2 = "aabc", the output should be
//          isSubstitutionCipher(string1, string2) = true.
//          Any ciphertext alphabet that starts with acb...would make this transformation possible.
//
//          For string1 = "aa" and string2 = "bc", the output should be
//          isSubstitutionCipher(string1, string2) = false.

namespace IsSubstitutionCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(isSubstitutionCipher("aacb","aabc"));
            Console.ReadKey();
        }

        // Returns true, if string1 and string2 are Substitution Cipher
        static bool isSubstitutionCipher(string string1, string string2)
        {
            bool isPossible = true; // Is true, while an inappropriate case is found

            // For each i and j position, when the letters are similar in a,
            // then they should be similar also in b, and vice-versa
            // when inconsistence is found, then the strings are not Substitution Cipher
            for (int i = 0; i < string1.Length; i++)
            {
                for (int j = 0; j < string1.Length; j++)
                {
                    bool test1 = string1[i] == string1[j];
                    bool test2 = string2[i] == string2[j];
                    if (test1 == test2) isPossible = true;
                    else
                    {
                        isPossible = false;
                        break;
                    }
                }

                if (!isPossible) break;
            }

            return isPossible;
        }

    }
}
