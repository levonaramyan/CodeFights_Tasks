using System;

// Some people run along a straight line in the same direction. They start simultaneously at
// pairwise distinct positions and run with constant speed (which may differ from person to person).
// If two or more people are at the same point at some moment we call that a meeting.
// The number of people gathered at the same point is called meeting cardinality.
// For the given starting positions and speeds of runners find the maximum meeting
// cardinality assuming that people run infinitely long. If there will be no meetings, return -1 instead.
// Example:
//          For startPosition = [1, 4, 2] and speed = [27, 18, 24], the output should be
//          runnersMeetings(startPosition, speed) = 3.
//          In 20 seconds after the runners start running, they end up at the same point.

namespace RunnersMeetings
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int runnersMeetings(int[] startPosition, int[] speed)
        {
            int res = -1;
            for (int i = 0; i < startPosition.Length - 1; i++)
            {
                for (int j = i + 1; j < startPosition.Length; j++)
                {
                    int tempres = 1;
                    int p1 = startPosition[i], p2 = startPosition[j];
                    int s1 = speed[i], s2 = speed[j];
                    if (p1 < p2 == s1 > s2)
                    {
                        tempres++;
                        for (int h = j + 1; h < startPosition.Length; h++)
                        {
                            int p3 = startPosition[h], s3 = speed[h];
                            if ((p2 < p3 == s2 > s3) && Math.Abs((s1 - s2) * (p2 - p3)) == Math.Abs((s2 - s3) * (p1 - p2)))
                                tempres++;
                        }
                    }

                    res = (tempres > 1 && tempres > res) ? tempres : res;
                }
            }

            return res;
        }
    }
}
