using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You're looking for the perfect pumpkin to carve into a bold and beautiful jack-o-lantern.
// You've already created a design for how you'd like to carve it, so now it's just a matter of finding a pumpkin that fits!
// The size of the pumpkin isn't very important; it's mostly a matter of getting the right proportions.
// You'd like to pick a pumpkin that has the same aspect ratio as the minimum bounding box of your design.
// If you can't find one that's exactly right, pick the one with the closest aspect ratio.
// You're open to the idea of displaying the pumpkin sideways, so the dimensions can be switched.
// To keep it simple, we'll represent all ratios with the smaller dimension as the numerator (ie: a fraction between 0 and 1).
// Choose the pumpkin whose ratio of dimensions has the smallest absolute difference with the ratio
// of your design's dimensions (represented as fractions between 0 and 1).
// If there's a tie, choose the bigger pumpkin (width * height).
// If there's still a tie, choose the one that appears earlier in the array.
// Your design was drawn on a sheet of A4 paper, then scanned at a very low resolution
// (one pixel per square centimetre), so the resulting image is a 21 x 30 matrix, represented by design,
// an array of strings.Your choices of pumpkins are represented by an array of their dimensions, pumpkinDimensions,
// where each element is of the form[width, height].

// PROBLEM: Given this information, your task is to return the index of the most suitable pumpkin.

// Example: For
//              design = ["..............................",
//                       "..............................",
//                       ".........#....................",
//                       "........##............#.......",
//                       ".......###...........###......",
//                       ".......###..........####......",
//                       "......###...........###.......",
//                       ".....######........######.....",
//                       ".....#######.......#######....",
//                       "..............................",
//                       "...............#..............",
//                       "..............###.............",
//                       ".....#.......#####............",
//                       ".....#....................#...",
//                       ".....##.#................##...",
//                       "......####............#..#....",
//                       "......####..##..###..#####....",
//                       "........#################.....",
//                       ".........###############......",
//                       "...........#..##...##.........",
//                       ".............................."]
//              and pumpkinDimensions = [[14, 22], [9,16], [11,7], [33,23], [42,25]], the output should be
//              bestPumpkin(design, pumpkinDimensions) = 3.
//              The bounding box is 22 by 18 pixels, so we represent it using the fraction 18 / 22, or 9 / 11.
//              Pumpkin 0 has a ratio of 14 / 22, or 7 / 11, so the difference is |9 / 11 - 7 / 11| = 2 / 11.
//              Pumpkin 1 has a ratio of 9 / 16, so the difference is |9 / 11 - 9 / 16| = 45 / 176 (not as close as pumpkin 0).
//              Pumpkin 2 has a ratio of 7 / 11, which gives the same difference as pumpkin 0 (2 / 11),
//              but since this one's smaller, pumpkin 0 is still a better choice.
//              Pumpkin 3 has a ratio of 23 / 33, so the difference is |9 / 11 - 23 / 33| = 4 / 33.
//              Since that's closer than pumpkin 0, this pumpkin is now the best choice.
//              Pumpkin 4 has a ratio of 25 / 42, so the difference is |9 / 11 - 25 / 42| = 103 / 462 (not as close as pumpkin 3).
//              So 3 is the best choice.

namespace BestPumpkin
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] design = new string[] { "..............................",
                                             "..............................",
                                             ".........#...#................",
                                             "........##............#.......",
                                             ".......###...........###......",
                                             ".......###..........####......",
                                             "......###...........###.......",
                                             ".....######........######.....",
                                             ".....#######.......#######....",
                                             "..............................",
                                             "...............#..............",
                                             "..............###.............",
                                             ".....#.......#####............",
                                             ".....#....................#...",
                                             ".....##.#................##...",
                                             "......####............#..#....",
                                             "......####..##..###..#####....",
                                             "........#################.....",
                                             ".........###############......",
                                             "...........#..##...##.........",
                                             ".............................."};

            int[][] dim = new int[5][];
            dim[0] = new int[] { 14, 22 };
            dim[1] = new int[] { 9, 16 };
            dim[2] = new int[] { 11, 7 };
            dim[3] = new int[] { 33, 23 };
            dim[4] = new int[] { 42, 25 };

            Console.WriteLine(bestPumpkin(design,dim));
            Console.ReadKey();

        
        }

        // Returns the number of assymetric pairs
        static int bestPumpkin(string[] design, int[][] pumpkinDimensions)
        {
            int[] box = GetDimensions(design);
            double ratio = box[0] / (1.0 * box[1]);
            int index = 0;
            double minDiff = 2;
            double size = 0;

            // comparing the ratios of dimensions
            for (int i = 0; i < pumpkinDimensions.Length; i++)
            {
                int[] a = pumpkinDimensions[i];
                Array.Sort(a);
                double absDiff = Math.Abs(ratio - a[0] / (1.0 * a[1]));
                if (absDiff < minDiff || (minDiff == absDiff && a[0] * a[1] > size))
                {
                    minDiff = absDiff;
                    index = i;
                    size = a[0] * a[1];
                }
            }

            return index;

        }

        // Returns the dimensions of the mask in design
        static int[] GetDimensions(string[] s)
        {
            int rLen = s.Length;
            int cLen = s[0].Length;
            int[] dim = new int[2];
            bool lowerFound = false;
            bool upperFound = false;
            int left = cLen - 1;
            int right = 0;

            // getting the indexes of the left-most, rightmost, top and bottom asterisks
            for (int i = 0; i < rLen; i++)
            {
                int c1 = s[i].IndexOf('#');
                int c2 = s[i].LastIndexOf('#');
                left = (c1 >= 0 && c1 < left) ? s[i].IndexOf('#') : left;
                right = c2 > right ? c2 : right;
                if (!upperFound && s[i].Contains('#'))
                {
                    dim[1] -= i;
                    upperFound = true;
                }
                if (!lowerFound && s[rLen - 1 - i].Contains('#'))
                {
                    dim[1] += rLen - i;
                    lowerFound = true;
                }
            }

            dim[0] = right - left + 1;
            Array.Sort(dim);
            return dim;
        }
    }
}
