using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// When you recently visited your little nephew, he told you a sad story: there's a bully
// at school who steals his lunch every day, and locks it away in his locker.
// He also leaves a note with a strange, coded message. Your nephew gave you one of the notes
// in hope that you can decipher it for him. And you did: it looks like all the digits in it
// are replaced with letters and vice versa. Digit 0 is replaced with 'a', 1 is replaced with 'b'
// and so on, with digit 9 replaced by 'j'.
// The note is different every day, so you decide to write a function that will decipher it
// for your nephew on an ongoing basis.
// Example:
//          For note = "you'll n4v4r 6u4ss 8t: cdja", the output should be
//          stolenLunch(note) = "you'll never guess it: 2390".

namespace StolenLunch
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string stolenLunch(string note)
        {
            string res = "";
            char newChar = ' ';
            foreach (char i in note)
            {
                if (char.IsDigit(i)) newChar = (char)('a' + int.Parse($"{i}"));
                else if (char.IsLetter(i) && i <= 'j' && i >= 'a') newChar = (char)('0' + i - 'a');
                else newChar = i;
                res += newChar;
            }

            return res;

        }
    }
}
