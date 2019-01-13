using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
