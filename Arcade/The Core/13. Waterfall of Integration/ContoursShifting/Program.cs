using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Mark got a rectangular array matrix for his birthday, and now he's thinking about all the fun things
// he can do with it. He likes shifting a lot, so he decides to shift all of its i-contours
// in a clockwise direction if i is even, and counterclockwise if i is odd.
// Here is how Mark defines i-contours:
// the 0-contour of a rectangular array as the union of left and right columns as well as top and bottom rows;
// consider the initial matrix without the 0-contour: its 0-contour is the 1-contour of the initial matrix;
// define 2-contour, 3-contour, etc. in the same manner by removing 0-contours from the obtained arrays.
// Implement a function that does exactly what Mark wants to do to his matrix.
// Example:
//          For
//          matrix = [[ 1,  2,  3,  4],
//                     [ 5,  6,  7,  8],
//                     [ 9, 10, 11, 12],
//                     [13, 14, 15, 16],
//                     [17, 18, 19, 20]]
//          the output should be
//          contoursShifting(matrix) = [[ 5,  1,  2,  3],
//                                       [ 9,  7, 11,  4],
//                                       [13,  6, 15,  8],
//                                       [17, 10, 14, 12],
//                                       [18, 19, 20, 16]]
//
//          For matrix = [[238, 239, 240, 241, 242, 243, 244, 245]],
//          the output should be
//          contoursShifting(matrix) = [[245, 238, 239, 240, 241, 242, 243, 244]].
//          Note, that if a contour is represented by a 1 × n array, its center is considered to be below it.
//
//          For
//          matrix = [[238],
//                    [239],
//                    [240],
//                    [241],
//                    [242],
//                    [243],
//                    [244],
//                    [245]]
//          the output should be
//          contoursShifting(matrix) = [[245],
//                                      [238],
//                                      [239],
//                                      [240],
//                                      [241],
//                                      [242],
//                                      [243],
//                                      [244]]
//          If a contour is represented by an n × 1 array, its center is considered to be to the left of it.

namespace ContoursShifting
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[][] contoursShifting(int[][] matrix)
        {
            int r = matrix.Length;
            int c = matrix[0].Length;
            int minLen = (r < c) ? r : c;
            int contNum = (r < c) ? (r / 2 + r % 2) : (c / 2 + c % 2);

            for (int i = 1; i <= contNum; i++)
            {
                int rCont = r - 2 * (contNum - i);
                int cCont = c - 2 * (contNum - i);
                int elemNum = (rCont <= 2 || cCont <= 2) ? rCont * cCont : 2 * (rCont + cCont) - 4;

                int[] contour = GetContArray(matrix, i, contNum, elemNum);

                bool isClockwise = (r == 1 || c == 1) ? true : (contNum - i) % 2 == 0;
                int[] shifted = ShiftContArray(contour, isClockwise);
                matrix = SetContArray(matrix, shifted, i, contNum);
            }

            return matrix;

        }

        static int[] GetContArray(int[][] matrix, int index, int cNum, int arrLen)
        {
            int[] arr = new int[arrLen];
            bool throughJ = true;
            int iterI = 1, iterJ = 1;
            int len1 = matrix.Length;
            int len2 = matrix[0].Length;
            int i = cNum - index;
            int j = i;

            for (int k = 0; k < arrLen; k++)
            {
                arr[k] = matrix[i][j];

                if (throughJ && ((j + iterJ) == (len2 - cNum + index) || (j + iterJ) == (cNum - index - 1)))
                {
                    throughJ = false;
                    iterJ *= -1;
                }

                if (!throughJ && ((i + iterI) == (len1 - cNum + index) || (i + iterI) == (cNum - index - 1)))
                {
                    throughJ = true;
                    iterI *= -1;
                }

                i = (!throughJ) ? i + iterI : i;
                j = (throughJ) ? j + iterJ : j;
            }

            return arr;
        }

        static int[][] SetContArray(int[][] matrix, int[] contour, int index, int cNum)
        {
            int arrLen = contour.Length;
            bool throughJ = true;
            int iterI = 1, iterJ = 1;
            int len1 = matrix.Length;
            int len2 = matrix[0].Length;
            int i = cNum - index;
            int j = i;

            for (int k = 0; k < arrLen; k++)
            {
                matrix[i][j] = contour[k];

                if (throughJ && ((j + iterJ) == (len2 - cNum + index) || (j + iterJ) == (cNum - index - 1)))
                {
                    throughJ = false;
                    iterJ *= -1;
                }

                if (!throughJ && ((i + iterI) == (len1 - cNum + index) || (i + iterI) == (cNum - index - 1)))
                {
                    throughJ = true;
                    iterI *= -1;
                }

                i = (!throughJ) ? i + iterI : i;
                j = (throughJ) ? j + iterJ : j;
            }

            return matrix;
        }

        static int[] ShiftContArray(int[] contour, bool clockwise)
        {
            int len = contour.Length;
            int iter = clockwise ? -1 : 1;
            int[] shifted = new int[len];
            for (int i = 0; i < len; i++)
                shifted[i] = contour[(len + i + iter) % len];
            return shifted;
        }

    }
}
