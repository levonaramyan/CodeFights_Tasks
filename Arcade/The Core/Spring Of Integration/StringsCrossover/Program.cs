using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsCrossover
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int stringsCrossover(string[] inputArray, string result)
        {
            int c = 0;
            for (int i = 0; i < inputArray.Length - 1; i++)
                for (int j = i + 1; j < inputArray.Length; j++)
                    if (IsGoodPair(inputArray[i], inputArray[j], result)) c++;
            return c;
        }

        static bool IsGoodPair(string a, string b, string s)
        {
            bool isOk = true;
            for (int i = 0; isOk && i < a.Length; i++) if (s[i] != a[i] && s[i] != b[i]) isOk = false;
            return isOk;
        }
    }
}
