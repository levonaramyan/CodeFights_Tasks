using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeakNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static int[] weakNumbers(int n)
        {
            int[] divisers = new int[n];
            int[] weakness = new int[n];
            int[] result = new int[2];
            int maxWeak = 0;
            int weakestCount = 0;
            int nDiv = GetDivisersCount(n);

            for (int i = 1; i <= n; i++)
            {
                int countWeakness = 0;
                divisers[i - 1] = GetDivisersCount(i);
                for (int j = 1; j < i; j++)
                {
                    if (divisers[j - 1] > divisers[i - 1]) countWeakness++;
                }
                weakness[i - 1] = countWeakness;
                if (weakness[i - 1] > maxWeak) maxWeak = weakness[i - 1];
            }

            foreach (int i in weakness)
                if (i == maxWeak) weakestCount++;

            result[0] = maxWeak;
            result[1] = weakestCount;

            return result;

        }

        static int GetDivisersCount(int num)
        {
            int count = 0;

            for (int i = 1; i <= (int)Math.Sqrt(num); i++)
                count = IsDiviser(num, i) ? ((num / i != i) ? (count + 2) : (count + 1)) : count;

            return count;
        }

        static bool IsDiviser(int num, int candidate)
        {
            return (num % candidate == 0);
        }
    }
}
