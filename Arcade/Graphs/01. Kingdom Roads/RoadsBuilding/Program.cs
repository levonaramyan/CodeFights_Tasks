using System;
using System.Collections.Generic;
using System.Linq;

// Once upon a time, in a kingdom far, far away, there lived a king Byteasar II. There was
// nothing special neither about him, nor about his kingdom. As a mediocre ruler,
// he did nothing about his kingdom and preferred hunting and feasting over doing anything
// about his kingdom prosperity.
// Luckily, his adviser, wise magician Bitlin, was working for the kingdom welfare daily and nightly.
// However, since there was no one to advise him, he completely forgot about one important thing:
// the roads. Over the years most of the two-way roads built by Byteasar II predecessors
// were forgotten and no longer traversable.Only a few roads can still be used.
// Bitlin wanted each pair of cities to be connected, but couldn't find a way to figure out
// which roads are missing. Desperate, he turned to his magic crystal, seeking help.
// The crystal showed him a programmer from the distant future: you! Now you're the only one
// who can save the kingdom.Given the existing roads and the number of cities in the kingdom,
// you should use the most modern technologies and find out what roads should be built again
// to make each pair of cities connected.Since the magic crystal is quite old and meticulous,
// it will only transfer the information that is sorted properly.
// The roads to be built should be returned in an array sorted lexicographically,
// with each road stored as [cityi, cityj], where cityi < cityj.
// Example:
//          For cities = 4 and roads = [[0, 1], [1, 2], [2, 0]],
//          the output should be
//          roadsBuilding(cities, roads) = [[0, 3], [1, 3], [2, 3]].
//          See the image below: the existing roads are colored black,
//          and the ones to be built are colored red.
//          https://codefightsuserpics.s3.amazonaws.com/tasks/roadsBuilding/img/example.jpg?_tm=1491302275155


namespace RoadsBuilding
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing test values
            int cities = 4;
            int[][] roads = new int[3][];
            roads[0] = new int[] { 0, 1 };
            roads[1] = new int[] { 1, 2 };
            roads[2] = new int[] { 2, 0 };

            // Testing and printing the result
            int[][] newRoads = roadsBuilding(cities, roads);
            foreach (int[] r in newRoads) Console.WriteLine($"{r[0]}, {r[1]}");

            Console.ReadKey();
        }

        static int[][] roadsBuilding(int cities, int[][] roads)
        {
            roads = roads.Select(x => (x[0] < x[1]) ? x : new int[] { x[1], x[0] }).ToArray();
            List<int[]> a = new List<int[]>(0);
            for (int i = 1; i < cities; i++)
                for (int j = 0; j < i; j++)
                    a.Add(new int[] { j, i });

            int[][] res = (a.Where(x => roads.Where(y => y[0] == x[0] && y[1] == x[1]).Count() == 0)).
                OrderBy(x => x[0]).ThenBy(x => x[1]).ToArray();

            return res;
        }
    }
}
