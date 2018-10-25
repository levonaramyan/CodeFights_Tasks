using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You're spending the night at your aunt's 300-year-old mansion which you're convinced is haunted.
// While in bed, the sibilant and shrill noises from around the house keep you awake.
// Are they really ghosts or just the wind?
// You recorded the sounds you had heard as a sequence of low-pitched noises(represented by o)
// and high-pitched ones(represented by u).
// The wind blows wildly and randomly, but ghosts' boos and wails follow a predictable pattern:
// They begin with a non-zero length of low-pitched os, then a non-zero length of high-pitched us,
// and finally another length of low-pitched os that are of the same length as the initial sequence of os.

// For example:

//              "ouo" = ghost
//              "oouuuuuoo" = ghost
//              "ouuooo" = ghost at first, then wind
//              "uo" = wind

// PROBLEM:     Given an uninterrupted sequence of sounds, your task is to determine whether it can be divided
//              into non-overlapping, contiguous subsequences that all follow the pattern of ghosts' wails.
//              If so, return true; otherwise, return false.

namespace WailingGhosts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(wailingGhosts("ouuooo"));
            Console.ReadKey();
        }

        // Returns true, if all pieces of strin sounds, belongs to ghost's wails
        static bool wailingGhosts(string sounds)
        {
            string s = sounds; // short assignment of sounds
            int l = s.Length; // the length of a sound
            int[] ouo = new int[3] { 0, 0, 0 }; // the lengths of current "o" "u" "o" pieces
            bool isGhost = true; // will get false, if it is not a ghost

            // while the pieces of string matches with ghosts sound standards, check the next piece
            while (isGhost && s.Length > 0)
            {
                // the length of first sequence of "o" is the index of first "u"
                int uInd = s.IndexOf('u');
                if (uInd <= 0)
                {
                    isGhost = false;
                    break;
                }
                ouo[0] = uInd;
                s = s.Substring(uInd);

                // the length of first sequence of "u" is the index of first "o"
                int oInd = s.IndexOf('o');
                if (oInd <= 0)
                {
                    isGhost = false;
                    break;
                }

                // If the remaining part of a string contains a sequence of "o"-s, with
                // at least equal to first part's length, then check the remaining, if no
                // then it is not a ghost and break the checking procedure
                ouo[1] = oInd;
                s = s.Substring(oInd);
                if (s.Length < ouo[0] || s.Substring(0, ouo[0]) != new String('o', ouo[0]))
                {
                    isGhost = false;
                    break;
                }

                s = s.Substring(ouo[0]);
            }

            return isGhost;


        }

    }
}
