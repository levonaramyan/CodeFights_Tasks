using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You are playing an RPG game. Currently your experience points (XP) total is equal to experience.
// To reach the next level your XP should be at least at threshold. If you kill the monster in front of you,
// you will gain more experience points in the amount of the reward.

// PROBLEM: Given values experience, threshold and reward, check if you reach the next level after killing the monster.

namespace ReachNextLevel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(reachNextLevel(1000, 1200, 250));
            Console.ReadKey();
        }

        // Returns true if the experience and reward together will overcome the threshold
        static bool reachNextLevel(int experience, int threshold, int reward)
        {
            return experience + reward >= threshold;
        }

    }
}
