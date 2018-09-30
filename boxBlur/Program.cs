using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Last night you partied a little too hard. Now there's a black and white photo of you
// that's about to go viral! You can't let this ruin your reputation, so you want to apply
// the box blur algorithm to the photo to hide its content.

// The pixels in the input image are represented as integers.The algorithm distorts
// the input image in the following way: Every pixel x in the output image has a value
// equal to the average value of the pixel values from the 3 × 3 square that has its center
// at x, including x itself.All the pixels on the border of x are then removed.

// PROBLEM: Return the blurred image as an integer, with the fractions rounded down.

namespace boxBlur
{
    class Program
    {
        static void Main(string[] args)
        {
            // initializing test
            int[][] test = new int[3][];
            test[0] = new int[] { 1, 2, 3 };
            test[1] = new int[] { 4, 5, 6 };
            test[2] = new int[] { 7, 8, 9 };

            // applying method
            int[][] blurred = boxBlur(test);

            // printing the result
            foreach (int[] i in blurred)
            {
                foreach (int j in i)
                    Console.Write($"{j} ");
                Console.WriteLine();
            }
            //Console.WriteLine(test.GetLength(0));
            Console.ReadKey();
        }

        // The method returns the blurred array
        static int[][] boxBlur(int[][] image)
        {
            // Initializing variables, and the blurred image
            int x = image.Length - 2;
            int y = image[0].Length - 2;
            int[][] blurred = new int[x][];
            int boxSum = 0;
            int boxMean = 0;


            // bluring and returning on blurred array
            for (int i = 0; i < x; i++)
            {
                blurred[i] = new int[y];
                for (int j = 0; j < y; j++)
                {
                    for (int k = i ; k <= i + 2; k++)
                        for (int h = j ; h <= j + 2; h++)
                            boxSum += image[k][h];
                    boxMean = boxSum / 9;
                    blurred[i][j] = boxMean;
                    boxSum = 0;
                }
            }

            // returning the resulting blured[][] image
            return blurred;
        }
    }
}
