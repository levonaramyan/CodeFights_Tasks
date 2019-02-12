using System;
using System.Text.RegularExpressions;

namespace reverseParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Your task is to reverse the strings contained in each pair
             * of matching parentheses, starting from the innermost pair.
             * The results string should not contain any parentheses.*/

            // defining some test string s
            string s = "(abc(cba)(ab)(bac)c)";

            //testing the reverseParentheses on s
            string sNew = reverseParentheses(s);
            Console.WriteLine(s);
            Console.WriteLine(sNew);
            Console.ReadLine();
        }

        //A method that reverses a text in each parentheses
        static string reverseParentheses(string s)
        {
            // Defining some variables
            string sNew = "";
            int sLen = s.Length;
            int parPos = sLen;
            bool par = false;

            // Finds the first ")" in i-th position, then goes back and finds the closest "(" in j-th position.
            // then reverses the text between j and i and merged with the right to i rest of the string s
            for (int i = 0; i < sLen; i++)
            {
                if (par == false && s[i] == ')')
                {
                    for (int j = i; j >= 0; j--)
                    {
                        if (s[j] == '(')
                        {
                            for (int k = i - 1; k > j; k--)
                            {
                                sNew += Convert.ToString(s[k]);
                            }
                            parPos = j;
                            break;
                        }
                    }
                    par = true;

                }
                else if (par == true) sNew += Convert.ToString(s[i]);
                
            }

            // merge the left from j rest of string s with the new rearranged string 
            s = s.Remove(parPos, sLen - parPos) + sNew;

            // it checks if in its last pass, it founds parentheses, then it calls the method again
            if (par == true) { s = reverseParentheses(s); }

            // Returning the final value of string s, without any parentheses
            return s;
        }

        /*---------------------------------------------------------------*/
        // SOLUTION 2_using REGEX
        string reverseInParentheses(string inputString)
        {
            string pattern = "[(][^)^(]*[)]";

            while (inputString.Contains("("))
            {
                string matchTemp = Regex.Match(inputString, pattern).Value;
                inputString = inputString.Replace(matchTemp, ReverseString(matchTemp.Substring(1, matchTemp.Length - 2)));
            }

            return inputString;
        }

        static string ReverseString(string input)
        {
            char[] output = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
                output[i] = input[input.Length - i - 1];

            return new string(output);
        }
    }
}
