using System;
using System.Collections.Generic;
using System.Linq;

// Let's play Tetris! But first we need to define the rules, especially since they probably
// differ from the way you've played Tetris before.
// There is an empty field with 20 rows and 10 columns, which is initially empty.
// Random pieces appear on the field, each composed of four square blocks.
// You can't change the piece's shape, but you can rotate it 90 degree clockwise
// (possibly several times) and choose which columns it will appear within.
// Once you've rotated the piece and have set its starting position, it appears
// at the topmost row where you placed it and falls down until it can't fall any further.
// The objective of the game is to create horizontal lines composed of 10 blocks.
// When such a line is created, it disappears, and all lines above the deleted one move down.
// The player receives 1 point for each deleted row.
// Your task is to implement an algorithm that places each new piece optimally.
// The piece is considered to be placed optimally if:
//      The total number of blocks in the rows this piece will occupyafter fallingdown is maximized;
//      Among all positions with that value maximized, this position requires the least number of rotations;
//      Among all positions that require the minimum number of rotations, this one is
//          the leftmost one (i.e.the leftmost block's position is as far to the left as possible).
// The piece can't leave the field. It is guaranteed that it is always possible to place
// the Tetris piece in the field.
// Implement this algorithm and calculate the number of points that you
// will get for the given set of pieces.
// Example:
//          For
//          pieces = [[[".", "#", "."],
//                     ["#", "#", "#"]],
//                    [["#", ".", "."], 
//                     ["#", "#", "#"]],
//                    [["#", "#", "."], 
//                     [".", "#", "#"]],
//                    [["#", "#", "#", "#"]],
//                    [["#", "#", "#", "#"]],
//                    [["#", "#"], 
//                     ["#", "#"]]]
//          the output should be
//          tetrisGame(pieces) = 1.
//          For this explanation, we are representing each block by the index of the piece
//          it belongs to. After the first 5 blocks fall, the field looks like this:
//          ...
//          . . . . . . . . . .
//          . . . . . . . . . .
//          . . . . . . . . . .
//          . . . . . . . . . .
//          . . . . . . . . 3 4
//          . . . . . . . . 3 4
//          . 0 . 1 . 2 2 . 3 4
//          0 0 0 1 1 1 2 2 3 4
//          Note that the 0th, 1st, and 2nd pieces all fell down without rotating,
//          while the 3rd and the 4th pieces were rotated one time each.
//          Since there is now a row composed of 10 blocks, it is deleted, and you get 1 point.
//          When the last piece falls, the final field looks like this:
//          ...
//          . . . . . . . . . .
//          . . . . . . . . . .
//          . . . . . . . . . .
//          . . . . . . . . . .
//          . . . . . . . . . .
//          5 5. . . . . . 3 4
//          5 5. . . . . . 3 4
//          . 0. 1. 2 2. 3 4

namespace TetrisGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing test array
            char[][][] pieces = new char[6][][];

            pieces[0] = new char[2][];
            pieces[0][0] = new char[] { '.', '#', '.' };
            pieces[0][1] = new char[] { '#', '#', '#' };

            pieces[1] = new char[2][];
            pieces[1][0] = new char[] { '.', '.', '#' };
            pieces[1][1] = new char[] { '#', '#', '#' };

            pieces[2] = new char[2][];
            pieces[2][0] = new char[] { '#', '#', '.' };
            pieces[2][1] = new char[] { '.', '#', '#' };

            pieces[3] = new char[2][];
            pieces[3][0] = new char[] { '.', '#', '.' };
            pieces[3][1] = new char[] { '#', '#', '#' };

            pieces[4] = new char[2][];
            pieces[4][0] = new char[] { '.', '.', '#' };
            pieces[4][1] = new char[] { '#', '#', '#' };

            pieces[5] = new char[2][];
            pieces[5][0] = new char[] { '#', '#', '.' };
            pieces[5][1] = new char[] { '.', '#', '#' };

            // Testing and printing out the result
            Console.WriteLine(tetrisGame(pieces));
            Console.ReadKey();
        }

        static int tetrisGame(char[][][] pieces)
        {
            int res = 0;
            char[][] board = Enumerable.Range(0, 20).Select(i => new string('.', 10).ToCharArray()).ToArray();

            // For each piece, find the best choice, fix it in the board
            // and clear the filled row, if there is such a case
            for (int j = 0; j < pieces.Length; j++)
            {
                char[][] p = pieces[j];
                int[] choice = FindTheBestChoice(board, p);
                for (int i = 1; i <= choice[1]; i++) p = RotatePiece(p);
                FixThePiece(ref board, p, choice[3], choice[2]);
                var filled = GetFullLines(board);
                foreach (int i in filled)
                {
                    ClearTheFilledLine(ref board, i);
                    res++;
                }
                // For tracing the step, jusk clear the comment sign below
                //PrintPiece(board);
                //Console.WriteLine();
            }

            return res;
        }

        // Rotate 90 degrees clockwise the piece
        static char[][] RotatePiece(char[][] p)
        {
            return Enumerable.Range(0, p[0].Length).
                Select(i => Enumerable.Range(0, p.Length).
                Select(j => p[j][i]).Reverse().ToArray()).ToArray();
        }

        // Print the shape of the piece in the console (fore helping/debugging purposes)
        static void PrintPiece(char[][] p)
        {
            foreach (char[] row in p)
            {
                foreach (char c in row) Console.Write($"{c} ");
                Console.WriteLine();
            }
        }

        // Throw a piece into the board in the column with index col
        // returns the index of the row, where it hits to another block or to the ground
        static int ThrowPiece(char[][] board, char[][] piece, int col)
        {
            int pi = piece.Length;
            int pj = piece[0].Length;
            if (pj + col > board[0].Length) return -1;
            int row = 0;
            bool isFixed = true;

            // While it does not reach to the fixed state, move down
            while (isFixed)
            {
                isFixed = true;
                for (int i = 0; i < pi; i++)
                {
                    for (int j = 0; j < pj; j++)
                    {
                        if (board[row + i][col + j] == '#' && piece[i][j] == '#')
                        {
                            isFixed = false;
                            break;
                        }
                    }
                }
                if (isFixed) row++;
                if (row == board.Length - pi + 1) break;
            }

            row--;

            return row;
        }

        // Returns a list of rows, which are fully filled with blocks
        static List<int> GetFullLines(char[][] board)
        {
            List<int> res = new List<int>(0);

            for (int i = 0; i < board.Length; i++)
                if (!board[i].Contains('.')) res.Add(i);

            return res;
        }

        // Clears the i-th line of the board 
        static void ClearTheFilledLine(ref char[][] board, int i)
        {
            var res = board.ToList();
            res.RemoveAt(i);
            res.Insert(0, new string('.', 10).ToArray());
            board = res.ToArray();
        }

        // Fixes the current piece int given positions in the board
        // Updates the board
        static void FixThePiece(ref char[][] board, char[][] piece, int row, int col)
        {
            int pi = piece.Length;
            int pj = piece[0].Length;
            for (int i = 0; i < pi; i++)
                for (int j = 0; j < pj; j++)
                    board[row + i][col + j] = piece[i][j] == '#' ?
                        '#' : board[row + i][col + j];
        }

        // Returns the parameters of the best choice for the given piece
        // return int[] is, 0-th blocks(number of blocks in the rows of piece),
        // 1-th rotation step (0 to 3)
        // 2-nd and 3-rd are positions (column and row) 
        static int[] FindTheBestChoice(char[][] board, char[][] piece)
        {
            List<int[]> choices = new List<int[]>(0);
            char[][] p = piece.Select(x => x.Select(y => y).ToArray()).ToArray();

            // for each rotation, and column find the blocks and fixing row
            for (int r = 0; r < 4; r++)
            {
                if (r > 0) p = RotatePiece(p);
                for (int col = 0; col <= board[0].Length - p[0].Length; col++)
                {
                    int row = ThrowPiece(board, p, col);
                    int blocks = Enumerable.Range(row, p.Length).
                        Select(i => board[i].Where(y => y == '#').Count()).Sum();
                    choices.Add(new int[] { blocks, r, col, row });
                }
            }

            // Return the best choice according to the terms of problem
            return choices.OrderByDescending(x => x[0]).ThenBy(x => x[1]).ThenBy(x => x[2]).FirstOrDefault();
        }
    }
}
