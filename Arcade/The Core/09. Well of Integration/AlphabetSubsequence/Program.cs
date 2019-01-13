using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphabetSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static bool alphabetSubsequence(string s)
        {
            int len = s.Length;
            bool isAlph = true;
            for (int i = 1; isAlph && i < len; i++)
            {
                if (s[i] <= s[i - 1]) isAlph = false;
            }

            return isAlph;

        }
    }
}
