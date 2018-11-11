using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

// Recerse Challenge!
// Test1:       Input: time: "1:23PM"
//              Expected Output: "12:23PM"
//
// Test2:       Input: time: "4:57AM"
//              Expected Output: "3:57AM"
//
// Test3:       Input: time: "9:00PM"
//              Expected Output: "8:00PM"

namespace FallBack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(fallBack("1:23PM"));
            Console.ReadKey();
        }

        // Returns the time in string format, one hour before
        static string fallBack(string time)
        {
            return DateTime.ParseExact(time, "h:mmtt", CultureInfo.InvariantCulture).AddHours(-1).
                ToString("h:mmtt", CultureInfo.InvariantCulture);
        }
    }
}
