using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Two sets of radio waves were broadcast near each other, with the same wavelength. Both broadcasts are represented
// as strings of uppercase English letters, of equal length.
// Since the two broadcasts may have interfered, some of the letters may have been swapped. There could have also
// been external interference that caused some of the letters to be corrupted.

// You've been called in to investigate the interference, so you've been supplied with some test data.
// Specifically, you're given both of the original broadcasts, as well as both of the received broadcasts,
// and your task is to find the minimum number of swaps required to restore them.

// You may only swap characters of equal index; in other words, broadcastA[i] can be swapped with broadcastB[j] only if i = j.
// If there are multiple consecutive characters that need to be swapped, up to three of them can be done in one move.
// If the original broadcasts can't be restored by a series of swaps, return -1.
// Example: For
//              originalA  = "ABAB"
//              originalB  = "CDCD"
//              broadcastA = "CDAD"
//              broadcastB = "ABCB"

//              the output should be reverseInterference(originalA, originalB, broadcastA, broadcastB) = 2.
//              The characters at indices 0, 1, and 3 have all been swapped. Both 0 and 1 can be swapped back in one move,
//              since they're consecutive characters, not exceeding 3 in a row. After that, one more swap will be needed
//              for character 3, for a total of 2 swaps.

//          For
//              originalA = "ABCDEF"
//              originalB  = "ZYXWVU"
//              broadcastA = "AYXWVU"
//              broadcastB = "ZBCDEF"

//              the output should be reverseInterference(originalA, originalB, broadcastA, broadcastB) = 2.
//              From index 1 to index 5, there are five consecutive characters that need to be swapped.
//              Since there are more than 3 in a row, we'll need to split them up into a group of 3 and a group of 2,
//              so it'll take 2 swaps at least.

//          For
//              originalA = "A"
//              originalB  = "Z"
//              broadcastA = "X"
//              broadcastB = "A"

//              the output should be reverseInterference(originalA, originalB, broadcastA, broadcastB) = -1.
//              Even after swapping the characters, the broadcasts won't match the original, so it's not possible
//              for them to be restored. So we return -1.

namespace ReverseInterference
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(reverseInterference("ABCDEF", "ZYXWVU", "AYXWVU", "ZBCDEF"));
            Console.ReadKey();
        }

        // Returns the number of swaps, taht will be necessary to do, for restoration to original broadcasts
        static int reverseInterference(string originalA, string originalB, string broadcastA, string broadcastB)
        {
            int swaps = 0; // the number of necessary swaps
            int len = originalA.Length; // the length of boradcasts
            int consecutiveness = 0; // will be the consecutiveness of current swapped chars in broadcasts
            bool restorable = true; // remains true, while the broadcasts are restorable

            for (int i = 0; restorable && i < len; i++)
            {
                consecutiveness = 0;

                // If the messages are restorable, then add the number of swaps,
                // according to the consecutiveness of swapped chars
                if (Test1(originalA[i], originalB[i], broadcastA[i], broadcastB[i]))
                {
                    while (consecutiveness < 3 && i < len &&
                          Test1(originalA[i], originalB[i], broadcastA[i], broadcastB[i]))
                    {
                        consecutiveness++;
                        i++;
                    }
                    swaps++;
                    i--;
                }

                // If the broadcasts are not restirable then return false, and stop the checking
                if (i < len && !(Test1(originalA[i], originalB[i], broadcastA[i], broadcastB[i]) ||
                    Test3(originalA[i], originalB[i], broadcastA[i], broadcastB[i])))
                    restorable = false;
            }

            return restorable ? swaps : -1; // if restorable, then returning a number of swaps, else -1

        }

        // Checking if original different characters are swapped in broadcasted ones
        static bool Test1(char a, char b, char a1, char b1)
        {
            return (a1 == b && b1 == a && (a != b));
        }

        // Checking if both broadcasted ones, are similar to their original ones
        static bool Test3(char a, char b, char a1, char b1)
        {
            return (a1 == a && b1 == b);
        }
    }
}
