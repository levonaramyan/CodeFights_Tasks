using System;
using System.Collections.Generic;
using System.Linq;

// Once upon a time, in a kingdom far, far away, there lived a king Byteasar VII.
// He reigned during the Dark Times, so very little is known about those times.
// It is known that when he ascended the throne, there were n cities in the kingdom,
// connected by several two-way roads. But before the young king managed to start ruling,
// the enemy came to the gates: the evil emperor Bugoleon invaded the kingdom and started
// to conquer the cities day after day.
// It is not known how long it took to capture each of the cities, but you've recently
// discovered an ancient chronicle saying that each day Bugoleon captured all the cities
// that had at most 1 neighboring free city at the moment. Knowing this fact, the number
// of cities n and all the roads of the kingdom, determine in how many days each
// of the cities was conquered.
// Example:
//          For n = 10 and
//          roads = [[1, 0], [1, 2], [8, 5], [9, 7],
//                   [5, 6], [5, 4], [4, 6], [6, 7]]
//          the output should be
//          citiesConquering(n, roads) = [1, 2, 1, 1, -1, -1, -1, 2, 1, 1].
//          Here's how the cities were conquered:
//          https://codefightsuserpics.s3.amazonaws.com/tasks/citiesConquering/img/example.jpg?_tm=1530791332586


namespace CitiesConquering
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing test values
            int n = 10;
            int[][] roads = new int[8][];
            roads[0] = new int[] { 1, 0 };
            roads[1] = new int[] { 1, 2 };
            roads[2] = new int[] { 8, 5 };
            roads[3] = new int[] { 9, 7 };
            roads[4] = new int[] { 5, 6 };
            roads[5] = new int[] { 5, 4 };
            roads[6] = new int[] { 4, 6 };
            roads[7] = new int[] { 6, 7 };

            // Testing and printing the result
            int[] days = citiesConquering(n, roads);
            foreach (int d in days) Console.WriteLine(d);

            Console.ReadKey();
        }

        // returns array of days to capture each city, or -1 if not possible to capture
        static int[] citiesConquering(int n, int[][] roads)
        {
            int iter = 0;
            int numOfCities = -1;

            // The list of connections of each non-conquered city at the moment
            Dictionary<int, List<int>> cities = new Dictionary<int, List<int>>();

            // The number of days for each city to capture, initializing with -1-s
            int[] days = Enumerable.Range(0,n).Select(x => -1).ToArray();
            for(int i = 0; i < n; i++)
                cities[i] = new List<int>(0);

            // filling the cities
            foreach (int[] r in roads)
            {
                cities[r[0]].Add(r[1]);
                cities[r[1]].Add(r[0]);
            }

            // iteratively determine the captured cities of the day,
            // remove them from the connections of their neighboring cities
            // add the day of their capture in days[] array
            while (cities.Count > 0 && numOfCities != cities.Count)
            {
                numOfCities = cities.Count;
                List<int> cap = cities.Where(x => x.Value.Count <= 1).Select(x => x.Key).ToList();
                foreach (int i in cap)
                {
                    try { cities[cities[i][0]].Remove(i); } catch { }
                    cities.Remove(i);
                    days[i] = iter + 1;
                }

                iter++;
            }

            return days;
        }
    }
}
