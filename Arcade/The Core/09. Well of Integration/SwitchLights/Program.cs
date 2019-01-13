using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchLights
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[] switchLights(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == 1)
                {
                    for (int j = i; j >= 0; j--)
                    {
                        a[j] = 1 - a[j];
                    }
                }
            }

            return a;

        }
    }
}
