using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// One night you go for a ride on your motorcycle. At 00:00 you start your engine, and the built-in timer
// automatically begins counting the length of your ride, in minutes. Off you go to explore the neighborhood.
// When you finally decide to head back, you realize there's a chance the bridges on your route home are up,
// leaving you stranded! Unfortunately, you don't have your watch on you and don't know what time it is.
// All you know thanks to the bike's timer is that n minutes have passed since 00:00.

// PROBLEM: Using the bike's timer, calculate the current time. Return an answer as the sum of digits
//          that the digital timer in the format hh:mm would show.

// Example: For n = 240, the output should be
//          lateRide(n) = 4.
//          Since 240 minutes have passed, the current time is 04:00. The digits sum up to 0 + 4 + 0 + 0 = 4,
//          which is the answer.

//          For n = 808, the output should be
//          lateRide(n) = 14.
//          808 minutes mean that it's 13:28 now, so the answer should be 1 + 3 + 2 + 8 = 14

namespace LateRide
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(lateRide(240));
            Console.ReadKey();
        }

        // Returns the sum of digits of a time, converted into 24 hour hh:mm format.
        static int lateRide(int n)
        {
            int a = n % 60; // getting the minutes
            int b = n / 60; // getting the hours
            return (a % 10 + a / 10 + b % 10 + b / 10); // returns the sum of all digits in a and b
        }
    }
}
