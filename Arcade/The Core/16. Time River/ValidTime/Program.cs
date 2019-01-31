using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Check if the given string is a correct time representation of the 24-hour clock.
// Example:
//          For time = "13:58", the output should be
//          validTime(time) = true;
//
//          For time = "25:51", the output should be
//          validTime(time) = false;
//
//          For time = "02:76", the output should be
//          validTime(time) = false.

namespace ValidTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ValidTime("25:51"));
            Console.ReadKey();
        }

        static bool validTime(string time)
        {
            return (int.Parse(time.Substring(0, 2)) < 24 && int.Parse(time.Substring(3, 2)) < 60);
        }

        static bool ValidTime(string time)
        {
            return TimeSpan.TryParse(time,out TimeSpan res);
        }
    }
}
