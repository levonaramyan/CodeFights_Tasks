using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Call two arms equally strong if the heaviest weights they each are able to lift are equal.
//Call two people equally strong if their strongest arms are equally strong
//(the strongest arm can be both the right and the left), and so are their weakest arms.
// PROBLEM: Given your and your friend's arms' lifting capabilities find out if you two are equally strong.

namespace areEquallyStrong
{
    class Program
    {
        static void Main(string[] args)
        {
            // initializing test values of arm strengths
            int yourLeft = 6;
            int yourRight = 15;
            int friendsLeft = 15;
            int friendsRight = 5;

            // Printing whether two people are equally strong
            Console.WriteLine(areEquallyStrong(yourLeft,yourRight,friendsLeft,friendsRight));
            Console.ReadKey();

        }

        // The method returns true, if two people are equally strong
        static bool areEquallyStrong(int yourLeft, int yourRight, int friendsLeft, int friendsRight)
        {
            bool totalStrengthEqual = (yourLeft + yourRight == friendsLeft + friendsRight);
            bool handDiffEqual = (Math.Abs(yourLeft - yourRight) == Math.Abs(friendsLeft - friendsRight));
            return (totalStrengthEqual && handDiffEqual);
                    
        }

    }
}
