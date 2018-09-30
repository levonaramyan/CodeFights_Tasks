using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You are given an array of integers representing coordinates of obstacles situated on a straight line.
// Assume that you are jumping from the point with coordinate 0 to the right.
// You are allowed only to make jumps of the same length represented by some integer.
// PROBLEM: Find the minimal length of the jump enough to avoid all the obstacles.

namespace avoidObstacles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing Test array
            int[] testArray = new int[] { 6, 5, 8, 9, 13, 14 };

            Console.WriteLine(avoidObstacles(testArray));
            Console.ReadKey();
        }

        // The method calculates the minimum jump to avoid all the obstacles
        static int avoidObstacles(int[] inputArray)
        {
            // Initializing variables
            int length = inputArray.Length; // length of array
            int minJump = 1; // the initial value of min jump
            bool jumpFound; // will get a value false, if we meet the obstacle

            // checking the possible jumps, from 2 to finding smallest possible
            do
            {
                jumpFound = true;
                ++minJump;
                foreach (int obst in inputArray)
                {
                    if (obst % minJump == 0) jumpFound = false;
                }
            } while (!jumpFound);

            return minJump; // returning the found smallest jump
        }
    }
}
