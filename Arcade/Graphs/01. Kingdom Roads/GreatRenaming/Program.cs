using System;
using System.Linq;

// Once upon a time, in a kingdom far, far away, there lived a king Byteasar VI.
// As any king with such a magnificent name, he was destined to leave a trace in history.
// Unfortunately imagination wasn't one of king Byteasar's strong suits, so the reform
// he came up with was quite simple: the king ordered to rename all the cities.
// He didn't want to come up with new names (as a king, he'd have to remember them all!),
// so he ordered the cities to swap their names in such manner that the ith city would have
// the name of the city number (i + 1)th. The last city in the Byteasar's kingdom would,
// naturally, get the name of the very first city.
// The cartographers were not happy with this reform, since they had to redraw all the maps
// of the kingdom.Before the reform, information about all the roads between the cities
// were stored in the roadRegister. Prior to drawing maps, they had to start with updating
// the register. Your task is to find out what the updated register looked like.
// Example:
//          For
//          roadRegister = [[false, true, true, false],
//                          [true,  false, true,  false],
//                          [true,  true,  false, true ],
//                          [false, false, true,  false]]
//          the output should be
//          greatRenaming(roadRegister) = [[false, false, false, true ],
//                                         [false, false, true,  true ],
//                                         [false, true,  false, true ],
//                                         [true,  true,  true,  false]]
//          Here's how the catalog can be represented before and after the Great Renaming
//          https://codefightsuserpics.s3.amazonaws.com/tasks/greatRenaming/img/example.jpg?_tm=1490626015511


namespace GreatRenaming
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing test array
            bool[][] roadRegister = new bool[4][];
            roadRegister[0] = new bool[] { false, true, true, false };
            roadRegister[1] = new bool[] { true, false, true, false };
            roadRegister[2] = new bool[] { true, true, false, true };
            roadRegister[3] = new bool[] { false, false, true, false };

            // Testing
            bool[][] res = greatRenaming(roadRegister);

            // Printing the rsulting array
            foreach (bool[] r in res)
            {
                foreach (bool c in r) Console.Write($"{c}\t");
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        // Returns the rearranged array with 1 index to right(down)
        static bool[][] greatRenaming(bool[][] roadRegister)
        {
            int n = roadRegister.Length;
            return Enumerable.Range(0, n).Select
                (
                    i => Enumerable.Range(0, n).Select
                    (
                        j => roadRegister[(n + i - 1) % n][(n + j - 1) % n]
                    ).ToArray()
                ).ToArray();
        }
    }
}
