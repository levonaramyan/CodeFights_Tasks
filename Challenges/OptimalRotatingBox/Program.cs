using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You're moving another large rectangular box over a rough, hazardous surface. Just like last time,
// your only movement option is to perform a series of 90 degree rotations (basically just repeatedly
// pushing the box over onto its side).

// Again, every time you rotate the box, it hits the ground and some damage is done, depending on the
// fragility of the side of the box that it landed on, as well as the roughness of the ground in the region
// where it was dropped.But this time, the box can be customized - so long as the original dimensions
// are maintained, each part of the box can be rearranged, so that the more fragile areas are less exposed
// to the rough parts of the surface.

// Given boxWeakness representing the original state of the box, and surfaceRoughness representing how
// damaging the surface is, your task is to find the minimum possible total damage the box can receive
// after being rotated across the entire surface.

// Notes:
//          All parts of the box must be used; no parts can be duplicated or destroyed.
//          The length of the surface might not perfectly fit the box; if there's some overhang on the last step,
//          that part won't be damaged.
//          Once the box has been customized, it can't be rearranged again throughout its rotation.
//
// Example:
//          For
//          boxWeakness = ["01",
//                         "21",
//                         "10"]
//          and surfaceRoughness = "39513695380152438476", the output should be
//          optimalRotatingBox(boxWeakness, surfaceRoughness) = 49.
//          In its original orientation, the box will take 56 units of damage, but it can be rearranged
//          in such a way that the total damage is as low as 49.
//          1*3 + 0*9 + 0*5 + 2*1 + 1*3 + 1*6 + 0*9 + 0*5 + 1*3 + 1*8 + 1*0 + 0*1 + 0*5 + 2*2 + 1*4 +
//                                                                      1*3 + 0*8 + 0*4 + 1*7 + 1*6 = 49

namespace OptimalRotatingBox
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] boxWeakness = new string[] {"01",
                                                 "21",
                                                 "10"};
            string surf = "39513695380152438476";

            Console.WriteLine(optimalRotatingBox(boxWeakness,surf));
            Console.ReadKey();
        }

        // Returns the minimum damage of the box, that could be obtained after rearrangement
        static int optimalRotatingBox(string[] boxWeakness, string surfaceRoughness)
        {
            int sum = 0;
            int[] bMin = MinArr(boxWeakness);
            int[] surf1 = Surf(surfaceRoughness, 2 * boxWeakness.Length + 2 * boxWeakness[0].Length);
            if (boxWeakness.Length == 1 && boxWeakness[0].Length == 1) return bMin[0] * surf1.Sum();
            int[] s = Merged(surf1, boxWeakness.Length, boxWeakness[0].Length);

            for (int i = 0; i < s.Length; i++)
                sum += s[s.Length - 1 - i] * bMin[i];

            return sum;
        }

        // The smallest elements(by asc.) that could be distributed along the border of the box.
        static int[] MinArr(string[] box)
        {
            int[] a = new int[box.Length * box[0].Length];
            for (int i = 0; i < a.Length; i++)
                a[i] = box[i / box[0].Length][i % box[0].Length] - '0';

            Array.Sort(a);

            return a;
        }

        // an array of surface damage to each of the elements of box border.
        static int[] Surf(string s, int d)
        {
            int[] res = new int[d];
            for (int i = 0; i < s.Length; i++)
                res[i % d] += s[i] - '0';
            return res;
        }

        // The total damage of box border elements, where the calculations of corner elements
        // are merged for each sequantial rotations
        static int[] Merged(int[] a, int i, int j)
        {
            int l = a.Length;
            int[] res = (i == 1 || j == 1) ? new int[l / 2 - 1] : new int[l - 4];
            if (i != 1 && j != 1)
            {
                int s1 = a[0] + a[l - 1];
                int s2 = a[j - 1] + a[j];
                int s3 = a[i + j - 1] + a[i + j];
                int s4 = a[i + 2 * j - 1] + a[i + 2 * j];
                int ad = j;
                for (int k = j; k <= 2 * i + 2 * j; k += ad)
                {
                    a[k - 1] = int.MaxValue;
                    a[k % l] = int.MaxValue;
                    ad = ad == j ? i : j;
                }

                Array.Sort(a);
                int r = res.Length;
                for (int k = 0; k < r - 4; k++)
                    res[k] = a[k];
                res[r - 4] = s1;
                res[r - 3] = s2;
                res[r - 2] = s3;
                res[r - 1] = s4;
            }
            else
            {
                int sh = (i == 1) ? 0 : 1;
                j = (i == 1) ? j : i;
                int s1 = a[l - 2 + sh] + a[(l - 1 + sh) % l] + a[0 + sh];
                int s2 = a[j - 1 + sh] + a[j + sh] + a[j + 1 + sh];
                for (int k = 0 + sh; k <= j + 1 + sh; k += j + 1)
                    for (int h = k - 2; h <= k; h++)
                        a[(h + l) % l] = int.MaxValue;
                for (int k = 0; k < (l - 6) / 2; k++)
                {
                    res[k] += a[1 + sh + k];
                    res[k] += a[l - 2 - (1 - sh) - k];
                }
                int r = res.Length;
                res[r - 2] = s2;
                res[r - 1] = s1;
            }

            Array.Sort(res);
            return res;
        }
    }
}
