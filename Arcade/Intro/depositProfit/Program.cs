using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You have deposited a specific amount of money into your bank account.
// Each year your balance increases at the same growth rate. With the assumption
// that you don't make any additional deposits, find out how long it would take
// for your balance to pass a specific threshold. Of course you don't want to wait
// too long, so you know that the answer is not greater than 6.

namespace depositProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            // testing and printing the result
            Console.WriteLine(depositProfit(100, 20, 170));
            Console.ReadKey();
        }

        // The method returns the years, that are needed to pass the threshold
        static int depositProfit(int deposit, int rate, int threshold)
        {
            int years = 0;
            float sum = deposit;
            for (; sum < threshold; years++)
            {
                sum += sum * rate / 100;
            }
            return years;
        }
    }
}
