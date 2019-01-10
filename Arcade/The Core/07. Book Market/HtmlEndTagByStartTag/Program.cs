using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You are implementing your own HTML editor. To make it more comfortable for developers
// you would like to add an auto-completion feature to it.
// PROBLEM: Given the starting HTML tag, find the appropriate end tag which your editor should propose.
//          If you are not familiar with HTML, consult with this note.
// Example:
//          For startTag = "<button type='button' disabled>", the output should be
//          htmlEndTagByStartTag(startTag) = "</button>";
//
//          For startTag = "<i>", the output should be
//          htmlEndTagByStartTag(startTag) = "</i>".

namespace HtmlEndTagByStartTag
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(htmlEndTagByStartTag("<button type='button' disabled>"));
            Console.ReadKey();
        }

        // Returns the appropriate end tag for the given startTag
        static string htmlEndTagByStartTag(string startTag)
        {
            string res = "";
            if (!startTag.Contains(' ')) res = startTag[0] + "/" + startTag.Substring(1, startTag.Length - 1);
            else
            {
                int sepIndex = startTag.IndexOf(' ');
                res = startTag[0] + "/" + startTag.Substring(1, sepIndex - 1) + ">";
            }

            return res;
        }
    }
}
