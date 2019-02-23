using System;
using System.Collections.Generic;
using System.Linq;

// You decided to create an automatic image recognizer that will determine the object
// in the image based on its contours. The main recognition system is already implemented,
// and now you need to start the teaching process.
// Today you want to teach your program to recognize butterfly patterns, which means
// that you need to implement a function that, given the adjacency matrix representing
// the contour, will determine whether it's a butterfly or not.
// The butterfly contour looks like this:
// https://codefightsuserpics.s3.amazonaws.com/tasks/isButterfly/img/butterfly.png?_tm=1495120253756
// Given the object's contour as an undirected graph represented by adjacency matrix adj
// determine whether it's a butterfly or not.
// Example:
//          For
//          adj = [[false, true, true, false, false],
//                 [true, false, true, false, false],
//                 [true, true, false, true, true],
//                 [false, false, true, false, true],
//                 [false, false, true, true, false]]
//          the output should be
//          isButterfly(adj) = true.
//          Here's what the given graph looks like:
//          https://codefightsuserpics.s3.amazonaws.com/tasks/isButterfly/img/example1.png?_tm=1495120253905

namespace IsButterfly
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing test array
            bool[][] adj = new bool[5][];
            adj[0] = new bool[] { false, true, true, false, false };
            adj[1] = new bool[] { true, false, true, false, false };
            adj[2] = new bool[] { true, true, true, true, false };
            adj[3] = new bool[] { false, false, true, false, true };
            adj[4] = new bool[] { false, false, false, true, true };

            // Testing and printing the result
            Console.WriteLine(isButterfly(adj));
            Console.ReadKey();
        }

        static bool isButterfly(bool[][] adj)
        {
            // Checking whether the matrix is correct or not, i.e. [i][i] element must be false
            for (int i = 0; i < adj.Length; i++)
                if (adj[i][i]) return false;

            // counting the number of neighbors
            List<int> neighbCount = adj.Select(x => x.Where(y => y).Count()).ToList();

            // If it is butterfly than one of the nodes should have 4 neighbors
            // and other 4 nodes should have 2 neighbors each
            neighbCount.Remove(4);
            for (int i = 0; i < 4; i++) neighbCount.Remove(2);

            return (neighbCount.Count > 0) ? false: true;
        }
    }
}
