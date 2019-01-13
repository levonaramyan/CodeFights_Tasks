using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfClans
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int numberOfClans(int[] divisors, int k)
        {
            int countFriends = 0;
            int[] clans = new int[k];
            for (int i = 0; i < k; i++)
            {
                clans[i] = -1;
            }

            int index = 0;
            for (int i = 1; i <= k; i++)
            {
                int j = 0;
                bool isNewClan = true;
                while (j < k && clans[j] >= 0)
                {
                    if (AreFriends(divisors, i, clans[j]))
                    {
                        isNewClan = false;
                        break;
                    }
                    j++;
                }

                if (isNewClan)
                {
                    clans[index] = i;
                    index++;
                }

            }

            return index;

        }

        static bool AreFriends(int[] divisors, int A, int B)
        {
            bool areFriends = true;
            for (int i = 0; areFriends && i < divisors.Length; i++)
            {
                areFriends = (A % divisors[i] == 0) == (B % divisors[i] == 0);
            }

            return areFriends;
        }
    }
}
