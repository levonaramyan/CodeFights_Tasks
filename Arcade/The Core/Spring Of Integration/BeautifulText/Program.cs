using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulText
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static bool beautifulText(string inputString, int l, int r)
        {
            bool isOk = false;
            int len = inputString.Length;
            for (int i = l; !isOk && i <= r && i <= (len + 1) / 2 - 1; i++)
            {
                if ((len + 1) % (i + 1) == 0)
                {
                    isOk = true;
                    for (int j = i; isOk && j < len; j += i + 1)
                        if (inputString[j] != ' ') isOk = false;
                }
                else isOk = false;
            }

            return isOk;
        }

    }
}
