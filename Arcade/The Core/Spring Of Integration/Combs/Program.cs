using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combs
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int combs(string comb1, string comb2)
        {
            int minPurse = comb1.Length + comb2.Length;
            int combination1 = GetMinPurse(comb1, comb2);
            int combination2 = GetMinPurse(comb2, comb1);


            return combination2 < combination1 ? combination2 : combination1;
        }

        static int GetMinPurse(string comb1, string comb2)
        {
            bool areOverlaping = false;
            int len1 = comb1.Length;
            int len2 = comb2.Length;
            int minPurse = len1 + len2;

            for (int i = 0; i < len1; i++)
            {
                areOverlaping = false;
                int j = i;
                for (; j < len1 && j - i < len2; j++)
                {
                    if (comb1[j] == comb2[j - i] && comb1[j] == '*')
                    {
                        areOverlaping = true;
                        break;
                    }
                }

                //if (!areOverlaping && (i + len2) < minPurse) minPurse = i + len2;
                if (!areOverlaping)
                {
                    int curLen = i + len2 >= len1 ? i + len2 : len1;
                    minPurse = curLen <= minPurse ? curLen : minPurse;
                }
            }

            return minPurse;
        }
    }
}
