using System;
using System.Collections.Generic;
using System.Linq;

// Once upon a time, in a kingdom far, far away, there lived a king Byteasar VIII.
// The king came down in history as a great warrior, since he managed to defeat the enemy
// that has been capturing the cities of the kingdom over more than a century.
// When the war was over, most of the cities were almost completely destroyed,
// and there was no way to raise them from the debris. Byteasar decided to start cities
// renovation by merging them.
// The king decided to merge each pair of cities cityi, cityi+1 for i = 0, 2, 4, ...
// if they were connected by one of the two-way roads running through the kingdom.
// Initially, all information about the roads were stored in the roadRegister.
// Your task is to return the roadRegister after the merging was performed, assuming
// that after merging the cities reindexation is done in such way that city formed
// out of cities a and b (where a < b) receives index a, and all the cities
// with numbers i(where i > b) get numbers i - 1.
// Example:
//          For
//          roadRegister =
//          [
//            [false, true,  true,  false, false, false, true ],
//            [true,  false, true,  false, true,  false, false],
//            [true,  true,  false, true,  false, false, true ],
//            [false, false, true,  false, false, true,  true ],
//            [false, true,  false, false, false, false, false],
//            [false, false, false, true,  false, false, false],
//            [true,  false, true,  true,  false, false, false]
//          ]
//          the output should be
//          mergingCities(roadRegister) = [
//            [false, true,  true,  false, true ],
//            [true,  false, false, true,  true ],
//            [true,  false, false, false, false],
//            [false, true,  false, false, false],
//            [true,  true,  false, false, false]
//          ]
//          Here's how the cities were merged:
//          https://codefightsuserpics.s3.amazonaws.com/tasks/mergingCities/img/example.jpg?_tm=1490636345938


namespace MergingCities
{
    class Program
    {
        static void Main(string[] args)
        {

            // Initializing test array
            bool[][] roadRegister = new bool[7][];
            roadRegister[0] = new bool[] { false, true, true, false, false, false, true };
            roadRegister[1] = new bool[] { true, false, true, false, true, false, false };
            roadRegister[2] = new bool[] { true, true, false, true, false, false, true };
            roadRegister[3] = new bool[] { false, false, true, false, false, true, true };
            roadRegister[4] = new bool[] { false, true, false, false, false, false, false };
            roadRegister[5] = new bool[] { false, false, false, true, false, false, false };
            roadRegister[6] = new bool[] { true, false, true, true, false, false, false };

            // Testing and printing the result
            var res = mergingCities(roadRegister);
            foreach (bool[] row in res)
            {
                foreach (bool b in row) Console.Write($"{b}\t");
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        // Returns the roadmapo after merging the cities
        static bool[][] mergingCities(bool[][] roadRegister)
        {
            int n = roadRegister.Length;

            // Getting the list of cities with even index, which have a connection with i+1 neighbor
            List<int> neighb = Enumerable.Range(0, n).Where(i => i % 2 == 0).
                Select(i => (i < n - 1 && roadRegister[i][i + 1]) ?  i: -1).
                Where(i => i!=-1).ToList();

            // merging the connection lists of the selected above cities and their i+1 neighbors 
            foreach (int i in neighb)
                for(int j = 0; j < n; j++)
                {
                    roadRegister[i][j] = roadRegister[i][j] | roadRegister[i + 1][j];
                    roadRegister[j][i] = roadRegister[j][i] | roadRegister[j][i + 1];
                }

            // list of cities which will be kept after merging
            List<int> cityNum = Enumerable.Range(0, n).Except(neighb.Select(i => i+1)).ToList();

            // getting only selected above cities
            roadRegister = cityNum.Select(i => cityNum.Select(j => roadRegister[i][j]).ToArray()).ToArray();

            // each [i][i] element should be false
            for (int i = 0; i < roadRegister.Length; i++)
                roadRegister[i][i] = false;

            return roadRegister;
        }

    }
}
