using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You are given n rectangular boxes, the ith box has the length lengthi,
// the width widthi and the height heighti. Your task is to check if it is possible
// to pack all boxes into one so that inside each box there is no more than one another box
// (which, in turn, can contain at most one another box, and so on).
// More formally, your task is to check whether there is such sequence of n different
// numbers pi (1 ≤ pi ≤ n) that for each 1 ≤ i < n the box number pi can be put into the box number pi+1.
// A box can be put into another box if all sides of the first one are less
// than the respective ones of the second one.You can rotate each box as you wish,
// i.e.you can swap its length, width and height if necessary.
// Example:
//          For length = [1, 3, 2], width = [1, 3, 2], and height = [1, 3, 2], the output should be
//          boxesPacking(length, width, height) = true;
//          
//          For length = [1, 1], width = [1, 1], and height = [1, 1], the output should be
//          boxesPacking(length, width, height) = false;
//
//          For length = [3, 1, 2], width = [3, 1, 2], and height = [3, 2, 1], the output should be
//          boxesPacking(length, width, height) = false.

namespace BoxesPacking
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static bool boxesPacking(int[] length, int[] width, int[] height)
        {
            int len = length.Length;
            bool collectable = true;
            for (int i = 0; i < len; i++)
            {
                int[] box = new int[] { length[i], width[i], height[i] };
                int maxB = box.Max();
                int minB = box.Min();
                int midB = box.Sum() - minB - maxB;
                height[i] = maxB;
                width[i] = midB;
                length[i] = minB;
            }

            for (int i = 0; collectable && i < len - 1; i++)
                for (int j = i + 1; collectable && j < len; j++)
                    collectable = CanFit(length, width, height, i, j);

            return collectable;


        }

        static bool CanFit(int[] a, int[] b, int[] c, int i, int j)
        {
            return (a[i] < a[j] && b[i] < b[j] && c[i] < c[j]) || (a[i] > a[j] && b[i] > b[j] && c[i] > c[j]);
        }

    }
}
