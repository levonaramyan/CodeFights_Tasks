using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You need to move a large rectangular box over a rough, hazardous surface. Since you don't have any tools
// to help you move it, your only option is to perform a series of 90 degree rotations (basically just
// repeatedly pushing the box over onto its side).

// Every time you rotate the box, it hits the ground and some damage is done - the amount of damage depends
// on the fragility of the side of the box that it landed on, as well as the roughness of the ground in the
// region where it was dropped.

// More specifically, we calculate the damage by multiplying the box's fragility by the ground's roughness
// for each pair of vertically adjacent cells. So for the box above, dropping it into its current position
// would cause a total of 4*7 + 0*4 + 5*9 = 73 damage.And the next turn will cause 5*7 + 3*0 + 4*7 = 63 damage.

// PROBLEM: Given boxWeakness, an array of strings representing how fragile the box is in each location,
//          and surfaceRoughness, a string of digits representing how damaging each section of the surface is,
//          your task is to find the total amount of damage the box will receive after being rotated across the
//          entire surface

// Note: The length of the surface might not perfectly fit the box; if there's some overhang on the last step,
//       that part won't be damaged.
// Example:
//          For
//          boxWeakness = ["01",
//                         "21",
//                         "10"]
//          and surfaceRoughness = "39513695380152438476", the output should be
//          fragileRotatingBox(boxWeakness, surfaceRoughness) = 56.
//          The total damage is 1*3 + 0*9 + 0*5 + 1*1 + 1*3 + 1*6 +0*9 + 0*5 + 2*3 + 1*8 + 1*0 + 0*1 +
//                                                      0*5 + 1*2 + 1*4 + 1*3 + 0*8 + 0*4 + 2*7 + 1*6 = 56

namespace FragileRotatingBox
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing test box[] and surface roundness
            string[] box = new string[] {"01",
                                         "21",
                                         "10" };

            string surface = "39513695380152438476";

            // Testing and printing the result
            Console.WriteLine(fragileRotatingBox(box,surface));
            Console.ReadKey();
        }

        // Returns the total amount of damage, after rotating through the whole range of surface
        static int fragileRotatingBox(string[] boxWeakness, string surfaceRoughness)
        {
            int sum = 0, iDir = -1, jDir = 1;// the total damage, and the identifiers of the direction of i and j
            int boxI = boxWeakness.Length; // the height of the box
            int boxJ = boxWeakness[0].Length; // the width of the box
            int i = boxWeakness.Length - 1, j = 0; // the lowest left point of the box 
            bool iIsActive = false; // indicates whether it needs to go through j index or i index

            // Until the end of the surface, rotate through the box edges, anti-clockwise
            for (int k = 0; k < surfaceRoughness.Length; k++)
            {
                sum += (boxWeakness[i][j] - '0') * (surfaceRoughness[k] - '0');
                i += iIsActive ? iDir : 0;
                j += iIsActive ? 0 : jDir;

                // When reaching the border, change the direction, and start to go through next dimension
                if (i < 0 || i == boxI) { i = i - iDir; iDir *= -1; iIsActive = false; }
                if (j < 0 || j == boxJ) { j = j - jDir; jDir *= -1; iIsActive = true; }
            }

            return sum;
        }

    }
}
