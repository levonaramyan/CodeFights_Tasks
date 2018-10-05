using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given an integer product, find the smallest positive (i.e. greater than 0) integer
// the product of whose digits is equal to product. If there is no such integer, return -1 instead.
// Example:
// For product = 12, the output should be: digitsProduct(product) = 26;
// For product = 19, the output should be: digitsProduct(product) = -1.

namespace digitsProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(digitsProduct(0));
            Console.ReadKey();
        }

        // The method returs the number appropriately, taking in acoount also exceptions
        static int digitsProduct(int product)
        {
            int result = -1;
            if (!int.TryParse(findDigits(product), out result)) result = -1; // -1, if impossible to divide to digits
            if (product == 1) result = 1;
            return result;
        }

        // The method returns a string which contains the number, the product of which digits is equal to product
        static string findDigits(int product)
        {
            bool isPosiible = true;
            string digits = "";
            int initial = product;

            // finding necessary digits, if not then returning false
            if (!(product == 0 || product ==1))
            {
                for (int i = 9; i >= 2; i--)
                {
                    if (product % i == 0)
                    {
                        product = product / i;
                        digits = findDigits(product) + i + digits;
                        break;
                    }

                    if (i == 2) isPosiible = false;
                }
            }
            
            // returning the result, a string of digits, 10, "" or "a" (if returned above false)
            return (isPosiible? (initial == 0 ? "10" : (initial == 1 ? "" : digits)) : "a");
        }
    }
}
