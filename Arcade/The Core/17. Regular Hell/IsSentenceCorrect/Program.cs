using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// Implement the missing code, denoted by ellipses. You may not modify the pre-existing code.
// A sentence is considered correct if:
//      it starts with a capital letter;
//      it ends with a full stop, question mark or exclamation point('.', '?' or '!');
//      full stops, question marks and exclamation points don't appear anywhere else in the sentence.
// Given a sentence, return true if it is correct and false otherwise.
// Example:
//          For sentence = "This is an example of *correct* sentence.",
//          the output should be
//          isSentenceCorrect(sentence) = true;
//
//          For sentence = "!this sentence is TOTALLY incorrecT",
//          the output should be
//          isSentenceCorrect(sentence) = false.

namespace IsSentenceCorrect
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static bool isSentenceCorrect(string sentence)
        {
            Regex regex = new Regex(@"^[A-Z][^!?.]*[!?.]$");
            return regex.IsMatch(sentence);
        }
    }
}
