using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You've been invited to a job interview at a famous company that tests programming challenges.
// To evaluate your coding skills, they have asked you to parse a given problem's input given
// as an inputString string, and count the number of primitive type elements within it.
// The inputString can be either a primitive type variable or an array(possibly multidimensional)
// that contains elements of the primitive types.
// A primitive type variable can be:
//      an integer number;
//      a string, which is surrounded by " characters (note that it may contain any character except ");
//      a boolean, which is either true or false.
// Return the total number of primitive type elements inside inputString.
// Example:
//          For inputString = "[[0, 20], [33, 99]]", the output should be
//          countElements(inputString) = 4;
//
//          For inputString = "[ "one", 2, "three" ]", the output should be
//          countElements(inputString) = 3;
//
//          For inputString = "true", the output should be
//          countElements(inputString) = 1;
//
//          For inputString = "[[1, 2, [3]], 4]", the output should be
//          countElements(inputString) = 4.

namespace CountElements
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            string test = "[\"[   -45,   95]   \", [ 87,  -655]]";
            Console.WriteLine(countElements(test));
            Console.ReadKey();
        }

        static int countElements(string inputString)
        {
            char[] st = inputString.ToCharArray();

            // replcaing the inner chars of "......" into 0-s
            for (int i = 0; i < st.Length;i++)
            {
                if (st[i] == '\"')
                {
                    do
                    {
                        st[i] = '0';
                        i++;
                    } while (i < st.Length - 1 && st[i] != '\"');

                    st[i] = '0';
                }
            }

            // making a string without un-important symbols
            string res = new string(st);
            res = res.Replace("[", "");
            res = res.Replace("]", "");
            res = res.Replace(" ", "");

            // the number of elements is the number of ","-s + 1
            return (res == "") ? 0 : res.Length - res.Replace(",", "").Length + 1;
        }
    }
}
