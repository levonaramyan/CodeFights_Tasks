using System;
using System.Globalization;

// Your Math teacher takes education very seriously, and hates it when a class is missed
// or canceled for any reason. He even made up the following rule: if a class is missed
// because of a holiday, the teacher will compensate for it with a makeup class after school.
// You're given an array, daysOfTheWeek, with the weekdays on which your teacher's classes
// are scheduled, and holidays, representing the dates of the holidays throughout
// the academic year(from 1st of September in year to 31st of May in year + 1).
// How many times will you be forced to stay after school for a makeup class because of
// holiday conflicts in the current academic year?
// For your convenience, here is the list of month lengths(from January to December, respectively) :
//      Month lengths: 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31.
//      Please note that in leap years February has 29 days.
// Example
//          For year = 2015, daysOfTheWeek = [2, 3], and
//          holidays = ["11-04", "02-22", "02-23", "03-07", "03-08", "05-09"],
//          the output should be
//          missedClasses(year, daysOfTheWeek, holidays) = 3.
//          November 4th of 2015 is a Wednesday, February 23th of 2016 and March 8th of 2016 are Tuesdays,
//          and the other holidays fall on Mondays.Classes are scheduled on Wednesdays and Tuesdays,
//          so there will be only 3 missed classes.

namespace MissedClasses
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int missedClasses(int year, int[] daysOfTheWeek, string[] holidays)
        {
            int y = year;
            int count = 0;
            for (int i = 0; i < holidays.Length; i++)
            {
                year = (int.Parse(holidays[i].Substring(0, 2)) < 9) ? y + 1 : y;
                DayOfWeek hol = DateTime.ParseExact($"{year}-{holidays[i]}", "yyyy-MM-dd",
                                                    CultureInfo.InvariantCulture).DayOfWeek;
                for (int j = 0; j < daysOfTheWeek.Length; j++)
                    if ((int)hol == daysOfTheWeek[j] % 7) count++;
            }

            return count;
        }
    }
}
