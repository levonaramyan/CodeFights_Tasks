using System;
using System.Collections.Generic;
using System.Linq;

// Once upon a time, in a kingdom far, far away, there lived a king Byteasar III.
// As a smart and educated ruler, he did everything in his (unlimited) power to make
// every single system of his kingdom efficient. The king went down in history
// as a great road builder: during his reign a great number of roads were built,
// and the road system he created was the most efficient for those dark times.
// When you started to learn about Byteasar's III deeds in your history classes,
// the creeping doubt crawled into the back of your mind: what if the famous king
// wasn't so great after all? According to the most recent studies, there were n cities
// in the Byteasar's kingdom, which were connected by the two-ways roads.
// You managed to get information about this roads from the university library,
// so now you can write a function that will determine whether the road system
// in Byteasar's kingdom was efficient or not.
// A road system is considered efficient if it is possible to travel from any city
// to any other city by traversing at most 2 roads.
// Example:
//          For n = 6 and
//          roads = [[3, 0], [0, 4], [5, 0], [2, 1], [1, 4], [2, 3], [5, 2]]
//          the output should be
//          efficientRoadNetwork(n, roads) = true.
//          Here's how the road system can be represented:
//          https://codefightsuserpics.s3.amazonaws.com/tasks/efficientRoadNetwork/img/example1.jpg?_tm=1530798811119
//
//          For n = 6 and
//          roads = [[0, 4], [5, 0], [2, 1], [1, 4], [2, 3], [5, 2]]
//          the output should be
//          efficientRoadNetwork(n, roads) = false.
//          Here's how the road system can be represented:
//          https://codefightsuserpics.s3.amazonaws.com/tasks/efficientRoadNetwork/img/example2.jpg?_tm=1530798811365
//          As you can see, it's only possible to travel from city 3 to city 4
//          by traversing at least 3 roads.

namespace efficientRoadNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing test values
            int n = 6;
            int[][] roads = new int[7][];
            roads[0] = new int[] { 3, 0 };
            roads[1] = new int[] { 0, 4 };
            roads[2] = new int[] { 5, 0};
            roads[3] = new int[] { 2, 1 };
            roads[4] = new int[] { 1, 4 };
            roads[5] = new int[] { 2, 3 };
            roads[6] = new int[] { 5, 2 };

            // Testing and printing the result
            Console.WriteLine(efficientRoadNetwork(n,roads));
            Console.ReadKey();
        }

        // Returns true, if each city could be reached from another city using at most two roads
        static bool efficientRoadNetwork(int n, int[][] roads)
        {
            List<int>[] firstReach = new List<int>[n];
            List<int>[] secondrich = new List<int>[n];

            // For each city, determining a list of cities which could be reached directly
            for (int i = 0; i < n; i++)
            {
                firstReach[i] = new List<int>(0);
                firstReach[i].AddRange
                    (
                        roads.Where(x => x[0] == i || x[1] == i).
                        Select(x => x[0] == i ? x[1] : x[0])
                    );
            }

            // adding the obtained list into a list of cities, which could be reach
            // using at most two roads
            secondrich = firstReach.Select(x => x.Select(y => y).ToList()).ToArray();

            // getting all of the cities that could be reached in the second iteration
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < firstReach[i].Count; j++)
                {
                    var l = firstReach[i][j];
                    secondrich[i].AddRange(firstReach[l]);
                }

                // filtering the lists, by excluding the starting city itself
                // and getting only distinct numbers
                secondrich[i] = secondrich[i].Distinct().Where(x => x != i).ToList();
            }

            // return true, if the number of possible cities to visit in two iterations
            //              is (n-1)
            return secondrich.Select(x => x.Count).Sum() == n * (n - 1);
        }
    }
}
