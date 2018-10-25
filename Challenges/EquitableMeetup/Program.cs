using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You and your friends are planning out your Halloween night experience! You all have your costumes ready to go,
// and you've decided on a rendezvous point where you'll all meet, then go trick-or-treating.
// You'd all like to meet up as soon as possible, but you're also all interested in picking up
// some candy along the way.So you decide on the following plan:

// Each of you will visit at least one house on your way toward the rendezvous point.
// Eventually each of you will stop visiting houses, but until then no houses will be skipped.
// You decide that fairness is most important, so the goal will be for everyone to visit houses
// in such a way that the total candy spread is minimized (ie: the maximum amount of candy collected
// by any friend minus the minimum amount of candy collected by any friend is the smallest possible).
// From extensive research and prior encounters, you're all aware of how much candy will be given out at each house.
// Since each of you will be walking different routes before meeting up, the amounts given by each house,
// on each friend's path, are represented by friendsRoutes, where friendsRoutes[i][j] is the amount of candy
// given by the jth house that the ith friend will encounter.

// Your task is to find how many houses each friend should visit before going directly to the rendezvous point.

// If there are multiple ways to minimize the spread, choose the option that involves visiting fewer houses
// (so that you can meet up earlier). friendsRoutes is not necessarily a rectangular matrix.
// Example: For

//              friendsRoutes = [[1,2,1,1,1,1], 
//                               [5,4,7,4,5,9], 
//                               [3,3,3,3,3,3,3,3,3]]
//          the output should be equitableMeetup(friendsRoutes) = [4, 1, 2].

// Since each friend must visit at least one house each, the friends will collect 1, 5, and 3 respectively,
// so the initial spread is 5 - 1 = 4.
// The best spread the friends can obtain is 1, and the way to achieve it while visiting the fewest number of houses,
// is for the friends to visit 4, 1, and 2 houses, respectively:
//      Friend 0 collects 1 + 2 + 1 + 1 = 5
//      Friend 1 collects 5
//      Friend 2 collects 3 + 3 = 6
//      Thus the spread is 6 - 5 = 1, which is the minimum possible.

namespace EquitableMeetup
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing a test array of friends routes
            int[][] friends = new int[5][];
            friends[0] = new int[] { 87, 38, 72, 32, 10, 37, 38, 84, 45, 96, 70, 11, 81, 49, 15, 30, 8, 23, 82 };
            friends[1] = new int[] { 94, 94, 17, 87, 5, 44, 78, 63, 93, 47, 86, 35, 21, 98, 33, 86, 45, 87, 40 };
            friends[2] = new int[] { 39, 6, 58, 47, 14, 83, 89, 1, 46, 31, 16, 32, 18, 85, 17, 67, 64, 72, 97 };
            friends[3] = new int[] { 94, 46, 89, 62, 18, 57, 68, 28, 2, 89, 96 };
            friends[4] = new int[] { 26, 61, 87, 29, 22, 32, 59, 19, 29, 11, 79, 35, 63, 39, 63, 89, 5, 11, 47 };

            // Getting an array of minimum house visits, and printing in Console
            int[] passed = equitableMeetup(friends);
            foreach (int i in passed) Console.Write(i + " ");

            Console.ReadKey();
        }

        // Returns an array of house visites, for which the spread of candies is the minimum.
        static int[] equitableMeetup(int[][] friendsRoutes)
        {
            int numberOfFriends = friendsRoutes.Length; // the number of participants
            int minSpread = int.MaxValue; // will be the until the moment the minimum spread
            int[] housesPassed = new int[numberOfFriends]; // will be an array of house visits, for current minimum spread
            int[] tempHousesPassed = new int[numberOfFriends]; // temprorary array of passed housed
            int[] candiesCollected = new int[numberOfFriends]; // an arrayof collected candies, for current minimum spread
            int[] tempCandiesCollected = new int[numberOfFriends]; // temprorary array of collected candies

            // All of the participants visit the first house
            for (int i = 0; i < numberOfFriends; i++)
            {
                housesPassed[i] = 1;
                tempHousesPassed[i] = 1;
                candiesCollected[i] += friendsRoutes[i][0];
                tempCandiesCollected[i] += friendsRoutes[i][0];
            }

            // Getting the values and indexes of current minimum and maximum collected candies
            int curMin = candiesCollected.Min();
            int indexMin = Array.IndexOf(candiesCollected, curMin);
            int curMax = candiesCollected.Max();
            minSpread = curMax - curMin; // calculating the spread, after first visits

            // While the house was not the last for a current friend with minimum candies
            // let him to visit the next house, and then find a new friend with minimum candies,
            // and repeat, repeat and repeat
            while (tempHousesPassed[indexMin] < friendsRoutes[indexMin].Length)
            {
                tempCandiesCollected[indexMin] += friendsRoutes[indexMin][tempHousesPassed[indexMin]];
                tempHousesPassed[indexMin]++;
                curMin = tempCandiesCollected.Min();
                indexMin = Array.IndexOf(tempCandiesCollected, curMin);
                curMax = tempCandiesCollected.Max();

                // when finding a case with minimum spread, then store the store the current information of
                // house visits in housesPassed[], and candies collected in candiesCollected[]
                if (curMax - curMin < minSpread)
                {
                    minSpread = curMax - curMin;
                    for (int i = 0; i < numberOfFriends; i++)
                    {
                        housesPassed[i] = tempHousesPassed[i];
                        candiesCollected[i] = tempCandiesCollected[i];
                    }
                }

                if (minSpread == 0) break;

            }

            return housesPassed;
        }
    }
}
