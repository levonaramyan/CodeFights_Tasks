using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You have been watching a video for some time. Knowing the total video duration find out what portion of the video
// you have already watched.
// Example:
//          For part = "02:20:00" and total = "07:00:00", the output should be
//          videoPart(part, total) = [1, 3].
//          You have watched 1 / 3 of the whole video.

namespace VideoPart
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[] videoPart(string part, string total)
        {
            bool reducable = true;
            int sec1 = int.Parse(total.Substring(0, 2)) * 3600 + int.Parse(total.Substring(3, 2)) * 60 + int.Parse(total.Substring(6, 2));
            int sec2 = int.Parse(part.Substring(0, 2)) * 3600 + int.Parse(part.Substring(3, 2)) * 60 + int.Parse(part.Substring(6, 2));

            int[] res = new int[] { sec2, sec1 };

            int gcd = GCD(sec2, sec1);
            res[0] /= gcd;
            res[1] /= gcd;
            return res;
        }

        static int GCD(int a, int b)
        {
            while (b > 0)
            {
                int rem = a % b;
                a = b;
                b = rem;
            }
            return a;
        }
    }
}
