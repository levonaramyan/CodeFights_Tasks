using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileNaming
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string[] fileNaming(string[] names)
        {
            int length = names.Length;
            string tempName = "";
            for (int i = 1; i < length; i++)
            {
                bool lookBack = true;
                int k = 0;
                while (lookBack == true)
                {
                    lookBack = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (k == 0) tempName = names[i];
                        if (names[i] == names[j])
                        {
                            k++;
                            names[i] = $"{tempName}({k})";
                            lookBack = true;
                        }
                    }
                }
            }

            return names;
        }
    }
}
