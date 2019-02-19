using System;
using System.Collections.Generic;
using System.Linq;

// Once upon a time, in a kingdom far, far away, there lived a king Byteasar IV.
// As Interkingdomial financial crisis was roaring through the neighborhood,
// Byteasar was struggling with keeping the economy out of recession.
// Unfortunately there was not much he could do. After long and deep thinking,
// the king came to the only solution: one of his cities should be demolished,
// since keeping communication between all the cities is way too expensive.
// It is not yet known if Byteasar chose the city to destroy after a careful
// planning or picked one at random.As a person with PhD in history and Nobel prize
// in Computer Science, you can solve this mystery.Archaeologists have recently found
// a manuscript with the information about the roads between the cities,
// that is now stored in the roadRegister matrix.You want to try and remove each city
// one by one and compare the road registers obtained this way.Thus you'll be able
// to compare the obtained roads and determine whether the one picked by Byteasar was
// the best by some criteria.
// Given the roadRegister, return an array of all the road registers obtained
// after removing each of the city one by one.
// Example:
//          For
//          roadRegister = [[false, true, true, false],
//                          [true,  false, true,  false],
//                          [true,  true,  false, true ],
//                          [false, false, true,  false]]
//          the output should be
//          financialCrisis(roadRegister) = [
//            [[false, true,  false],
//             [true,  false, true ],
//             [false, true,  false]],
//            [[false, true,  false],
//             [true,  false, true ],
//             [false, true,  false]],
//            [[false, true,  false],
//             [true,  false, false],
//             [false, false, false]],
//            [[false, true,  true ],
//             [true,  false, true ],
//             [true,  true,  false]]
//          ]
//          Here's the city connection that the given catalog represents:
//          https://codefightsuserpics.s3.amazonaws.com/tasks/financialCrisis/img/initial.jpg?_tm=1490625952769
//          And here's how the cities are connected with one of the cities destroyed
//          (cities 0 - 3, respectively):
//          https://codefightsuserpics.s3.amazonaws.com/tasks/financialCrisis/img/deck.jpg?_tm=1490625953053


namespace FinancialCrisis
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
            bool[][][] res = financialCrisis(roadRegister);

            // Printing the result of the test
            foreach (var rR in res)
            {
                foreach(var r in rR)
                {
                    foreach (bool v in r) Console.Write($"{v} ");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            Console.ReadKey();

        }

        // Returns all the possible variants of removing one city
        static bool[][][] financialCrisis(bool[][] roadRegister)
        {
            int dim = roadRegister.Length;
            bool[][][] res = new bool[dim][][];
            for (int i = 0; i < dim; i++)
                res[i] = RemoveAt<bool[]>
                    (
                        (roadRegister.Select(x => (RemoveAt<bool>(x.ToList(),i)).ToArray())).ToList(),
                        i
                    ).ToArray();

            return res;
        }

        // removes the i-th element and returns the list
        static List<t> RemoveAt<t>(List<t> l,int i)
        {
            l.RemoveAt(i);
            return l;
        }
    }
}
