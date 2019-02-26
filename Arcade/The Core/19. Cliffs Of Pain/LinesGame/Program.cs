using System;
using System.Collections.Generic;
using System.Linq;

// Let's remember the '90s and play an old-school Lines (wikipedia reference) game
// with the following rules.
// The game starts with a 9 × 9 field with several colored balls placed on its cells
// (there are 7 possible colors but not all colors have to be present initially).
// The player can move one ball per turn, and they may only move a ball if
// there is a clear path between the current position of the chosen ball
// and the desired destination.Clear paths are formed by neighboring empty cells.
// Two cells are neighboring if they have a common side.The goal is to remove balls
// by forming lines (horizontal, vertical or diagonal) of at least five balls of the same color.
// If the player manages to form one or more such lines, the move is called successful,
// and the balls in those lines disappear.Otherwise, the move is called unsuccessful,
// and three more balls appear on the field.
// You are given the game logs, and your task is to calculate the player's final score.
// Here's the information you have:
//    The field state at the initial moment;
//    The clicks the user has made.Note that a click does not necessarily result in a move:
//        If the user clicks a ball and then another, the first click is ignored;
//        If two consecutive clicks result in an incorrect move, they are ignored;
//    After each unsuccessful move three more balls appear:
//        newBalls contains the balls' colors;
//        newBallsCoordinates contains their coordinates;
//        Note that after the balls appear, new lines may form;
//    Whenever new lines appear, they are removed and the player receives A + B - 1 points, where:
//        A is the number of lines of at least five balls;
//        B is the total number of balls in those lines;
//    Possible ball colors are red, blue, orange, violet, green, yellow and cyan,
//    which are represented in logs by "R", "B", "O", "V", "G", "Y" and "C" respectively.
// Example:
//          For
//          field = [['.', 'G', '.', '.', '.', '.', '.', '.', '.'],
//                   ['.', '.', '.', '.', '.', '.', '.', 'V', '.'],
//                   ['.', 'O', '.', '.', 'O', '.', '.', '.', '.'],
//                   ['.', '.', '.', '.', 'O', '.', '.', '.', '.'],
//                   ['.', '.', '.', '.', '.', '.', '.', '.', 'O'],
//                   ['.', '.', '.', '.', 'O', '.', '.', '.', '.'],
//                   ['.', '.', '.', '.', '.', '.', '.', '.', '.'],
//                   ['R', '.', '.', '.', '.', '.', '.', 'B', 'R'],
//                   ['.', '.', 'C', '.', '.', '.', '.', 'Y', 'O']]
//          clicks = [[4, 8], [2, 1], [4, 4], [6, 4], [4, 8], [1, 2], [1, 4], [4, 8], [6, 4]],
//          newBalls = ['R', 'V', 'C', 'G', 'Y', 'O'], and
//          newBallsCoordinates = [[1, 2], [8, 5], [8, 6], [1, 1], [1, 8], [7, 4]], the output should be
//          linesGame(field, clicks, newBalls, newBallsCoordinates) = 6.
//
//          The only correct moves were:
//          Orange ball moved from[2, 1] to[4, 4];
//          Red ball moved from[1, 2] to[1, 4];
//          Orange ball moved from[4, 8] to[6, 4]
//          After the third move a vertical line with 6 orange balls appears,
//          so it is removed and the player receives 1 + 6 - 1 = 6 points.
//          https://codefightsuserpics.s3.amazonaws.com/tasks/linesGame/img/example1.jpg?_tm=1530801867305
//
//          For
//          field = [['.', '.', '.', '.', '.', '.', '.', '.', '.'],
//                  ['.', '.', '.', '.', '.', '.', '.', '.', '.'],
//                  ['.', '.', 'O', '.', 'O', '.', 'O', '.', '.'],
//                  ['.', '.', '.', 'O', 'O', 'O', '.', '.', '.'],
//                  ['.', '.', '.', '.', '.', '.', '.', '.', 'O'],
//                  ['.', '.', '.', 'O', 'O', 'O', '.', '.', '.'],
//                  ['.', '.', 'O', '.', 'O', '.', 'O', '.', '.'],
//                  ['.', '.', '.', '.', '.', '.', '.', '.', '.'],
//                  ['.', '.', '.', '.', '.', '.', '.', '.', '.']]
//          clicks = [[4, 8], [4, 4]],
//          newBalls = [], and
//          newBallsCoordinates = [], the output should be
//          linesGame(field, clicks, newBalls, newBallsCoordinates) = 17.
//          After the move there will be three lines with exactly 5 balls of the same color,
//          so the answer is 3 + (5 + 5 + 5) - 1 = 17.
//          https://codefightsuserpics.s3.amazonaws.com/tasks/linesGame/img/example2.jpg?_tm=1530801867695



namespace LinesGame
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] field = new char[9][];
            field[0] = new char[] { 'V', '.', '.', '.', '.', '.', '.', '.', 'V' };
            field[1] = new char[] { 'V', '.', '.', '.', '.', '.', '.', '.', 'V' };
            field[2] = new char[] { 'V', '.', 'O', '.', 'O', '.', 'O', '.', '.' };
            field[3] = new char[] { 'V', '.', '.', 'O', 'O', 'O', '.', '.', '.' };
            field[4] = new char[] { '.', 'V', 'V', 'V', '.', '.', '.', '.', 'O' };
            field[5] = new char[] { 'V', '.', '.', 'O', 'O', 'O', '.', '.', '.' };
            field[6] = new char[] { 'V', '.', 'O', '.', 'O', '.', 'O', '.', '.' };
            field[7] = new char[] { 'V', '.', '.', '.', '.', '.', '.', '.', '.' };
            field[8] = new char[] { 'V', '.', '.', '.', '.', '.', '.', '.', '.' };

            int[][] clicks = new int[4][];
            clicks[0] = new int[] { 4, 8 };
            clicks[1] = new int[] { 4, 4 };
            clicks[2] = new int[] { 1, 8 };
            clicks[3] = new int[] { 4, 0 };

            char[] newBalls = new char[0] { };

            int[][] newBallsCoordinates = new int[0][];

            Console.WriteLine(linesGame(field, clicks, newBalls, newBallsCoordinates));


            Console.ReadKey();
        }

        static int linesGame(char[][] field, int[][] clicks, char[] newBalls, int[][] newBallsCoordinates)
        {
            int score = 0;

            for (int i = 1; i < clicks.Length; i++)
            {
                if (field[clicks[i - 1][0]][clicks[i - 1][1]] != '.' && field[clicks[i][0]][clicks[i][1]] == '.')
                {
                    bool swapIsValid = IsPathClear(field, clicks[i - 1], clicks[i]);
                    if (swapIsValid)
                    {
                        Swap(field, clicks[i], clicks[i - 1]);
                        i++;
                    }
                    else continue;
                }
                else continue;

                List<List<int[]>> lines = FindTheLines(field);
                if (lines.Count > 0)
                {
                    score += Score(field, lines);
                }
                else
                {
                    for (int j = 0; j < 3; j++)
                    {
                        int i1 = newBallsCoordinates[j][0];
                        int j1 = newBallsCoordinates[j][1];
                        field[i1][j1] = newBalls[j];
                    }
                    var nb = newBalls.ToList();
                    nb.RemoveRange(0, 3);
                    newBalls = nb.ToArray();
                    var nbc = newBallsCoordinates.ToList();
                    nbc.RemoveRange(0, 3);
                    newBallsCoordinates = nbc.ToArray();
                }

                lines = FindTheLines(field);
                if (lines.Count > 0)
                {
                    score += Score(field, lines);
                }
            }

            return score;
        }

        static void Swap(char[][] field, int[] a, int[] b)
        {
            char c = field[a[0]][a[1]];
            char d = field[b[0]][b[1]];
            field[a[0]][a[1]] = d;
            field[b[0]][b[1]] = c;
        }

        static bool IsPathClear(char[][] field, int[] start, int[] end)
        {
            List<int[]> considered = new List<int[]> { start };
            List<int[]> connections = new List<int[]> { start };

            while (true)
            {
                List<int[]> newConnections = new List<int[]>(0);
                foreach (int[] c in connections)
                {
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            if (i * j == 0)
                            {
                                int[] pos = new int[] { c[0] + i, c[1] + j };
                                bool posIsNotNew = IsConsidered(considered, pos);

                                if (IsInField(field, pos) && !posIsNotNew)
                                {
                                    considered.Add(pos);
                                    if (field[pos[0]][pos[1]] == '.') newConnections.Add(pos);
                                }
                            }
                        }
                    }
                }

                if (newConnections.Count == 0) break;
                connections.AddRange(newConnections);
            }

            return connections.Where(x => x[0] == end[0] && x[1] == end[1]).Count() > 0;
        }

        static bool IsInField(char[][] field, int[] p)
        {
            return p[0] >= 0 && p[1] >= 0 && p[0] < field.Length && p[1] < field[0].Length;
        }

        static bool IsConsidered(List<int[]> l, int[] p)
        {
            return l.Where(x => x[0] == p[0] && x[1] == p[1]).Count() > 0;
        }

        static List<List<int[]>> FindTheLines(char[][] field)
        {
            List<List<int[]>> lines = new List<List<int[]>>(0);
            int iLen = field.Length;
            int jLen = field[0].Length;

            // Finding horizontal lines
            for (int i = 0; i < iLen; i++)
            {
                for (int j = 0; j < jLen; j++)
                {
                    if (field[i][j] == '.') continue;
                    List<int[]> line = new List<int[]> { new int[] { i, j } };
                    while (j + 1 < jLen && field[i][j + 1] == field[i][j] && field[i][j] != '.')
                    {
                        j++;
                        line.Add(new int[] { i, j });
                    }

                    if (line.Count >= 5) lines.Add(line);
                }
            }

            // Finding vertical lines
            for (int j = 0; j < jLen; j++)
            {
                for (int i = 0; i < iLen; i++)
                {
                    if (field[i][j] == '.') continue;
                    List<int[]> line = new List<int[]> { new int[] { i, j } };
                    while (i + 1 < iLen && field[i + 1][j] == field[i][j] && field[i][j] != '.')
                    {
                        i++;
                        line.Add(new int[] { i, j });
                    }

                    if (line.Count >= 5) lines.Add(line);
                }
            }

            // Finding diagonal lines right-top --> bottom left, i.e. /
            for (int k = -4; k < jLen - 4; k++)
            {
                int i = iLen - 1;
                int j = k;
                for (; i >= 0; i--, j++)
                {
                    if (!IsInField(field, new int[] { i, j })) continue;
                    if (field[i][j] == '.') continue;
                    List<int[]> line = new List<int[]> { new int[] { i, j } };
                    while (IsInField(field, new int[] { i - 1, j + 1 }) && field[i - 1][j + 1] == field[i][j] && field[i][j] != '.')
                    {
                        i--;
                        j++;
                        line.Add(new int[] { i, j });
                    }

                    if (line.Count >= 5) lines.Add(line);
                }
            }

            // Finding diagonal lines left-top --> bottom right, i.e. \
            for (int k = -4; k < jLen - 4; k++)
            {
                int i = 0;
                int j = k;
                for (; i < iLen; i++, j++)
                {
                    if (!IsInField(field, new int[] { i, j })) continue;
                    if (field[i][j] == '.') continue;
                    List<int[]> line = new List<int[]> { new int[] { i, j } };
                    while (IsInField(field, new int[] { i + 1, j + 1 }) && field[i + 1][j + 1] == field[i][j] && field[i][j] != '.')
                    {
                        i++;
                        j++;
                        line.Add(new int[] { i, j });
                    }

                    if (line.Count >= 5) lines.Add(line);
                }
            }

            return lines;
        }

        static int Score(char[][] field, List<List<int[]>> lines)
        {
            int elemCount = 0;
            foreach (var line in lines)
                foreach (int[] l in line)
                {
                    field[l[0]][l[1]] = '.';
                    elemCount++;
                }

            return lines.Count == 0 ? 0 : lines.Count + elemCount - 1;
        }
    }
}
