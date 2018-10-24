using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Jumping Jimmy is trying to reach the top of a tall tower!

// Given an integer jumpHeight representing the maximum vertical distance he can ascend in one jump,
// and an array tower representing the vertical distances between each floor of the tower,
// your task is to find the total vertical distance Jimmy is able to travel
// (until he reaches the top of the tower or isn't able to complete the next jump).

// Example:
//          For tower = [3, 1, 2] and jumpHeight = 3, the output should be jumpingJimmy(tower, jumpHeight) = 6.
//          After reaching the top of the tower, Jimmy has ascended a total distance of 3 + 1 + 2 = 6.
//
//          For tower = [1, 2, 3, 4] and jumpHeight = 2, the output should be jumpingJimmy(tower, jumpHeight) = 3.
//          Jimmy is able to complete the first two jumps, but he can't clear a gap of size 3,
//          so the total vertical distance is 1 + 2 = 3.
//
//          For tower = [5, 1, 8, 2, 4, 3, 1, 9, 8, 5, 1] and jumpHeight = 1,
//          the output should be jumpingJimmy(tower, jumpHeight) = 0.
//          Jimmy can't even clear the first gap, so he can't ascend the tower at all

namespace JumpingJimmy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing test tower[] and the height of jump
            int[] tower = new int[] { 3, 1, 2 };
            int jumpHeight = 3;

            Console.WriteLine(jumpingJimmy(tower,jumpHeight));
            Console.ReadKey();
        }

        static int jumpingJimmy(int[] tower, int jumpHeight)
        {
            int dist = 0; // will be the total distance that Jimmy Jumped
            int floor = 0; // will be the floor that Jimmy reached

            // Jumpitng, until the Jump height is less than the floor height
            while (floor < tower.Length && tower[floor] <= jumpHeight)
            {
                int currentJump = jumpHeight - tower[floor];
                floor++;

                // if with one jump can pass more than one floor
                while (floor < tower.Length && tower[floor] <= currentJump)
                {
                    currentJump = jumpHeight - tower[floor];
                    floor++;
                }
            }

            // Calculating the total distance that Jimmy was able to jump
            for (int i = 0; i < floor; i++)
            {
                dist += tower[i];
            }

            return dist;

        }
    }
}
