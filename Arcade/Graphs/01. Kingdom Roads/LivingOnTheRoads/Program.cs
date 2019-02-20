using System;
using System.Collections.Generic;
using System.Linq;

// In a kingdom far, far away, there lives a king Byteasar IX. The history of the kingdom
// is rich with events and actions, most of which has something to do with the cities
// of that kingdom. King Byteasar doesn't want to go down in history, and, most of all,
// he doesn't want to have anything to do with the cities of the kingdom. Cities are lame!
// Instead, king Byteasar wants to focus on the roads, which is why he issued a new decree:
// from now on, all roads are considered to be cities, and all cities are considered
// to be roads.Now his gratefuller subjects pack their livings and move out from the cities
// to the roads, and the cartographers are busy with building a new roadRegister of the kingdom.
// All roads of the kingdom are to be named by the cities they connect
// (i.e. [city1, city2], city1<city2), sorted lexicographically and enumerated starting from 0.
// A new road register for such a system should be created.
// Your task is to help the cartographers with building the new road register.
// Handle the challenge, and the glorious kingdom of Byteasar IX will never have to deal
// with the tasks related to cities ever again!
// Example:
//          For
//          roadRegister = [
//          [false, true, true, false, false, false],
//          [true,  false, false, true,  false, false],
//          [true,  false, false, false, false, false],
//          [false, true,  false, false, false, false],
//          [false, false, false, false, false, true ],
//          [false, false, false, false, true,  false]
//          ]
//          the output should be
//          livingOnTheRoads(roadRegister) = [
//            [false, true,  true,  false],
//            [true,  false, false, false],
//            [true,  false, false, false],
//            [false, false, false, false]
//          ]
//          Here's how the new register can be obtained:
//          https://codefightsuserpics.s3.amazonaws.com/tasks/livingOnTheRoads/img/example.jpg?_tm=1490636290807


namespace LivingOnTheRoads
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing test array
            bool[][] roadRegister = new bool[6][];
            roadRegister[0] = new bool[] { false, true, true, false, false, false };
            roadRegister[1] = new bool[] { true, false, false, true, false, false };
            roadRegister[2] = new bool[] { true, false, false, false, false, false };
            roadRegister[3] = new bool[] { false, true, false, false, false, false };
            roadRegister[4] = new bool[] { false, false, false, false, false, true };
            roadRegister[5] = new bool[] { false, false, false, false, true, false };

            // Testing and printing the result
            bool[][] res = livingOnTheRoads(roadRegister);
            foreach (bool[] row in res)
            {
                foreach (bool b in row) Console.Write($"{b}\t");
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        // Returns a new roadmap of newly created lists
        static bool[][] livingOnTheRoads(bool[][] roadRegister)
        {
            // Getting cities from existing roads
            List<int[]> cities = new List<int[]>(0);
            for (int i = 0; i < roadRegister.Length; i++)
                for (int j = i + 1; j < roadRegister.Length; j++)
                    if (roadRegister[i][j]) cities.Add(new int[] { i, j });

            int n = cities.Count; // number of new cities

            // The cities are connected if, they have similar indexes, i or j in initial array
            bool[][] res = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                res[i] = new bool[n];
                for (int j = 0; j < n; j++)
                    res[i][j] = (i == j) ? false :
                        (cities[i].Contains(cities[j][0]) | cities[i].Contains(cities[j][1]));
            }
                

            return res;
        }
    }
}
