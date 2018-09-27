using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isLucky
{
    class Program
    {
        static void Main(string[] args)
        {
            //This program calculates and return, whether the ticket is lucky or not?
            //The lucky ticket is when the sum of the one digit numbers of the first half equals to second.
            //The count of the digits in the ticket is always even

            //Defining a ticket number for testing
            int n = 1230;
            
            //Checking whether the ticket n is lucky, or not?
            Console.WriteLine(isLucky(n));
            Console.ReadKey();
        }

        //The method returns a bool which is true if the ticket with number n is lucky
        static bool isLucky (int n)
        {
            //defining the variables of sums of first and second half of ticket n
            int firstHalf = 0;
            int secondHalf = 0;

            //converting the ticket number to string
            string n_Str = n.ToString();
            int n_Len = n_Str.Length;

            //calculating the sums of first and second half of the ticket number, symbol by symbol
            for (int i = 0; i <= n_Len - 1; i++)
            {
                if ((i + 1) <= n_Len / 2)
                {
                    firstHalf += Convert.ToInt32(n_Str[i]);
                }
                else secondHalf += Convert.ToInt32(n_Str[i]);
            }

            //returning true if Lucky: firstHalf == secondHalf
            return (firstHalf == secondHalf);
        }
    }
}
