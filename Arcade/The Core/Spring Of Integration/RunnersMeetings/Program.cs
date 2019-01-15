using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
