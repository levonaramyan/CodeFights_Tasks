using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Timed Reading is an educational tool used in many schools to improve and advance reading skills.
// A young elementary student has just finished his very first timed reading exercise.
// Unfortunately he's not a very good reader yet, so whenever he encountered a word longer than maxLength,
// he simply skipped it and read on.
// Help the teacher figure out how many words the boy has read by calculating the number of words
// in the text he has read, no longer than maxLength.
// Formally, a word is a substring consisting of English letters, such that characters
// to the left of the leftmost letter and to the right of the rightmost letter are not letters.
// Example:
//          For maxLength = 4 and
//          text = "The Fox asked the stork, 'How is the soup?'",
//          the output should be
//          timedReading(maxLength, text) = 7.
//          The boy has read the following words: "The", "Fox", "the", "How", "is", "the", "soup".

namespace TimedReading
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int timedReading(int maxLength, string text)
        {
            int readed = 0;
            int wordlength = 0;
            int index = 0;
            foreach (char i in text)
            {
                if (wordlength > 0 && !(char.IsLetter(i)) && wordlength <= maxLength)
                    readed++;
                if (char.IsLetter(i)) wordlength++;
                else wordlength = 0;

                if (wordlength > 0 && wordlength <= maxLength && index == text.Length - 1)
                    readed++;
                index++;
            }

            return readed;

        }
    }
}
