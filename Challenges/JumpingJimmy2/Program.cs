using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Jumping Jimmy is back, and he's ready to tackle a new tower!
// He has the same goal as before(keep jumping as high as possible until he gets to the top or can't jump any higher),
// but this tower is a little different from the last one - some of the floors can affect Jimmy's jump height!
// More specifically, there are power floors (which increase his jump height by 1),
// and poison floors(which decrease his jump height by 1). The indices of these floors are represented
// by the power and poison arrays.Each index is 0-based, and does not include the initial floor that Jimmy begins on.

// PROBLEM: Given tower(an array representing the gaps between each pair of consecutive floors), as well as power,
// poison, and jumpHeight, your task is to find the height of the highest floor in the tower that
// Jimmy will be able to reach.

// Notes: Both power and poison are sorted in ascending order, with no repeat elements.
//        Elements of power and poison are mutually exclusive - there are no floors that have both attributes.
// Example:
//          For tower = [1, 4, 3, 2, 2, 2, 2, 1, 4, 4, 2, 3, 3, 4, 1, 4, 2, 1, 2, 4, 1, 2, 2, 4, 1],
//          power = [1, 3, 11], poison = [2, 4, 5, 7, 12, 20, 22], and jumpHeight = 4, the output should be
//          jumpingJimmy2(tower, power, poison, jumpHeight) = 56.
//          At first the climb is looking promising for Jimmy, as he lands on some power floors,
//          while avoiding poison floors.But his luck soon runs out, as he then encounters three poison floors,
//          and becomes unable to reach the next floor. The height of the last reachable platform is 56.

namespace JumpingJimmy2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing test values
            int[] tower = new int[] { 1, 4, 3, 2, 2, 2, 2, 1, 4, 4, 2, 3, 3, 4, 1, 4, 2, 1, 2, 4, 1, 2, 2, 4, 1 };
            int[] power = new int[] { 1, 3, 11 };
            int[] poison = new int[] { 2, 4, 5, 7, 12, 20, 22 };
            int jumpHeight = 4;

            // Testing and printing the result
            Console.WriteLine(jumpingJimmy2(tower, power, poison, jumpHeight));
            Console.ReadKey();
        }

        // Returns the maximum total height that Jimmy will be able to jump
        static int jumpingJimmy2(int[] tower, int[] power, int[] poison, int jumpHeight)
        {
            int dist = 0; // will be the total jumped height
            int floor = 0; // will be the current floor that Jimmy reached
            int l = 0; // the coming index of poison[], where he will decrease the jumping height
            int h = 0; // the coming index of power[], where he will increase the jumping height

            // Current Height that Jimmy can Jump
            int curHeight = jumpHeight + ((h < power.Length && floor - 1 == power[h]) ? 1 :
                                          (l < poison.Length && floor - 1 == poison[l] ? -1 : 0));

            // While there are more floors and Jimmy-s jump height is enough, continue jumping
            while (floor < tower.Length && tower[floor] <= curHeight)
            {
                int currentJump = curHeight - tower[floor];
                floor++;

                // Checking if Jimmy can jump more floors at once
                while (floor < tower.Length && tower[floor] <= currentJump)
                {
                    currentJump = currentJump - tower[floor];
                    floor++;
                }

                // If Jimmy passed the current power/poison floor, go to the next one
                while (l < poison.Length - 1 && poison[l] < floor - 1) l++;
                while (h < power.Length - 1 && power[h] < floor - 1) h++;

                // If Jimmy reaches the power/poison floor, change its jump-height
                curHeight = curHeight + ((h < power.Length && floor - 1 == power[h]) ? 1 :
                                            (l < poison.Length && floor - 1 == poison[l] ? -1 : 0));
            }

            // Calculate the total height that Jimmy jumped
            for (int i = 0; i < floor; i++)
            {
                dist += tower[i];
            }

            return dist;
        }
    }
}
