using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Define a word as a sequence of consecutive English letters.
// Find the longest word from the given string.

namespace longestWord
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the longest word
            Console.WriteLine(longestWord("asdshgfjhas fakjhf oo?"));
            Console.ReadKey();
        }

        // The method returns the longest word in the text.
        static string longestWord(string text)
        {
            int max = 0; // will be the maximum length of the word
            int templen = 0; // will be the length of current considered word
            string result = ""; // will be the final result
            string word = ""; // will be the current considered word

            // searching char by char the longest word
            foreach (char i in text)
            {
                // adding the letter wot the word until it is not letter
                if (char.IsLetter(i))
                {
                    templen++;
                    word += $"{i}";
                }
                // when finding the end of word, comparing it with the previous max and taking the longest
                else
                {
                    if (templen > max)
                    {
                        max = templen;
                        result = word;
                    }
                    templen = 0; // starting a new word
                    word = ""; // starting a new word
                }
            }

            if (templen > max) result = word; // checking the last/unchecked word

            return result;
        }

    
    }
}
