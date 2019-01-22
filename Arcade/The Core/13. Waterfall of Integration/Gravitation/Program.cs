using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You are given a vertical box divided into equal columns. Someone dropped several stones
// from its top through the columns. Stones are falling straight down at a constant speed
// (equal for all stones) while possible (i.e. while they haven't reached the ground or
// they are not blocked by another motionless stone). Given the state of the box
// at some moment in time, find out which columns become motionless first.
// Example:
//          For
//          rows = ["#..##",
//                  ".##.#",
//                  ".#.##",
//                  "....."]
//          the output should be gravitation(rows) = [1, 4].
//          Check out the image below for better understanding:
//          https://codefightsuserpics.s3.amazonaws.com/tasks/gravitation/img/example.png?_tm=1530798973334


namespace Gravitation
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[] gravitation(string[] rows)
        {
            int height = rows.Length;
            int width = rows[0].Length;
            int statCols = NumOfStaticCols(rows);
            if (statCols > 0) return GetStaticAtBeginningCols(rows, statCols);
            return GetFirstStaticCols(rows);

        }

        static int NumOfStaticCols(string[] rows)
        {
            int staticNum = 0;
            int height = rows.Length;
            int width = rows[0].Length;
            for (int j = 0; j < width; j++)
            {
                int numOfDots = 0;
                int numOfAsts = 0;
                int heightOfFirstAst = 0;
                for (int i = 0; i < height; i++)
                {
                    if (heightOfFirstAst == 0 && rows[i][j] == '#') heightOfFirstAst = height - i;
                    numOfDots += (rows[i][j] == '.') ? 1 : 0;
                    numOfAsts += (rows[i][j] == '#') ? 1 : 0;
                }
                if (numOfDots == height || (rows[height - 1][j] == '#' && numOfAsts == heightOfFirstAst))
                    staticNum++;
            }

            return staticNum;
        }

        static int[] GetStaticAtBeginningCols(string[] rows, int colNum)
        {
            int[] statCols = new int[colNum];
            int index = 0;
            int height = rows.Length;
            int width = rows[0].Length;
            for (int j = 0; index <= colNum && j < width; j++)
            {
                int numOfDots = 0;
                int numOfAsts = 0;
                int heightOfFirstAst = 0;
                for (int i = 0; i < height; i++)
                {
                    if (heightOfFirstAst == 0 && rows[i][j] == '#') heightOfFirstAst = height - i;
                    numOfDots += (rows[i][j] == '.') ? 1 : 0;
                    numOfAsts += (rows[i][j] == '#') ? 1 : 0;
                }
                if (numOfDots == height || (rows[height - 1][j] == '#' && numOfAsts == heightOfFirstAst))
                {
                    statCols[index] = j;
                    index++;
                }
            }

            return statCols;
        }

        static int[] GetFirstStaticCols(string[] rows)
        {
            int height = rows.Length;
            int width = rows[0].Length;
            int staticNum = 1;
            int minTime = height + 1;
            int[] time = new int[width];
            for (int j = 0; j < width; j++)
            {
                for (int i = 0; i < height; i++)
                {
                    if (time[j] == 0 && rows[i][j] == '#') time[j] = height - i;
                    else if (time[j] > 0 && rows[i][j] == '#') time[j]--;
                }

                if (time[j] < minTime) { minTime = time[j]; staticNum = 1; }
                else if (time[j] == minTime) staticNum++;
            }

            int[] firstStaticCols = new int[staticNum];
            int index = 0;

            for (int i = 0; i < width; i++)
                if (time[i] == minTime) { firstStaticCols[index] = i; index++; }

            return firstStaticCols;
        }
    }
}
