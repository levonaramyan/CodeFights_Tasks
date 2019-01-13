using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Consider two following representations of a non-negative integer:
// A simple decimal integer, constructed of a non-empty sequence of digits from 0 to 9;
// An integer with at least one digit in a base from 2 to 16 (inclusive),
// enclosed between # characters, and preceded by the base, which can only be a number
// between 2 and 16 in the first representation. For digits from 10 to 15
// characters a, b, ..., f and A, B, ..., F are used.
// Additionally, both representations may contain underscore(_) characters;
// they are used only as separators for improving legibility of numbers and can be ignored while processing a number.
// PROBLEM: Your task is to determine whether the given string is a valid integer representation.
// Note: this is how integer numbers are represented in the programming language Ada.
// Example:
//          For line = "123_456_789", the output should be
//          adaNumber(line) = true;
//
//          For line = "16#123abc#", the output should be
//          adaNumber(line) = true;
//
//          For line = "10#123abc#", the output should be
//          adaNumber(line) = false;
//
//          For line = "10#10#123ABC#", the output should be
//          adaNumber(line) = false;
//
//          For line = "10#0#", the output should be
//          adaNumber(line) = true;
//
//          For line = "10##", the output should be
//          adaNumber(line) = false.

namespace AdaNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static bool adaNumber(string line)
        {
            bool atLeastOneDigit = false;
            int len = line.Length;
            if (line[len - 1] == '#')
            {
                int i = 0;
                int theBase = 0;

                while (line[i] != '#' && theBase <= 16)
                {
                    if (line[i] != '_')
                    {
                        if ('0' <= line[i] && line[i] <= '9')
                        {
                            theBase = theBase * 10 + (line[i] - '0');
                        }
                        else
                        {
                            return false;
                        }
                    }
                    i++;
                }
                if (theBase < 2 || theBase > 16)
                {
                    return false;
                }
                i++;

                while (i < len - 1)
                {
                    if (line[i] != '_')
                    {
                        var digit = -1;
                        if ('a' <= line[i] && line[i] <= 'f')
                        {
                            digit = line[i] - 'a' + 10;
                        }
                        if ('A' <= line[i] && line[i] <= 'F')
                        {
                            digit = line[i] - 'A' + 10;
                        }
                        if ('0' <= line[i] && line[i] <= '9')
                        {
                            digit = line[i] - '0';
                        }
                        if (0 <= digit && digit < theBase)
                        {
                            atLeastOneDigit = true;
                        }
                        else return false;
                    }
                    i++;
                }
            }
            else
            {
                foreach (char i in line)
                {
                    if (i != '_')
                    {
                        if ('0' <= i && i <= '9')
                        {
                            atLeastOneDigit = true;
                        }
                        else return false;
                    }
                }
            }
            return atLeastOneDigit;
        }
    }
}
