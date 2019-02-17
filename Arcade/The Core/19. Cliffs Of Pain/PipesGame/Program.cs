using System;
using System.Collections.Generic;
using System.Linq;

// Carlos always loved playing video games, especially the well-known computer game "Pipes".
// Today he finally decided to write his own version of the legendary game from scratch.
// In this game the player has to place the pipes on a rectangular field to make water pour
// from each source to a respective sink.He has already come up with the entire program,
// but one question still bugs him: how can he best check that the arrangement of pipes is correct?
// It's your job to help him figure out exactly that.
// Carlos has 7 types of pipes in his game, with numbers corresponding to each type:
//      1 - vertical pipe
//      2 - horizontal pipe
//      3-6 - corner pipes
//      7 - two pipes crossed in the same cell (note that these pipes are not connected)
// Here they are, pipes 1 to 7, respectively:
// https://codefightsuserpics.s3.amazonaws.com/tasks/pipesGame/img/pipe_types.png?_tm=1530802177363
// Water pours from each source in each direction that has a pipe connected to it
// (thus it can even pour in all four directions). The puzzle is solved correctly only
// if all water poured from each source eventually reaches a corresponding sink.
// Help Carlos check whether the arrangement of pipes is correct. If it is correct,
// return the number of cells with pipes that will be full of water at the end of the game.
// If not, return -X, where X is the number of cells with water before the first leakage point
// is reached, or if the first drop of water reaches an incorrect destination (whichever comes first).
// Assume that water moves from one cell to another at the same speed.
// Example:
//          For
//          state = ["a224C22300000",
//                   "0001643722B00",
//                   "0b27275100000",
//                   "00c7256500000",
//                   "0006A45000000"]
//          the output should be pipesGame(state) = 19.
//          Here is how the game will end:
//          https://codefightsuserpics.s3.amazonaws.com/tasks/pipesGame/img/example.png?_tm=1530802177628



namespace PipesGame
{
    class Program
    {
        static void Main(string[] args)
        {

            // Initializing test array of strings
            string[] state = new string[]
            {
                "3277222400000000",
                "1000032A40000000",
                "1000010110000000",
                "1Q2227277q000000",
                "1000010110000000",
                "1000062a50000000",
                "6222222500000000"
            };

            // Testing and printing the result
            Console.WriteLine(pipesGame(state));
            Console.ReadKey();
        }

        // Returns the number of filled pipes
        // X if no leaks, -X where x is the number of filled pipes until the first leak, or wrong connection
        static int pipesGame(string[] state)
        {
            int num = 0;
            int interupt = 20000;
            List<string[]> wired = new List<string[]>(0);
            List<int[]> sources = GetAllSources(state);
            foreach (int[] s in sources)
            {
                var con = GetConnections(state, s);
                foreach (int[] c in con)
                {
                    List<int[]> seq = new List<int[]>(0);
                    seq.Add(s);
                    seq.Add(c);
                    int[] prev = new int[] { s[0], s[1] };
                    int[] cur = new int[] { c[0], c[1] };

                    while (true)
                    {
                        int[] next = GetNext(state, state[cur[0]][cur[1]], cur, prev);
                        if (next is null || (char.IsUpper(state[next[0]][next[1]]) &&
                            state[next[0]][next[1]] != char.ToUpper(state[seq[0][0]][seq[0][1]])))
                        {
                            interupt = interupt > seq.Count - 1 ? seq.Count - 1 : interupt;
                            break;
                        }
                        if (char.IsUpper(state[next[0]][next[1]])) break;
                        prev = cur;
                        cur = next;
                        seq.Add(next);
                    }

                    wired.Add(seq.Where(x => char.IsDigit(state[x[0]][x[1]])).Select(x => $"{x[0]},{x[1]}").ToArray());
                }
            }

            List<string> filled = new List<string>(0);
            if (interupt == 20000)
                foreach (var s in wired)
                    filled.AddRange(s.Select(x => x));
            else
                foreach (var s in wired)
                    for (int i = 0; i < s.Length && i < interupt; i++)
                        filled.Add(s[i]);

            return filled.Distinct().ToList().Count * (interupt == 20000 ? 1 : -1);
        }

        // Get the coordinates of the next coming pipe candidate
        static int[] GetNext(string[] state, char pipe, int[] coord, int[] prev)
        {
            int[] neighb = new int[2];
            int i = coord[0];
            int j = coord[1];
            int pi = prev[0];
            int pj = prev[1];

            switch (pipe)
            {
                case '1':
                    neighb = (pi == i - 1 && pj == j) ?
                        new int[] { i + 1, j } :
                        new int[] { i - 1, j };
                    break;
                case '2':
                    neighb = (pi == i && pj == j - 1) ?
                        new int[] { i, j + 1 } :
                        new int[] { i, j - 1 };
                    break;
                case '3':
                    neighb = (pi == i + 1 && pj == j) ?
                        new int[] { i, j + 1 } :
                        new int[] { i + 1, j };
                    break;
                case '4':
                    neighb = (pi == i + 1 && pj == j) ?
                        new int[] { i, j - 1 } :
                        new int[] { i + 1, j };
                    break;
                case '5':
                    neighb = (pi == i && pj == j - 1) ?
                        new int[] { i - 1, j } :
                        new int[] { i, j - 1 };
                    break;
                case '6':
                    neighb = (pi == i - 1 && pj == j) ?
                        new int[] { i, j + 1 } :
                        new int[] { i - 1, j };
                    break;
                case '7':
                    neighb = (pi == i) ?
                        GetNext(state, '2', coord, prev) :
                        GetNext(state, '1', coord, prev);
                    break;
            }

            return (!IsCoordNormal(state, neighb) ||
                !AreMerging(state[coord[0]][coord[1]], state[neighb[0]][neighb[1]], coord, neighb) ||
                !AreMerging(state[neighb[0]][neighb[1]], state[coord[0]][coord[1]], neighb, coord)) ? null : neighb;
        }

        // Get the list of coordinates of all of the connections from the given source
        static List<int[]> GetConnections(string[] state, int[] coord)
        {
            int i = coord[0];
            int j = coord[1];
            List<int[]> res = new List<int[]>(0);
            res.Add(new int[] { i, j - 1 });
            res.Add(new int[] { i, j + 1 });
            res.Add(new int[] { i - 1, j });
            res.Add(new int[] { i + 1, j });

            res = res.Where(x => IsCoordNormal(state, x)).Select(x => x).ToList();
            res = res.Where(x => (x[0] == i + 1 && "1567".Contains(state[x[0]][x[1]])) ||
                                 (x[0] == i - 1 && "1347".Contains(state[x[0]][x[1]])) ||
                                 (x[1] == j - 1 && "2367".Contains(state[x[0]][x[1]])) ||
                                 (x[1] == j + 1 && "2457".Contains(state[x[0]][x[1]]))
                                 ).ToList();

            return res;
        }

        // Getting a list of coordinates of all of the sources in state
        static List<int[]> GetAllSources(string[] state)
        {
            List<int[]> sr = new List<int[]>(0);
            for (int i = 0; i < state.Length; i++)
                for (int j = 0; j < state[0].Length; j++)
                    if (char.IsLower(state[i][j])) sr.Add(new int[] { i, j });

            return sr;
        }

        // Checking if the coord[] falls in range of state
        static bool IsCoordNormal(string[] state, int[] coord)
        {
            if (coord is null) return false;
            bool yOK = coord[0] >= 0 && coord[0] < state.Length;
            bool xOK = coord[1] >= 0 && coord[1] < state[0].Length;
            return xOK && yOK;
        }

        // Checks if two neighboring pipes could be successfully connected
        static bool AreMerging(char p1, char p2, int[] c1, int[] c2)
        {
            switch (p1)
            {
                case '1':
                    return c1[1] == c2[1] && Math.Abs(c1[0] - c2[0]) == 1;
                case '2':
                    return c1[0] == c2[0] && Math.Abs(c1[1] - c2[1]) == 1;
                case '3':
                    return (c1[0] == c2[0] && c2[1] - c1[1] == 1) || (c1[1] == c2[1] && c2[0] - c1[0] == 1);
                case '4':
                    return (c1[0] == c2[0] && c2[1] - c1[1] == -1) || (c1[1] == c2[1] && c2[0] - c1[0] == 1);
                case '5':
                    return (c1[0] == c2[0] && c2[1] - c1[1] == -1) || (c1[1] == c2[1] && c2[0] - c1[0] == -1);
                case '6':
                    return (c1[0] == c2[0] && c2[1] - c1[1] == 1) || (c1[1] == c2[1] && c2[0] - c1[0] == -1);
                case '7':
                    return (c1[1] == c2[1] && Math.Abs(c1[0] - c2[0]) == 1) || (c1[0] == c2[0] && Math.Abs(c1[1] - c2[1]) == 1);
                case '0':
                    return false;
                default:
                    return (char.IsLower(p1) || char.IsLower(p2)) ? false : true;
            }
        }
    }
}