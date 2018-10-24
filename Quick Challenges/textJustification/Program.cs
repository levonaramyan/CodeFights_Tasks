using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given an array of words and a length l, format the text such that each line has exactly l characters
// and is fully justified on both the left and the right. Words should be packed in a greedy approach;
// that is, pack as many words as possible in each line. Add extra spaces when necessary so that
// each line has exactly l characters.

// Extra spaces between words should be distributed as evenly as possible.
// If the number of spaces on a line does not divide evenly between words,
// the empty slots on the left will be assigned more spaces than the slots on the right.
// For the last line of text and lines with one word only, the words should be left justified
// with no extra space inserted between them.

// Example:
//          For
//          words = ["This", "is", "an", "example", "of", "text", "justification."]
//          and l = 16, the output should be

//          textJustification(words, l) = ["This    is    an",
//                                         "example  of text",
//                                         "justification.  "]


namespace textJustification
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing a test array of strings and the width of the line
            string[] test = new string[] { "Looks", "like", "it", "can", "be", "a", "tricky", "test" };
            int width = 25;

            // Getting justified array of equal width lines
            string[] adjustedText = textJustification(test, width);

            // Printing the intitial array and justified text in console
            Console.Write("Input array: ");
            foreach (string i in test) Console.Write(i + " ");
            Console.WriteLine($"\n\nWidth = {width}\n");
            foreach (string i in adjustedText) Console.WriteLine(i + "|");
            Console.ReadKey();
        }

        // Returns a justified array of lines (width = l), from array words[]
        static string[] textJustification(string[] words, int l)
        {
            int wLen = words.Length; // The number of words in input array words[]
            string[][] lineWords = new string[wLen][]; // will contain an array of corresponding words, for each line i
            int lineLen = words[0].Length; // will be the current length of a line
            int index = 0; // the index of current line
            int start = 0; // the starting index of the current line in array words[]

            // Filling the array lineWords, with corresponding words
            for (int i = 1; i < wLen; i++)
            {
                // If the current word can be stored in the current line, then just add its length to lineLen
                // else initialize the string of words of current line and fill with corresponding words
                if (lineLen + 1 + words[i].Length <= l) lineLen += 1 + words[i].Length;
                else
                {
                    lineWords[index] = new string[i - start]; // Initializing the current line, with (i - start) elements

                    for (int j = start; j < i; j++) lineWords[index][j - start] = words[j]; // filling
                    index++; // Getting to the next line
                    start = i; // Moving the start point of next line
                    lineLen = words[i].Length; // adding the length of first word in line's length
                }

                // If it is the last word in array, then initialize the last line
                if (i == wLen - 1)
                {
                    lineWords[index] = new string[i - start + 1];
                    for (int j = start; j <= i; j++) lineWords[index][j - start] = words[j];
                }
            }

            // If words[] contains only one word, then directly return its corresponding array of 1 elem.
            if (wLen == 1) return (new string[] { AdjustLine(WordArrayToLine(words, l), l, true) });

            // Construct and return an array of lines
            return ConstructLines(lineWords, l, index + 1);
            
        }

        // Getting an array of words of all of the lines, the width and the number of lines
        // Returns an array of lines
        static string[] ConstructLines(string[][] words, int width, int len)
        {
            string[] res = new string[len]; // initializing an empty array of lines

            // Filling with corresponding lines
            for (int i = 0; i < len; i++)
                res[i] = AdjustLine(WordArrayToLine(words[i], width), width, (i == len - 1));

            return res;
        }

        // Getting an array of words, returns a string with spaces in between words
        static string WordArrayToLine(string[] words, int width)
        {
            if (words.Length == 1 && words[0].Length < width) return words[0] + " ";

            string res = "";
            for (int i = 0; i < words.Length; i++)
                res += words[i] + ((i != words.Length - 1) ? " " : "");

            return res;
        }

        // Getting a line, width, and a flag of last line
        // Returns a new string with corresponding width, by appropriately adding spaces
        static string AdjustLine(string line, int width, bool last)
        {
            if (line.Length == width) return line; // when there is no need to add any spaces

            if (last) return (line + new string(' ', width - line.Length)); // when it is the last line, just add spaces after

            int spaces = line.Length - line.Replace(" ", "").Length; // the number of spaces in the line
            int moreSpaces = width - line.Length; // the number of more spaces to be added
            string normSpace = new string(' ', 1 + moreSpaces / spaces); // the new space, between words
            string extraSpace = new string(' ', 2 + moreSpaces / spaces); // the extraSpace, for adjustment
            line = line.Replace(" ", normSpace); // replace all the spaces with new ones
            int pos = line.IndexOf(normSpace); // get the position of the first space

            // Adding more spaces from left to right, when equal distribution of additional spaces
            // is not enough to get a line with given width
            while (line.Length < width)
            {
                // adding an extra space in position pos
                line = line.Substring(0, pos) + extraSpace + line.Substring(pos + normSpace.Length);

                // finding the next space in the line
                pos = pos + extraSpace.Length + line.Substring(pos + extraSpace.Length).IndexOf(normSpace);
            }

            return line;
        }
    }
}
