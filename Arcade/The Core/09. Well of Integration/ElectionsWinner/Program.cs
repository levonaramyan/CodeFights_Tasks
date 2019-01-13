using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionsWinner
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int electionsWinners(int[] votes, int k)
        {
            int count = 0;
            int maxCounts = 0;
            int maxVotes = votes.Max();

            foreach (int i in votes)
            {
                if (i + k > maxVotes) count++;
                if (i == maxVotes) maxCounts++;
            }

            if (k == 0 && maxCounts == 1) count = 1;
            return count;

        }
    }
}
