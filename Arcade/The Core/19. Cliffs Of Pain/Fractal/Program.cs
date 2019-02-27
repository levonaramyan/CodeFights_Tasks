using System;
using System.Collections.Generic;
using System.Linq;

// Your task is to draw a special fractal after n iterations. The fractal consists
// of unit connectors '|' and '_'.
// For n = 1 the fractal looks as follows:
//      _
//      _|
// Now assume that you have already made N iterations and drawn the f(N) fractal.
// To draw the f(N + 1) fractal do the following:
// Note that every fractal has exactly two edge points which can be connected to the edge points
// of other fractals using the unit connectors.
// At first, take the f(N) fractal and place it in the top left corner. As the next step,
// put f(N) rotated by 0°, 90°, 180° or 270° in the remaining 3 quarters - top right,
// bottom left and bottom right - so that it is possible to connect all four of them by adding
// exactly 3 unit connectors between the adjacent fractal edge points.
// Note that there is always exactly one possible combination of rotations which allows
// to connect all 4 f(N) fractals together.
// See examples below for better understanding.
// Example:
//          For n = 1, the output should be
//          [[' ', '_', ' '],
//           [' ', '_', '|']] 
//          In other words, it should represent _
//          the following picture:              _|
//
//          For n = 2, the output should be
//          [[' ', '_', ' ', ' ', ' ', '_', ' '],      
//           [' ', '_', '|', ' ', '|', '_', ' '],                                  
//           ['|', ' ', ' ', '_', ' ', ' ', '|'],                                 
//           ['|', '_', '|', ' ', '|', '_', '|']]
//          Or, to put it differently:  _   _
//                                      _| |_
//                                     |  _  |
//                                     |_| |_| 
//
//          For n = 3, the fractal looks as follows:
//                                _   ___   ___
//                                _| |_  |_|  _|
//                               |  _  |  _  |_ 
//                               |_| |_| | |___|
//                                _   _  |  ___ 
//                               | |_| | |_|  _|
//                               |_   _|  _  |_
//                                _| |___| |___|
//
//          For n = 4, the fractal looks as follows:
//                         _   ___   ___   ___   ___   _
//                         _| |_  |_|  _| |_  |_|  _| |_ 
//                        |  _  |  _  |_   _|  _  |  _  |
//                        |_| |_| | |___| |___| | |_| |_|
//                         _   _  |  ___   ___  |  _   _
//                        | |_| | |_|  _| |_  |_| | |_| |
//                        |_   _|  _  |_   _|  _  |_   _|
//                         _| |___| |___| |___| |___| |_ 
//                        |  ___   ___   _   ___   ___  |
//                        |_|  _| |_  |_| |_|  _| |_  |_|
//                         _  |_   _|  _   _  |_   _|  _ 
//                        | |___| |___| | | |___| |___| |
//                        |_   _____   _| |_   _____   _|
//                         _| |_   _| |_   _| |_   _| |_ 
//                        |  _  | |  _  | |  _  | |  _  |
//                        |_| |_| |_| |_| |_| |_| |_| |_|

namespace Fractal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the resulting fractal
            PrintSegment(fractal(4));

            Console.ReadKey();
        }

        // Returns a fractl of order n
        static char[][] fractal(int n)
        {
            // n = 1 fractal in not arranged form
            char[][] start = new char[3][];
            start[0] = new char[] { ' ', '_', ' ' };
            start[1] = new char[] { ' ', ' ', '|' };
            start[2] = new char[] { ' ', '_', ' ' };

            // Iteratively getting n-th fractal
            for (int i = 2; i <= n; i++)
                start = NextIteration(start, i);

            // Arrange and return the final view
            return ReturnFinalView(start);
        }

        // Returns the rotated array [][] 90 degrees clockwise
        static char[][] Rotate(char[][] fr)
        {
            return Enumerable.Range(0,fr[0].Length).Select
                (
                    j => Enumerable.Range(0,fr.Length).Select
                    (
                        i => fr[i][j] =='_' ? '|' : fr[i][j] == '|' ? '_' : ' '
                    ).Reverse().ToArray()
                ).ToArray();
        }

        // For Testing purpose: printing the input[][] in the console
        static void PrintSegment(char[][] input)
        {
            foreach (var x in input)
            {
                foreach (char c in x) Console.Write($"{c} ");
                Console.WriteLine();
            }
        }

        // Constructs a new +1 order fractal from previous iteration
        static char[][] NextIteration(char[][] fr0, int n)
        {
            int len = fr0.Length;
            var fr1 = Rotate(fr0); // rotated 90 degrees clockwise
            var fr2 = Rotate(fr1); // rotated 180 degrees clockwise
            var fr3 = Rotate(fr2); // rotated 270 degrees clockwise
            char[][] res;

            // for even n-s the new fractal will be constructed with given orientations
            //      fr0 fr2
            //      fr1 fr1
            if (n % 2 == 0)
            {
                char[] middle = $"|{new string(' ', 2 * len - 1)}|".ToCharArray();
                res = Enumerable.Range(0, len).Select(i => MergeArrays(fr0[i], fr2[i])).Union
                    (
                        new List<char[]>{ middle}.Union(
                        Enumerable.Range(0, len).Select(j => MergeArrays(fr1[j], fr1[j])))
                    ).ToArray();
                res[len+1][len] = '_';
            }                
            else
            // for odd n-s the new fractal will be constructed with given orientations
            //      fr0 fr3
            //      fr2 fr3
            {
                char[] middle = $"{new string(' ', 2 * len + 1)}".ToCharArray();
                middle[len+1] = '|';
                res = Enumerable.Range(0, len).Select(i => MergeArrays(fr0[i], fr3[i])).Union
                    (
                        new List<char[]> { middle }.Union(
                        Enumerable.Range(0, len).Select(j => MergeArrays(fr2[j], fr3[j])))
                    ).ToArray();
                res[0][len] = '_';
                res[2 * len][len] = '_';
            }
                

            return res;
        }

        // Returns the mergeing of two char arrays with ' ' element in the middle
        static char[] MergeArrays(char[] a, char[] b)
        {
            var res = a.ToList();
            res.Add(' ');
            res.AddRange(b);
            return res.ToArray();
        }

        // Reconstructs the final view of the fractal
        static char[][] ReturnFinalView(char[][] input)
        {
            List<char[]> output = new List<char[]> { input[0] };

            // shift 1 step down all the '|' symbols and delete the empty rows
            for (int i = 2; i < input.Length; i+=2)
            {
                output.Add(Enumerable.Range(0, input[0].Length).Select
                    (
                        j => input[i][j] != ' ' ? input[i][j] : input[i - 1][j]
                    ).ToArray());
            }
            char[][] res = output.ToArray();

            // fill the '_',' ', '_' cases with '_' in the middle
            for (int i = 0; i < res.Length; i++)
                for (int j = 2; j < res[0].Length; j++)
                    if (res[i][j] == '_' && res[i][j - 1] == ' ' && res[i][j - 2] == '_') res[i][j-1] = '_';

            return res;
        }
    }
}
