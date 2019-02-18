using System;
using System.Collections.Generic;
using System.Linq;

// You are most likely familiar with the game 2048.
// 2048 is played on a gray 4 × 4 grid with numbered tiles that slide smoothly
// when a player moves them using one of the four arrow keys - Up, Down, Left or Right.
// On every turn, a new tile with a value of either 2 or 4 randomly appears on an empty spot
// of the board.After one of the keys is pressed, the tiles slide as far as possible
// in the chosen direction until they are stopped either by another tile or by the edge
// of the grid.If two tiles with the same number collide while moving, they merge
// into a tile with this number doubled. You can't merge an already merged tile
// in the same turn. If there are more than 2 tiles in the same row (column) that can merge,
// the farthest (closest to an edge) pair will be merged first (see the second example).
// In this problem you are not going to solve the 2048 puzzle, but you are going to find
// the final state of the board from the given one after a defined set
// of n arrow key presses, assuming that no new random tiles will appear on the empty spots.
//      The following example shows the next state of the board after pressing Right.
//      https://codefightsuserpics.s3.amazonaws.com/tasks/game2048/img/ex1.png?_tm=1530798950249
//      This example shows the next state of the board after pressing Down.
//      https://codefightsuserpics.s3.amazonaws.com/tasks/game2048/img/ex2.png?_tm=1530798950639
// For more details you can visit http://gabrielecirulli.github.io/2048/ and play online 😃
// You are given a matrix 4 × 4 which corresponds to the 2048 game grid.
// grid[0][0] corresponds to the upper left tile of the grid. Each element of the grid
// is equal to some power of 2 if there is a tile with that value in the corresponding position,
// and 0 if it corresponds to the empty spot.
// You are also given a sequence of key presses as a string path. Each character
// of the string equals L, R, U, or D corresponding to Left, Right, Up or Down respectively.
// Please note that in some cases after pressing an arrow key nothing will be changed.
// Example:
//          For
//          grid = [[0, 0, 0, 0],
//                 [0, 0, 2, 2],
//                 [0, 0, 2, 4],
//                 [2, 2, 4, 8]]
//          and path = "RR", the output should be
//          game2048(grid, path) = [[0, 0, 0, 0],
//                                  [0, 0, 0, 4],
//                                  [0, 0, 2, 4],
//                                  [0, 0, 8, 8]]

namespace Game2048
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing test values
            string path = "URLD";
            int[][] grid = new int[4][];
            grid[0] = new int[] { 2, 4, 8, 16 };
            grid[1] = new int[] { 256, 128, 64, 32 };
            grid[2] = new int[] { 512, 1024, 2048, 4096 };
            grid[3] = new int[] { 65536, 32768, 16384, 8192 };

            // Printing the grid before the changes
            foreach (int[] row in grid)
            {
                foreach (int val in row) Console.Write($"{val} ");
                Console.WriteLine();
            }

            // Testing
            grid = game2048(grid, path);
            Console.WriteLine(new string('*',100));

            // Printing the grid after the changes
            foreach (int[] row in grid)
            {
                foreach (int val in row) Console.Write($"{val} ");
                Console.WriteLine();
            }

            Console.ReadKey();

        }

        // Moving the grid according to the instruction set path
        static int[][] game2048(int[][] grid, string path)
        {
            foreach (char c in path) MoveGrid(grid, c);

            return grid;
        }

        // Move the whole grid according to direction c, by merging corresponding elements
        static void MoveGrid(int[][] grid, char c)
        {
            switch (c)
            {
                case 'R':
                    for (int i = 0; i < grid.Length; i++) RowToRight(grid,i);
                    break;
                case 'L':
                    for (int i = 0; i < grid.Length; i++) RowToLeft(grid,i);
                    break;
                case 'U':
                    for (int i = 0; i < grid.Length; i++) ColumnUp(grid,i);
                    break;
                case 'D':
                    for (int i = 0; i < grid.Length; i++) ColumnDown(grid,i);
                    break;
            }
        }

        // Moving right the current row of the grid, by merging corresponding elements
        static void RowToRight(int[][] grid, int i)
        {
            List<int> l = grid[i].Where(x => x != 0).ToList();
            for (int j = l.Count - 1; j > 0; j--)
            {
                if (l[j] == l[j-1])
                {
                    l[j - 1] *= 2;
                    l.RemoveAt(j);
                    j--;
                }
            }

            var res = (Enumerable.Range(0, grid[i].Length - l.Count).Select(x => 0)).ToList();
            res.AddRange(l);
            grid[i] = res.ToArray();
        }

        // Moving left the current row of the grid, by merging corresponding elements
        static void RowToLeft(int[][] grid, int i)
        {
            List<int> l = grid[i].Where(x => x != 0).ToList();
            for (int j = 1; j < l.Count; j++)
            {
                if (l[j] == l[j - 1])
                {
                    l[j - 1] *= 2;
                    l.RemoveAt(j);
                }
            }

            l.AddRange((Enumerable.Range(0, grid[i].Length - l.Count).Select(x => 0)));
            grid[i] = l.ToArray();
        }

        // Moving up the current column of the grid, by merging corresponding elements
        static void ColumnUp(int[][] grid, int j)
        {
            List<int> l = grid.Where(x => x[j] != 0).Select(x => x[j]).ToList();
            for (int i = 1; i < l.Count; i++)
            {
                if (l[i] == l[i - 1])
                {
                    l[i - 1] *= 2;
                    l.RemoveAt(i);
                }
            }

            l.AddRange((Enumerable.Range(0, grid.Length - l.Count).Select(x => 0)));

            for (int i = 0; i < grid.Length; i++)
                grid[i][j] = l[i];
        }

        // Moving down the current column of the grid, by merging corresponding elements
        static void ColumnDown(int[][] grid, int j)
        {
            List<int> l = grid.Where(x => x[j] != 0).Select(x => x[j]).ToList();
            for (int i = l.Count - 1; i > 0; i--)
            {
                if (l[i] == l[i - 1])
                {
                    l[i - 1] *= 2;
                    l.RemoveAt(i);
                    i--;
                }
            }

            var res = (Enumerable.Range(0, grid.Length - l.Count).Select(x => 0)).ToList();
            res.AddRange(l);

            for (int i = 0; i < grid.Length; i++)
                grid[i][j] = res[i];
        }
    }
}
