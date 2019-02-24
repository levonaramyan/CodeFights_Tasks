using System;
using System.Collections.Generic;
using System.Linq;

// You decided to create an automatic image recognizer that will determine the object
// in the image based on its contours. The main recognition system is already implemented,
// and now you need to start the teaching process.
// Today you want to teach your program to recognize star patterns in the image of the night sky,
// which means that you need to implement a function that, given the adjacency matrix
// representing a number of contours in the sky, will find the number of stars in it.
// The graph representing some contour is cosidered to be a star if it is a tree
// of size 2 or if it is a tree of size k > 2 with one internal node(which is a tree root
// at the same time) and k - 1 leaves.
// Here is an example of some stars:
// https://codefightsuserpics.s3.amazonaws.com/tasks/countStars/img/stars.png?_tm=1490625770330
// Given the sky objects' contours as an undirected graph represented by its adjacency matrix adj,
// calculate the number of stars in it.
// Example:
//          For
//          adj = [[false, true, false, false, false],
//                 [true, false, false, false, false],
//                 [false, false, false, true, false],
//                 [false, false, true, false, false],
//                 [false, false, false, false, false]]
//          the output should be
//          countStars(adj) = 2.
//          Here's what the given graph looks like:
//          https://codefightsuserpics.s3.amazonaws.com/tasks/countStars/img/example1.png?_tm=1490625770504

namespace CountStars
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing test array
            bool[][] adj = new bool[5][];
            adj[0] = new bool[] { false, true, false, false, false };
            adj[1] = new bool[] { true, false, false, false, false };
            adj[2] = new bool[] { false, false, false, true, false };
            adj[3] = new bool[] { false, false, true, false, false };
            adj[4] = new bool[] { false, false, false, false, true };

            // Testing and printing the result
            Console.WriteLine(countStars(adj));

            Console.ReadKey();
        }

        // Returns the number of stars in graph
        static int countStars(bool[][] adj)
        {
            int n = adj.Length;

            List<int> nodes = Enumerable.Range(0, n).ToList();
            List<List<int>> groups = new List<List<int>>(0);

            // Find the groups of connected nodes
            while (nodes.Count > 0)
            {
                List<int> group = new List<int>(0);
                group.Add(nodes[0]);
                nodes.RemoveAt(0);

                while(nodes.Count > 0)
                {
                    int start = group.Count;
                    List<int> conn = new List<int>(0);
                    foreach (int i in  group)
                    {
                        conn.AddRange(nodes.Where(j => adj[i][j]));
                        nodes = nodes.Except(conn).ToList();
                    }
                    conn = conn.Distinct().ToList();

                    group.AddRange(conn);

                    if (start == group.Count) break;
                }

                groups.Add(group);
            }

            // Return the number of star-like groups of nodes
            return groups.Where(x => IsStar(adj,x)).Count();
        }

        // Checks if the list of nodes represent a star or not
        static bool IsStar(bool[][] adj, List<int> nodes)
        {
            // one node is not a star
            if (nodes.Count == 1) return false;

            // if there is i-i connection then it is not a star, it has a loop
            if (nodes.Where(i => adj[i][i]).Count() > 0) return false;

            // Two connnected nodes represent a star
            if (nodes.Count == 2) return true;    
            
            // If there are n-1 nodes with 1 connection and only 1 node with more than 1 connection
            return nodes.Where(i => adj[i].Where(x => x).Count() != 1).Count() == 1;
        }
    }
}
