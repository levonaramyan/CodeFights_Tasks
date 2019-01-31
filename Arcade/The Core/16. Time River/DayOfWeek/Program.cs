using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Whenever you decide to celebrate your birthday you always do this your favorite café,
// which is quite popular and as such usually very crowded. This year you got lucky:
// when you and your friend enter the café you're surprised to see that it's almost empty.
// The waiter lets slip that there are always very few people on this day of the week.
// You enjoyed having the café all to yourself, and are now curious about the next time
// you'll be this lucky. Given the current birthdayDate, determine the number of years until
// it will fall on the same day of the week.
// For your convenience, here is the list of months lengths(from January to December, respectively) :
//      Months lengths: 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31.
// Please, note that in leap years February has 29 days.If your birthday is on the 29th of February,
// you celebrate it once in four years.Otherwise you birthday is celebrated each year.
// Example:
//          For birthdayDate = "02-01-2016", the output should be
//          dayOfWeek(birthdayDate) = 5.
//          February 1 in 2016 is a Monday. The next year in which this same date will be Monday too
//          is 2021. 2021 - 2016 = 5, which is the answer.

namespace DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int dayOfWeek(string birthdayDate)
        {
            DateTime bd = DateTime.ParseExact(birthdayDate, "MM-dd-yyyy", CultureInfo.InvariantCulture);
            var dOW = bd.DayOfWeek;
            int addYear = (bd.Day == 29 && bd.Month == 2) ? 4 : 1;
            int next = addYear;

            while (true)
            {
                bool skip = bd.Year == 2096;
                bd = (skip) ? bd.AddYears(2 * addYear) : bd.AddYears(addYear);
                if (dOW == bd.DayOfWeek) break;
                next += (skip) ? 2 * addYear : addYear;
            }

            return next;

        }
    }
}
