using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyclicString
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int cyclicString(string s)
        {
            int minLen = s.Length;
            for (int i = 0; i < s.Length - 1; i++)
            {
                string t = s.Substring(0, i + 1);
                if (IsRep(t, s) && t.Length < minLen) minLen = t.Length;
            }

            return minLen;
        }

        static bool IsRep(string a, string s)
        {
            bool isOk = true;
            for (int i = 0; isOk && i < s.Length; i++)
                if (s[i] != a[i % a.Length]) isOk = false;
            return isOk;
        }

    }
}
