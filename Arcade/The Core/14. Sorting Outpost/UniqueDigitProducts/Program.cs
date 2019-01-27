using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Let's call product(x) the product of x's digits. Given an array of integers a,
// calculate product(x) for each x in a, and return the number of distinct results you get.
// Example:
//          For a = [2, 8, 121, 42, 222, 23], the output should be
//          uniqueDigitProducts(a) = 3.
//          Here are the products of the array's elements:
//          2: product(2) = 2;
//          8: product(8) = 8;
//          121: product(121) = 1 * 2 * 1 = 2;
//          42: product(42) = 4 * 2 = 8;
//          222: product(222) = 2 * 2 * 2 = 8;
//          23: product(23) = 2 * 3 = 6.
//          As you can see, there are only 3 different products: 2, 6 and 8.

namespace UniqueDigitProducts
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int uniqueDigitProducts(int[] a)
        {
            int[] p = new int[a.Length];
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                p[i] = DigProd(a[i]);
            }

            Array.Sort(p);

            for (int i = 1; i < a.Length; i++)
                count += p[i] != p[i - 1] ? 1 : 0;

            return count + 1;

        }

        static int DigProd(int n)
        {
            char[] d = $"{n}".ToCharArray();
            int p = 1;
            foreach (char i in d) p *= (int)i - (int)'0';
            return p;
        }

    }
}
