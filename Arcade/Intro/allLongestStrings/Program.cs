using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allLongestStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            //testing the method on a custom string array

            string[] testStringArray = new string[5] { "bla", "alba","coco","aa","bb" };
            string[] resultString = allLongestStrings(testStringArray);

            //Writing the resulting longest string array in Console 

            for (int i = 0; i <= resultString.Length-1;i ++)
            {
                Console.WriteLine(resultString[i]);
            }
            Console.ReadKey();

        }

        //A method that returns an array of longest string from an initial string array
        static string[] allLongestStrings(string[] inputArray)
        {
            //defining the parameters
            int maxlen = 0;
            int maxcount = 0;

            //calculating the length of an initial array
            int lenArr = inputArray.Length;

            //defining a new array which will contain the lentghs of all strings in initial array.
            //maxcount = the count of maximum length (maxlen) strings in the array
            int[] arrObjLen = new int[lenArr];
            for (int i=0; i <= lenArr-1; i++)
            {
                arrObjLen[i] = inputArray[i].Length;
                if (maxlen < arrObjLen[i])
                {
                    maxlen = arrObjLen[i];
                    maxcount = 1;
                } else if(maxlen == arrObjLen[i])
                {
                    maxcount++; 
                }
            }

            //creating a new string array with the longest strings
            string[] longestStrings = new string[maxcount];
            int t = 0;
            for (int j=0; j<=lenArr-1; j++)
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
