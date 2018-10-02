using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given an encoded string, return its corresponding decoded string.
// The encoding rule is: k[encoded_string], where the encoded_string
// inside the square brackets is repeated exactly k times.Note:
// k is guaranteed to be a positive integer.
// Note that your solution should have linear complexity because
// this is what you will be asked during an interview.
//
//For s = "2[b3[a]]", the output should be decodeString(s) = "baaabaaa"



namespace decodeString
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(decodeString("z4[50[20[y]]]zzz2[2[abc]]"));
            //Console.WriteLine(simpleString("z4[5[2[y]]]zzz2[2[abc]]", "y",6,8,2));
            Console.ReadKey();
        }

        static string decodeString(string s)
        {
            if (s.Contains("]"))
            {
                int sLen = s.Length; // the length of the string
                int counter = 0; // will be the counter of a bracket group
                int endBrackIndex = s.IndexOf("]"); // the index of first "]" bracket
                int startBracketIndex = 0; // the index of corresponding "[" bracket
                string part1 = ""; // the part of string before a code in brackets
                string part2 = ""; // the part of string after a code in brackets
                string code = ""; // the string inside of brackets

                // finding the corresponding "[" of first "]" bracket
                for (int i = endBrackIndex-1; i >= 0; i--)
                {                    
                    if (s[i] == '[')
                    {
                        startBracketIndex = i;
                        counter = findTheCounter(s, startBracketIndex - 1); // getting the counter for it
                        break;
                    }
                    else code = s[i] + code ; // taking the code inside of brackets
                }

                // simplifying the string, ex. "ba3[8[4[2[a]]]]" -->  "ba192[a]", and getting params.
                s = simpleString(s, ref code, ref startBracketIndex, ref endBrackIndex, ref counter);
                sLen = s.Length; // the length of a new string
                int cLen = $"{counter}".Length; // the number of digits in counter
                code = decodeBrackets(code, counter); // opening the brackets, and writing on code

                // taking strings part1 and part2
                if (startBracketIndex - cLen > 0)
                    part1 = s.Remove(startBracketIndex - cLen, sLen - (startBracketIndex - cLen));
                if (endBrackIndex < sLen - 1)
                    part2 = s.Substring(endBrackIndex + 1);

                // merging three parts toether and returning in s
                s = $"{part1}{code}{part2}";
                s = decodeString(s); // recursion, looking again for more brackets
            }

            return s;
        }

        // The method takes the code and return count times of this code
        static string decodeBrackets(string code, int count)
        {
            string decoded = "";

            // METHOD 1: Standard decoding
            //for (int i = 1; i <= count; i++) decoded += code;

            // METHOD 2: binary duplication decoding
            //string binary = Convert.ToString(count, 2);
            //int bLen = binary.Length;
            //for (int i = bLen -1; i >= 0; i--)
            //{
            //    int numBin = Convert.ToInt32($"{binary[i]}");
            //
            //    if (numBin == 1) decoded += code;
            //    code += code;
            //}

            // METHOD 3: decimal multiplication decoding
            string dec = Convert.ToString(count);
            int dlen = dec.Length;
            for (int i = dlen-1; i >= 0; i--)
            {
                string codeDec = code;
                int numDec = Convert.ToInt32($"{dec[i]}");

                if (numDec != 0)
                {
                    for (int j = 1; j <= numDec; j++)
                    {
                        decoded = $"{decoded}{code}";
                    }
                }

                for (int j = 1; j <= 9; j++)
                {
                    code = $"{code}{codeDec}";
                }
            }


            return decoded;
        }

        // The method gets the string s and the position of "["
        // and returns the counter before that bracket
        static int findTheCounter(string s, int end)
        {
            string countStr = "";
            for (int i = end; i >=0; i--)
            {
                string charS = Convert.ToString(s[i]);
                int numChar;
                if (int.TryParse(charS, out numChar))
                {
                    countStr = charS + countStr;
                }
                else break;
            }

            if (countStr == "") countStr = "0";

            return Convert.ToInt32(countStr);
        }


        // This method returns a simplified string, like "ba3[8[4[2[a]]]]" -->  "ba192[a]"
        // it changes also the corresponding parameters, code, startBracketIndex, endBracketIndex, counter
        static string simpleString(string s, ref string code, ref int startBracketIndex, ref int endBrackIndex, ref int counter)
        {
            int sLen = s.Length; // the length of initial string s
            int cLen = ($"{counter}").Length; // the length of initial counter

            //checking if there are more brackets around them
            while (endBrackIndex < sLen-1 && startBracketIndex - cLen > 1
                && s[endBrackIndex +1] == ']' && s[startBracketIndex - cLen -1] == '[')
            {
                int counter2 = findTheCounter(s, startBracketIndex - cLen - 2); // finding the next counter
                int cLen2 = ($"{counter2}").Length; // the number of digits in counter2
                counter = counter * counter2; // calculating the resulting counter
                int newCLen = ($"{counter}").Length; // taking the number of its digits                

                string part1 = ""; // the first part, before current brackets
                if (startBracketIndex - cLen - cLen2 - 1 > 0)
                    part1 = s.Remove(startBracketIndex - cLen - cLen2 - 1, sLen - (startBracketIndex) + cLen + cLen2 + 1);

                string part2 = ""; // the second part,after he brackets
                if (endBrackIndex + 1 < sLen - 1)
                    part2 = s.Substring(endBrackIndex + 2);

                s = $"{part1}{counter}[{code}]{part2}"; // mergin different parts into s
                startBracketIndex = part1.Length + newCLen; // updating the index of "["
                endBrackIndex = startBracketIndex + 1 + code.Length; // updating the index of "]"

                sLen = s.Length; // updating the length of s
                cLen = ($"{counter}").Length; // updating the number of digits of a counter
            }        

            return s;
        }
    }
}
