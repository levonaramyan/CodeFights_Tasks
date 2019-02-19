using System;
using System.Collections.Generic;
using System.Linq;

// Once upon a time, in a kingdom far, far away, there lived a king Byteasar V.
// His predecessor, king Byteasar IV, lived quite a long life, and when Byteasar V
// finally ascended the throne, he was already 150 years old. The new king had been
// preparing all his life for his moment of glory and, scared that he wouldn't have
// enough time to shine, started his reforms right away.
// The first (and, as it turned out, the last) royal decree, issued within a couple of days
// after the coronation, ordered the following: all the road in the kingdom were to be named.
// Unfortunately the king didn't have enough time to come up with actual names,
// so all the roads were to be names with numbers from 0 to roads.length - 1.
// As a born strategist, Byteasar wanted to make sure that the maps of his kingdom
// were confusing to enemies, which is why the road names were to be chosen so
// that no two roads with the neighboring names (i.e. names i and i + 1 for some i)
// would have a common end at one of the cities.
// The archicartographer came up with the names for the roads, but he was not sure
// if the constraint the king imposed was met.He asked the Greater Power to help him check it.
// As a Greater Power from the future, you are the one who can help with that.
// Given the names for the roads the archicartographer came up with, check that
// no two roads with the neighboring names have a common end.
// Example:
//          For
//          roads = [[0, 1, 0],
//                   [4, 1, 2],
//                   [4, 3, 4],
//                   [2, 3, 1],
//                   [2, 0, 3]]
//          the output should be
//          namingRoads(roads) = true.
//          Here's what the given road system looks like:
//          https://codefightsuserpics.s3.amazonaws.com/tasks/namingRoads/img/example1.jpg?_tm=1490636380904
//
//          For
//          roads = [[2, 3, 1],
//                   [3, 0, 0],
//                   [2, 0, 2]]
//          the output should be
//          namingRoads(roads) = false.
//          Here's what the given road system looks like:
//          https://codefightsuserpics.s3.amazonaws.com/tasks/namingRoads/img/example2.jpg?_tm=1490636381049


namespace NamingRoads
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing test array
            int[][] roads = new int[3][];
            roads[0] = new int[] { 2, 3, 1 };
            roads[1] = new int[] { 3, 0, 0 };
            roads[2] = new int[] { 2, 0, 2 };

            // Testing and printing the result
            Console.WriteLine(namingRoads(roads));

            Console.ReadKey();
        }

        static bool namingRoads(int[][] roads)
        {
            int maxIndex = roads.Select(x => x[2]).Max();
            List<int>[] neighb= new List<int>[maxIndex+1];
            for (int i = 0; i <= maxIndex; i++)
                neighb[i] = new List<int>(0);

            // adding the city numbers for given road and its previous one
            foreach (int[] r in roads)
            {
                neighb[r[2]].AddRange(new int[] { r[0], r[1] });
                try { neighb[r[2]-1].AddRange(new int[] { r[0], r[1] }); }
                catch { }
            }

            // returns true, if in all arrays in neighb, no repeating numbers are available
            return neighb.Where(x => x.Count == x.Distinct().Count()).Count() == maxIndex + 1;
        }
    }
}
