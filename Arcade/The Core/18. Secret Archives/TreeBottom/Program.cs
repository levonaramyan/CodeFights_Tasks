using System;
using System.Collections.Generic;
using System.Linq;

// You are given a recursive notation of a binary tree: each node of a tree is represented as a set
// of three elements:
//      value of the node;
//      left subtree;
//      right subtree.
// So, a tree can be written as (value left_subtree right_subtree). It is guaranteed
// that 1 ≤ value ≤ 109. If a node doesn't exist then it is represented as an empty set:().
// For example, here is a representation of a tree in the given picture:
// (2 (7 (2 () ()) (6 (5 () ()) (11 () ()))) (5 () (9 (4 () ()) ())))
// https://codefightsuserpics.s3.amazonaws.com/tasks/treeBottom/img/tree.png?_tm=1530820904857
// Your task is to obtain a list of nodes, that are the most distant from the tree root,
// in the order from left to right.
// In the notation of a node its value and subtrees are separated by exactly one space character.
// Example:
//          For
//          tree = "(2 (7 (2 () ()) (6 (5 () ()) (11 () ()))) (5 () (9 (4 () ()) ())))"
//          the output should be
//          treeBottom(tree) = [5, 11, 4].

namespace TreeBottom
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            string tree = "(65 (88 (45 (4 () ()) ()) ()) (1000000000 () ()))";
            int[] res = treeBottom(tree);
            foreach (int r in res) Console.WriteLine(r);
            Console.ReadKey();
        }

        // return an array of the most distant nodes
        static int[] treeBottom(string tree)
        {
            List<int[]> nodes = new List<int[]>(0); // list of [distance,node] pairs
            int dist = 0;
            int maxdist = 0;
            for (int i = 0; i < tree.Length; i++)
            {
                // recalculating the current distance from the root
                dist += (tree[i] == '(') ? 1 : (tree[i] == ')' ? -1 : 0);

                // if the symbol is digit then find the whole number
                string cur = "";
                while (char.IsDigit(tree[i]))
                {
                    cur += tree[i];
                    i++;
                }

                // if it was a number, then add [dist, node] pair in the list nodes
                // and compare dist with maxdist and get the maximum
                if (cur.Length > 0)
                {
                    nodes.Add(new int[] { dist, int.Parse(cur) });
                    maxdist = dist > maxdist ? dist : maxdist;
                }
            }

            // return those nodes, for which dist == maxdist
            return nodes.Where(x => x[0] == maxdist).Select(x => x[1]).ToArray();
        }
    }
}
