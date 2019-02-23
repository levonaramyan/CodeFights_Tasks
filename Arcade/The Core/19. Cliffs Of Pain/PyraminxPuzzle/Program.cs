using System;
using System.Collections.Generic;
using System.Linq;

// You've mastered the Rubik's Cube and got bored solving it, so now you are looking
// for a new challenge. One puzzle similar to the Rubik's Cube caught your attention.
// It's called a Pyraminx puzzle, and is a triangular pyramid-shaped puzzle.
// The parts are arranged in a pyramidal pattern on each side, while the layers can be
// rotated with respect to each vertex, and the individual tips can be rotated as well.
// There are 4 faces on the Pyraminx. The puzzle should be held so that one face faces you
// and one face faces down, as in the image below. The four corners are then labeled U (for up),
// R (for right), L (for left), and B (for back). The front face thus contains the U, R,
// and L corners.
// https://codefightsuserpics.s3.amazonaws.com/tasks/pyraminxPuzzle/img/notation.gif?_tm=1490636526830
// Let's write down all possible moves for vertex U in the following notation:
//      U - 120° counterclockwise turn of topmost tip(assuming that we're looking at the pyraminx
//          from the top, and vertex U is the topmost);
//      U' - clockwise turn for the same tip;
//      u - 120° counterclockwise turn of two upper layer;
//      u' - clockwise turn for the same layers.
// https://codefightsuserpics.s3.amazonaws.com/tasks/pyraminxPuzzle/img/moves.png?_tm=1490636527040
// For other vertices the moves can be described similarly:
// https://codefightsuserpics.s3.amazonaws.com/tasks/pyraminxPuzzle/img/moves.gif?_tm=1490636527763
// The first puzzle you bought wasn't assembled, so you get your professional pyraminx solver
// friend to assemble it. He does, and you wrote down all his moves notated as described above.
// Now the puzzle's faces have colors faceColors[0] (front face), faceColors[1] (bottom face),
// faceColors[2] (left face), faceColors[3] (right face). You want to know the initial state
// of the puzzle to repeat your friend's moves and see how he solved it.
// Example:
//          For faceColors = ['R', 'G', 'Y', 'O'] and moves = ["B", "b'", "u'", "R"],
//          the output should be
//          pyraminxPuzzle(faceColors, moves) = [['Y', 'Y', 'Y', 'Y', 'R', 'R', 'R', 'R', 'G'],
//                                               ['G', 'R', 'O', 'O', 'O', 'G', 'G', 'G', 'G'],
//                                               ['Y', 'O', 'Y', 'G', 'O', 'O', 'G', 'G', 'Y'],
//                                               ['R', 'O', 'O', 'R', 'O', 'Y', 'Y', 'R', 'R']]
//          Let's repeat the friend's steps in reverse order:
//          Final state:
//          https://codefightsuserpics.s3.amazonaws.com/tasks/pyraminxPuzzle/img/end.gif?_tm=1490636527953
//          Before the last move:
//          https://codefightsuserpics.s3.amazonaws.com/tasks/pyraminxPuzzle/img/move1.gif?_tm=1490636528147
//          One more move before that:
//          https://codefightsuserpics.s3.amazonaws.com/tasks/pyraminxPuzzle/img/move2.gif?_tm=1490636528303
//          And one more:
//          https://codefightsuserpics.s3.amazonaws.com/tasks/pyraminxPuzzle/img/move3.gif?_tm=1490636528447
//          Finally, the initial state:
//          https://codefightsuserpics.s3.amazonaws.com/tasks/pyraminxPuzzle/img/move4.gif?_tm=1490636528585



namespace PyraminxPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing test arrays
            char[] faceColors = new char[] { 'R', 'G', 'Y', 'O' };
            string[] moves = new string[] { "B", "b'", "u'", "R" };

            // Testing and printing the result
            char[][] pyr = pyraminxPuzzle(faceColors, moves);
            PrintPyramid(pyr);

            Console.ReadKey();
        }

        // Returns the initial state of pyraminx puzzle
        static char[][] pyraminxPuzzle(char[] faceColors, string[] moves)
        {
            moves = moves.Reverse().ToArray();
            char[][] pyr = Enumerable.Range(0, 4).
                Select(i => Enumerable.Range(0, 9).
                            Select(j => faceColors[i]).ToArray()).ToArray();

            foreach (string move in moves)
            {
                Rotate(ref pyr, move);
                //PrintPyramid(pyr); Console.WriteLine();
            }

            return pyr;

        }

        // Implements a rotation of pyr, according to instruction move
        static void Rotate(ref char[][] pyr, string move)
        {
            // the anti-clockwise order of rotating faces for each axis
            List<int> uOrder = new List<int> { 0, 3, 2 };
            List<int> rOrder = new List<int> { 0, 1, 3 };
            List<int> lOrder = new List<int> { 0, 2, 1 };
            List<int> bOrder = new List<int> { 1, 2, 3 };

            // Below are the list of corresponding elements of each face for the given axis
            // index 1 idicates the top line
            // index 2 indicates the second line

            // U, R, L
            List<List<int>> u1 = new List<List<int>>
            {
                new List<int> { 0},
                new List<int>{ 8},
                new List<int>{ 4}
            };

            // U, R, L
            List<List<int>> u2 = new List<List<int>>
            {
                new List<int> { 1,2,3},
                new List<int>{ 3,7,6},
                new List<int>{ 6,5,1}
            };

            // U, B, R
            List<List<int>> r1 = new List<List<int>>
            {
                new List<int> { 8},
                new List<int>{ 4},
                new List<int>{ 0}
            };

            // U, B, R
            List<List<int>> r2 = new List<List<int>>
            {
                new List<int> { 3,7,6},
                new List<int>{ 6,5,1},
                new List<int>{ 1,2,3}
            };

            // U, L, B
            List<List<int>> l1 = new List<List<int>>
            {
                new List<int> { 4},
                new List<int>{ 0},
                new List<int>{ 8}
            };

            // U, L, B
            List<List<int>> l2 = new List<List<int>>
            {
                new List<int> { 6,5,1},
                new List<int>{ 1,2,3},
                new List<int>{ 3,7,6}
            };

            // B, L, R
            List<List<int>> b1 = new List<List<int>>
            {
                new List<int> { 0},
                new List<int>{ 8},
                new List<int>{ 4}
            };

            // B, L, R
            List<List<int>> b2 = new List<List<int>>
            {
                new List<int> { 1, 2, 3},
                new List<int>{ 3, 7, 6},
                new List<int>{ 6, 5, 1 }
            };

            // implementing the move operation
            switch (move)
            {
                case "U":
                    RotateLines(ref pyr, u1, uOrder, false);
                    break;
                case "U'":
                    RotateLines(ref pyr, u1, uOrder, true);
                    break;
                case "u":
                    RotateLines(ref pyr, u2, uOrder, false);
                    goto case "U";
                    break;
                case "u'":
                    RotateLines(ref pyr, u2, uOrder, true);
                    goto case "U'";
                    break;
                case "B":
                    RotateLines(ref pyr, b1, bOrder, false);
                    break;
                case "B'":
                    RotateLines(ref pyr, b1, bOrder, true);
                    break;
                case "b":
                    RotateLines(ref pyr, b2, bOrder, false);
                    goto case "B";
                    break;
                case "b'":
                    RotateLines(ref pyr, b2, bOrder, true);
                    goto case "B'";
                    break;
                case "L":
                    RotateLines(ref pyr, l1, lOrder, false);
                    break;
                case "L'":
                    RotateLines(ref pyr, l1, lOrder, true);
                    break;
                case "l":
                    RotateLines(ref pyr, l2, lOrder, false);
                    goto case "L";
                    break;
                case "l'":
                    RotateLines(ref pyr, l2, lOrder, true);
                    goto case "L'";
                    break;
                case "R":
                    RotateLines(ref pyr, r1, rOrder, false);
                    break;
                case "R'":
                    RotateLines(ref pyr, r1, rOrder, true);
                    break;
                case "r":
                    RotateLines(ref pyr, r2, rOrder, false);
                    goto case "R";
                    break;
                case "r'":
                    RotateLines(ref pyr, r2, rOrder, true);
                    goto case "R'";
                    break;
            }
        }

        // Rotates the selected line in pyr
        // cor is a list of corresponding elements of each faces in anti-clockwise order,
        // faces indicate the anti-clockwise order of the faces,
        // dir indicates whether the rotation is clockwise or anti-clockwise
        static void RotateLines(ref char[][] pyr, List<List<int>> cor, List<int> faces, bool dir)
        {
            for (int i = 0; i < cor[0].Count; i++)
            {
                char a = pyr[faces[0]][cor[0][i]];
                char b = pyr[faces[1]][cor[1][i]];
                char c = pyr[faces[2]][cor[2][i]];

                pyr[faces[1]][cor[1][i]] = dir ? a : c;
                pyr[faces[2]][cor[2][i]] = dir ? b : a;
                pyr[faces[0]][cor[0][i]] = dir ? c : b;
            }
        }

        // Print the current state of the pyramid
        static void PrintPyramid(char[][] pyr)
        {
            foreach (char[] row in pyr)
            {
                foreach (char c in row) Console.Write($"{c} ");
                Console.WriteLine();
            }
        }
    }
}
