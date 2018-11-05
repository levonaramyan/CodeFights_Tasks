using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleRotation
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static int rectangleRotation(int a, int b)
        {
            double dist = Math.Sqrt(2) / 2;
            int count = 0;
            int aNew = (int)(a / (2 * dist));
            int bNew = (int)(b / (2 * dist));
            for (int i = -aNew; i <= aNew; i++)
            {
                for (int j = -bNew; j <= bNew; j++)
                {
                    if (Math.Abs(i) % 2 == Math.Abs(j) % 2) count++;
                }
            }

            return count;
        }
    }
}
