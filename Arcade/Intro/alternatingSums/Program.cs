using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alternatingSums
{
    class Program
    {
        static void Main(string[] args)
        {
            //Several people are standing in a row and need to be divided into two teams.
            //The first person goes into team 1, the second goes into team 2, the third goes
            //into team 1 again, the fourth into team 2, and so on.
            // PROBLEM: select an array and return the total weigths of team1 and team2

            // defining a test array
            int[] a = new int[] { 50, 60, 60, 45, 70 };

            // defining ann 2 comp. array which will contain the weights of the teams
            int[] teams = new int[2];

            // calculating and printing out the weights of two teams
            teams = alternatingSums(a);
            Console.WriteLine(teams[0]);
            Console.WriteLine(teams[1]);

            // Delay
            Console.ReadKey();
        }

        // the method selects the array a[] of weights and return a 2 comp. array with weights of team1 and team2
        static int[] alternatingSums(int[] a)
        {
            // defining a two component array for teams weights
            int[] teams = new int[2] { 0, 0 };

            // calculating the total wights
            for (int i = 0; i < a.Length; i++)
            {
                if (i % 2 == 0)
                {
                    teams[0] += a[i];
                }
                else teams[1] += a[i];
            }

            // returning the teams[team1,team2] array of weights
            return teams;
        }
    }
}
