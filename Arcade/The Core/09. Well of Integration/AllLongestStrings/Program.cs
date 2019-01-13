using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllLongestStrings
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string[] allLongestStrings(string[] inputArray)
        {
            int maxlen = 0;
            int maxcount = 0;
            int lenArr = inputArray.Length;
            int[] arrObjLen = new int[lenArr];
            for (int i = 0; i <= lenArr - 1; i++)
            {
                arrObjLen[i] = inputArray[i].Length;
                if (maxlen < arrObjLen[i])
                {
                    maxlen = arrObjLen[i];
                    maxcount = 1;
                }
                else if (maxlen == arrObjLen[i])
                {
                    maxcount++;
                }
            }

            string[] longestStrings = new string[maxcount];
            int t = 0;
            for (int j = 0; j <= lenArr - 1; j++)
            {
                if (arrObjLen[j] == maxlen)
                {
                    longestStrings[t] = inputArray[j];
                    t++;
                }
            }
            return longestStrings;
        }
    }
}
