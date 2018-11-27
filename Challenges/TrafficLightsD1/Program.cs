using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You're travelling on a long straight road with many stoplights. You've travelled this road many times 
// before and you're very observant, so you're already aware of the location (in metres) and frequency
// (in seconds) of each stoplight, and you've stored these values in the array roadMap.

// As an example of how the data is stored, [15, 9] would represent a stoplight that's 15 metres away
// from your starting point, and its frequency is 9 seconds. In other words, the light will be green for 9 seconds,
// then red for another 9 seconds, then green again for another 9 seconds, etc.

// PROBLEM: Given the roadMap array, your task is to find how long it'll take for you reach the end of the road,
//          assuming you travel at exactly 1 metre per second.

// Notes:
//          You start at a position of 0, at time 0.
//          The timer stops the moment you're able to pass through the final stoplight in the list.
//          At time 0, all the stoplights have just turned green.
//          There's no one else on the road / no obstacles other than the stoplights to obstruct your path.
//          You travel at a constant rate(1 metre per second), so no time is spent accelerating or stopping;
//          the moment the light turns green, you start moving.
// Example:
//          For[[24, 7], [31,15], [50,41]], the output should be 82.
//          You start at position 0, so it takes 24 seconds to reach the first stoplight(which is 24 metres away).
//          This first stoplight has a frequency of 7, which means it's green at 0 seconds, it turns red at 7 seconds,
//          back to green at 14 seconds, then red again st 21 seconds, then it won't turn green again until 28 seconds.
//          Since you arrive at 24 seconds, you'll have to wait 4 seconds for the light to turn green again.
//
//          After the first light turns green, you travel another 7 metres to the seconds stoplight at position 31.
//          By this time, 35 seconds have passed, so the light is already green, and you don't have to stop
//          (this light has a frequency of 15, so it would have started green at 0, turned red at 15, then back
//          to green at 30, until 45, so at 35 seconds it's green).
//
//          You then travel another 19 metres to the final stoplight, which you arrive at after a total of 54 seconds.
//          Since this light has a frequency of 41, it would have turned red at 41 seconds, and will stay red
//          until 82 seconds have passed. After 82 seconds, you're able to make it through the last light,
//          so this is the final answer.
//
//          For [[23,23], [37,30]], the output should be 60.
//          You arrive at the first stoplight at the exact moment it turns red 😡. This means you'll have to wait
//          until another 23 seconds pass, so the time will be 46 by the time you can go.
//
//          After travelling another 14 metres, the time is now 60, which means the second stoplight will have
//          just turned green the instant you arrive at it (it was green until 30 seconds, then back to green right
//          at 60). So you can pass through this final stoplight after 60 seconds.

namespace TrafficLightsD1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing test values
            int[][] test = new int[3][];
            test[0] = new int[] { 24, 7 };
            test[1] = new int[] { 31, 15 };
            test[2] = new int[] { 50, 41 };

            // Testing and printing the result
            Console.WriteLine(trafficLights1D(test));
            Console.ReadKey();
        }

        // The method returns the total time of passing all of the stoplights
        static int trafficLights1D(int[][] roadMap)
        {
            int t = 0; // is the total time of passing until the current stoplight
            int d = 0; // the distance of previous stoplight from the start point
            for (int i = 0; i < roadMap.Length; i++)
            {
                t += roadMap[i][0] - d; // adding the distance between two stoplights
                d = roadMap[i][0]; // keeping the distance of current stoplight
                int sp = roadMap[i][1]; // the changing periodicity of current stoplight

                // if the current stoplight is not green, then get the value of coming green
                t = ((t / sp) % 2 != 0) ? (t / sp + 1) * sp : t;
            }

            return t;
        }
    }
}
