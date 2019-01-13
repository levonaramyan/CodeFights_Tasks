using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseOfCats
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[] houseOfCats(int legs)
        {
            int variants = legs / 4 + 1;
            int[] numOfPeople = new int[variants];
            for (int i = 0; i <= legs / 4; i++)
            {
                numOfPeople[variants - 1 - i] = (legs - i * 4) / 2;
            }

            return numOfPeople;
        }

    }
}
