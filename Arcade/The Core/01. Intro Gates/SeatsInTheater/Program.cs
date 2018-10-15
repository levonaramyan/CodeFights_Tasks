using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Your friend advised you to see a new performance in the most popular theater in the city.
// He knows a lot about art and his advice is usually good, but not this time: the performance
// turned out to be awfully dull. It's so bad you want to sneak out, which is quite simple,
// especially since the exit is located right behind your row to the left.
// All you need to do is climb over your seat and make your way to the exit.
// The main problem is your shyness: you're afraid that you'll end up
// blocking the view(even if only for a couple of seconds) of all the people who sit behind you
// and in your column or the columns to your left.To gain some courage, you decide to calculate
// the number of such people and see if you can possibly make it to the exit without disturbing too many people.

// PROBEM: Given the total number of rows and columns in the theater (nRows and nCols, respectively),
// and the row and column you're sitting in, return the number of people who sit strictly behind you
// and in your column or to the left, assuming all seats are occupied.

// Example:
//         For nCols = 16, nRows = 11, col = 5, and row = 3, the output should be
//         seatsInTheater(nCols, nRows, col, row) = 96.

namespace SeatsInTheater
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(seatsInTheater(16, 11, 5, 3));
            Console.ReadKey();
        }

        // Returning a number of seats which are strictly behind you and in your column or to the left 
        static int seatsInTheater(int nCols, int nRows, int col, int row)
        {
            return (nCols - col + 1) * (nRows - row);
        }
    }
}
