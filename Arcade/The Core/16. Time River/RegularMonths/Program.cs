using System;
using System.Globalization;

// In an effort to be more innovative, your boss introduced a strange new tradition:
// the first day of every month you're allowed to work from home.
// You like this rule when the day falls on a Monday, because any excuse to skip rush hour traffic is great!
// You and your colleagues have started calling these months regular months.
// Since you're a fan of working from home, you decide to find out how far away the nearest 
// regular month is, given that the currMonth has just started.
// For your convenience, here is a list of month lengths(from January to December, respectively) :
//      Month lengths: 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31.
//      Please, note that in leap years February has 29 days.
// Example:
//          For currMonth = "02-2016", the output should be
//          regularMonths(currMonth) = "08-2016".
//          February of 2016 year is regular, but it doesn't count since it has started already,
//          so the next regular month is August of 2016 - which is the answer.

namespace RegularMonths
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string regularMonths(string currMonth)
        {
            DateTime current = DateTime.ParseExact("01-" + currMonth, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            while (true)
            {
                current = current.AddMonths(1);
                if (current.DayOfWeek == DayOfWeek.Monday) break;
            }

            return current.ToString("MM-yyyy", CultureInfo.InvariantCulture);
        }
    }
}
