using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// In tennis, a set is finished when one of the players wins 6 games and the other one wins less than 5,
// or, if both players win at least 5 games, until one of the players wins 7 games.

// PROBLEM: Determine if it is possible for a tennis set to be finished with the score score1 : score2.

namespace TennisSet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(tennisSet(7,5));
            Console.ReadKey();
        }

        // Returns true, if the score could be a resut of a tennis set 
        static bool tennisSet(int score1, int score2)
        {
            int min;
            int max;
            if (score1 >= score2)
            {
                min = score2;
                max = score1;
            }
            else
            {
                max = score2;
                min = score1;
            }

            return ((max == 7 && min >= 5 && min < max) || (max == 6 && min <= 4));


        }

    }
}
