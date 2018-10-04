using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Check if the given string is a correct time representation of the 24-hour clock.

namespace validTime
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(myValidTime("23:55"));            
            Console.ReadKey();
        }

        // checking with built in method
        static bool validTime(string time)
        {
            TimeSpan b;
            return TimeSpan.TryParse(time, out b);
        }

        // writing the method by my own
        static bool myValidTime(string time)
        {
            bool isTimeForm = time[2] == ':';
            int hour;
            int minutes;
            bool isHour = int.TryParse($"{time[0]}{time[1]}", out hour);
            bool isMin = int.TryParse($"{time[3]}{time[4]}", out minutes);

            return (isTimeForm && isHour && isMin && hour <= 23 && minutes <= 59);
        }
    }
}
