using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// *******************************  Challenge  **************************************
// Alex lives in a small town that only has one store that sells school supplies.
// On the first day of school, she made a list of all the supplies she would need for each class.
// For every new item on the list, she made a note of the price, on a separate list.

// PROBLEM: Given the arrays supplies and prices, your task is to calculate how much
//          Alex's school supplies will cost for this term.

// NOTES:
// The same item may appear more than once in the supplies list, but its price will
// only be logged in prices the first time it appears.
// The names of the items may or may not be pluralized, depending on how many are required.
// To avoid floating point values, all prices will be listed in terms of cents (eg: 325 means $3.25).

namespace schoolSupplies
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing test arrays supplies[] and prices[]
            string[] supplies = new string[] { "2 binders", "5 pens", "3 notebooks", "1 calculator", "4 notebooks", "1 binder", "3 folders" };
            int[] prices = new int[] { 750, 150, 200, 1875, 250 };

            // Applying the method and printing the result of the test
            Console.WriteLine(schoolSupplies(supplies, prices));
            Console.ReadKey();
        }

        // The method returns the total price of expences
        static int schoolSupplies(string[] supplies, int[] prices)
        {
            // Initializing variables and new arrays
            int sumTotal = 0;
            int lenSuppl = supplies.Length;
            int lenPrice = prices.Length;
            int[] counts = new int[lenSuppl]; // will contain the count of current item
            string[] names = new string[lenSuppl]; // will contain the name of current item
            string[] priceNames = new string[lenPrice]; // will contain a name corresponding to the price[item]
            int k = 0;            

            if (lenSuppl > 0)
            {
                for (int i = 0; i < lenSuppl; i++)
                {
                    counts[i] = Convert.ToInt32(supplies[i].Split(' ')[0]); // getting the count
                    names[i] = supplies[i].Split(' ')[1]; // getting the name

                    // considering the first item separately
                    if (i == 0)
                    {
                        priceNames[0] = names[0];
                        sumTotal += counts[0] * prices[0]; 
                        k++;
                    }

                    // if it is not the first item
                    else
                    {
                        bool newName = true; // will be true, if the item is not previosly considered
                        for (int h = 0; h < k; h++)
                        {
                            // if the item was previosly considered
                            if (names[i] == priceNames[h]
                                || names[i] + "s" == priceNames[h]
                                || names[i] == priceNames[h] + "s")
                            {
                                newName = false;
                                sumTotal += counts[i] * prices[h];
                                break;
                            }
                        }

                        // if the item is new
                        if (newName)
                        {
                            priceNames[k] = names[i];
                            sumTotal += counts[i] * prices[k];
                            k++;
                        }
                    }
                }
            }  
            return sumTotal;
        }
    }
}
