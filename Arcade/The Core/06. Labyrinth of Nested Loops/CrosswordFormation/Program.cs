using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrosswordFormation
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static bool isPower(int n)
        {
            bool res = false;
            for (int i = 2; i <= (int)Math.Sqrt(n); i++)
            {
                res = IsPowerOfm(n, i);
                if (res) break;
            }

            return n == 1 ? true : res;
        }

        static bool IsPowerOfm(int n, int m)
        {
            bool isPowerOfm = true;

            while (isPowerOfm && n > 1)
            {
                if (n % m > 0) isPowerOfm = false;
                n /= m;
            }

            return isPowerOfm;
        }

    }
}
