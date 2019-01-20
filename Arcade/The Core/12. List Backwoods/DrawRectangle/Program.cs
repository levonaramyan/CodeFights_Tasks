using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You are implementing a command-line version of the Paint app.Since the command line doesn't
// support colors, you are using different characters to represent pixels. Your current goal
// is to support rectangle x1 y1 x2 y2 operation, which draws a rectangle that has an
// upper left corner at (x1, y1) and a lower right corner at (x2, y2).
// Here the x-axis points from left to right, and the y-axis points from top to bottom.
// PROBLEM: Given the initial canvas state and the array that represents the coordinates
//          of the two corners, return the canvas state after the operation is applied.
//          For the details about how rectangles are painted, see the example.
// Example:
//          For
//          canvas = [['a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'],
//                    ['a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'],
//                    ['a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'],
//                    ['b', 'b', 'b', 'b', 'b', 'b', 'b', 'b'],
//                    ['b', 'b', 'b', 'b', 'b', 'b', 'b', 'b']]
//          and rectangle = [1, 1, 4, 3], the output should be
//          drawRectangle(canvas, rectangle) = [['a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'],
//                                              ['a', '*', '-', '-', '*', 'a', 'a', 'a'],
//                                              ['a', '|', 'a', 'a', '|', 'a', 'a', 'a'],
//                                              ['b', '*', '-', '-', '*', 'b', 'b', 'b'],
//                                              ['b', 'b', 'b', 'b', 'b', 'b', 'b', 'b']]
//          Note that rectangle sides are depicted as -s and |s, asterisks(*) stand for
//          its corners and all of the other "pixels" remain the same.Color in the example
//          is used only for illustration.

namespace DrawRectangle
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static char[][] drawRectangle(char[][] canvas, int[] rectangle)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                    canvas[rectangle[j * 2 + 1]][rectangle[i * 2]] = '*';

                for (int x = rectangle[1] + 1; x < rectangle[3]; x++)
                    canvas[x][rectangle[2 * i]] = '|';
                for (int y = rectangle[0] + 1; y < rectangle[2]; y++)
                    canvas[rectangle[2 * i + 1]][y] = '-';
            }

            return canvas;
        }

    }
}
