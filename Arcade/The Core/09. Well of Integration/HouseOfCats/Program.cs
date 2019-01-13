using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// There are some people and cats in a house. You are given the number of legs they have all together.
// Your task is to return an array containing every possible number of people that could be
// in the house sorted in ascending order. It's guaranteed that each person has 2 legs and each cat has 4 legs.
// Example:
//          For legs = 6, the output should be
//          houseOfCats(legs) = [1, 3].
//          There could be either 1 cat and 1 person(4 + 2 = 6) or 3 people(2 * 3 = 6).
//
//          For legs = 2, the output should be
//          houseOfCats(legs) = [1].
//          There can be only 1 person.

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
