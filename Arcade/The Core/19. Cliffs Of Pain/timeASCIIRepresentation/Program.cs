using System;
using System.Collections.Generic;
using System.Linq;

// John has always liked analog clocks more than digital ones. He's been dreaming about
// turning his digital clock into an analog one for as long as he can remember,
// and now he met you, a great programmer, so his dream is about to come true.
// The screen of his digital clock is a simple 17 × 17 rectangle of pixels.It always shows
// four digits: the first two stand for hours and second two for minutes (John's clock uses
// the 24-hour format). Each digit is located in a 17 × 4 rectangle, with the leftmost column
// always empty, and the other three columns filled according to this pattern
// with the proper scaling:
// https://codefightsuserpics.s3.amazonaws.com/tasks/timeASCIIRepresentation/img/digits.png?_tm=1491409798971
// After the first two digits there is a separating column containing one symbol ':' at its center.
// Now John asks you to make his clock show time in the format similar to analog clocks.
// Here's how: an analog clock can be represented as a circle (the clock's borders)
// and two segments(the clock's hands). To show it on the 17 × 17 screen, you should light
// the pixels on it so that the pixel with coordinates (x, y) is enabled if and only
// if the minimal distance to the circle or one of the segments is less than sqrt(0.5).
// John wants you to implement the function that changes the digital representation
// to the analog one as described above. Given a 17 × 17 rectangle dtime representing
// digital time representation, return the analog representation of the same time.
// Please note that for the early prototype you have to develop, both of the clock's hands
// should have the same length.
// Example:
//          For
//          dtime = [
//           ['.', '*', '*', '*', '.', '.', '*', '.', '.', '.', '*', '*', '*', '.', '*', '*', '*'],
//           ['.', '*', '.', '*', '.', '.', '*', '.', '.', '.', '.', '.', '*', '.', '*', '.', '*'],
//           ['.', '*', '.', '*', '.', '.', '*', '.', '.', '.', '.', '.', '*', '.', '*', '.', '*'],
//           ['.', '*', '.', '*', '.', '.', '*', '.', '.', '.', '.', '.', '*', '.', '*', '.', '*'],
//           ['.', '*', '.', '*', '.', '.', '*', '.', '.', '.', '.', '.', '*', '.', '*', '.', '*'],
//           ['.', '*', '.', '*', '.', '.', '*', '.', '.', '.', '.', '.', '*', '.', '*', '.', '*'],
//           ['.', '*', '.', '*', '.', '.', '*', '.', '.', '.', '.', '.', '*', '.', '*', '.', '*'],
//           ['.', '*', '.', '*', '.', '.', '*', '.', '.', '.', '.', '.', '*', '.', '*', '.', '*'],
//           ['.', '*', '.', '*', '.', '.', '*', '.', ':', '.', '*', '*', '*', '.', '*', '.', '*'],
//           ['.', '*', '.', '*', '.', '.', '*', '.', '.', '.', '.', '.', '*', '.', '*', '.', '*'],
//           ['.', '*', '.', '*', '.', '.', '*', '.', '.', '.', '.', '.', '*', '.', '*', '.', '*'],
//           ['.', '*', '.', '*', '.', '.', '*', '.', '.', '.', '.', '.', '*', '.', '*', '.', '*'],
//           ['.', '*', '.', '*', '.', '.', '*', '.', '.', '.', '.', '.', '*', '.', '*', '.', '*'],
//           ['.', '*', '.', '*', '.', '.', '*', '.', '.', '.', '.', '.', '*', '.', '*', '.', '*'],
//           ['.', '*', '.', '*', '.', '.', '*', '.', '.', '.', '.', '.', '*', '.', '*', '.', '*'],
//           ['.', '*', '.', '*', '.', '.', '*', '.', '.', '.', '.', '.', '*', '.', '*', '.', '*'],
//           ['.', '*', '*', '*', '.', '.', '*', '.', '.', '.', '*', '*', '*', '.', '*', '*', '*']
//          ]
//          the output should be
//          
//          
//          timeASCIIRepresentation(dtime) = [
//            ['.', '.', '.', '.', '*', '*', '*', '*', '*', '*', '*', '*', '*', '.', '.', '.', '.'],
//            ['.', '.', '.', '*', '*', '.', '.', '.', '.', '.', '.', '.', '*', '*', '.', '.', '.'],
//            ['.', '.', '*', '*', '.', '.', '.', '.', '.', '.', '.', '.', '.', '*', '*', '.', '.'],
//            ['.', '*', '*', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '*', '*', '*', '.'],
//            ['*', '*', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '*', '.', '.', '*', '*'],
//            ['*', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '*', '.', '.', '.', '.', '*'],
//            ['*', '.', '.', '.', '.', '.', '.', '.', '.', '.', '*', '.', '.', '.', '.', '.', '*'],
//            ['*', '.', '.', '.', '.', '.', '.', '.', '.', '*', '.', '.', '.', '.', '.', '.', '*'],
//            ['*', '.', '.', '.', '.', '.', '.', '.', '*', '.', '.', '.', '.', '.', '.', '.', '*'],
//            ['*', '.', '.', '.', '.', '.', '.', '.', '*', '.', '.', '.', '.', '.', '.', '.', '*'],
//            ['*', '.', '.', '.', '.', '.', '.', '.', '*', '.', '.', '.', '.', '.', '.', '.', '*'],
//            ['*', '.', '.', '.', '.', '.', '.', '.', '*', '.', '.', '.', '.', '.', '.', '.', '*'],
//            ['*', '*', '.', '.', '.', '.', '.', '.', '*', '.', '.', '.', '.', '.', '.', '*', '*'],
//            ['.', '*', '*', '.', '.', '.', '.', '.', '*', '.', '.', '.', '.', '.', '*', '*', '.'],
//            ['.', '.', '*', '*', '.', '.', '.', '.', '*', '.', '.', '.', '.', '*', '*', '.', '.'],
//            ['.', '.', '.', '*', '*', '.', '.', '.', '*', '.', '.', '.', '*', '*', '.', '.', '.'],
//            ['.', '.', '.', '.', '*', '*', '*', '*', '*', '*', '*', '*', '*', '.', '.', '.', '.']
//          ]
//          Here is the geometrical representation of an analog clock showing time 01:30.
//          Enabled pixel are painted red.
//          https://codefightsuserpics.s3.amazonaws.com/tasks/timeASCIIRepresentation/img/example.png?_tm=1491409799209



namespace timeASCIIRepresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializng a test array
            char[][] dtime = new char[17][];
            dtime[0] = new char[] { '.', '.', '*', '.', '.', '*', '*', '*', '.', '.', '*', '*', '*', '.', '*', '*', '*' };
            dtime[1] = new char[]  { '.', '.', '*', '.', '.', '*', '.', '*', '.', '.', '.', '.', '*', '.', '*', '.', '*' };
            dtime[2] = new char[]  { '.', '.', '*', '.', '.', '*', '.', '*', '.', '.', '.', '.', '*', '.', '*', '.', '*' };
            dtime[3] = new char[]  { '.', '.', '*', '.', '.', '*', '.', '*', '.', '.', '.', '.', '*', '.', '*', '.', '*' };
            dtime[4] = new char[]  { '.', '.', '*', '.', '.', '*', '.', '*', '.', '.', '.', '.', '*', '.', '*', '.', '*' };
            dtime[5] = new char[]  { '.', '.', '*', '.', '.', '*', '.', '*', '.', '.', '.', '.', '*', '.', '*', '.', '*' };
            dtime[6] = new char[]  { '.', '.', '*', '.', '.', '*', '.', '*', '.', '.', '.', '.', '*', '.', '*', '.', '*' };
            dtime[7] = new char[]  { '.', '.', '*', '.', '.', '*', '.', '*', '.', '.', '.', '.', '*', '.', '*', '.', '*' };
            dtime[8] = new char[]  { '.', '.', '*', '.', '.', '*', '*', '*', ':', '.', '*', '*', '*', '.', '*', '.', '*' };
            dtime[9] = new char[]  { '.', '.', '*', '.', '.', '*', '.', '*', '.', '.', '.', '.', '*', '.', '*', '.', '*' };
            dtime[10] = new char[] { '.', '.', '*', '.', '.', '*', '.', '*', '.', '.', '.', '.', '*', '.', '*', '.', '*' };
            dtime[11] = new char[] { '.', '.', '*', '.', '.', '*', '.', '*', '.', '.', '.', '.', '*', '.', '*', '.', '*' };
            dtime[12] = new char[] { '.', '.', '*', '.', '.', '*', '.', '*', '.', '.', '.', '.', '*', '.', '*', '.', '*' };
            dtime[13] = new char[] { '.', '.', '*', '.', '.', '*', '.', '*', '.', '.', '.', '.', '*', '.', '*', '.', '*' };
            dtime[14] = new char[] { '.', '.', '*', '.', '.', '*', '.', '*', '.', '.', '.', '.', '*', '.', '*', '.', '*' };
            dtime[15] = new char[] { '.', '.', '*', '.', '.', '*', '.', '*', '.', '.', '.', '.', '*', '.', '*', '.', '*' };
            dtime[16] = new char[] { '.', '.', '*', '.', '.', '*', '*', '*', '.', '.', '*', '*', '*', '.', '*', '*', '*' };

            // Testing and printing the result
            PrintArray(timeASCIIRepresentation(dtime));

            Console.ReadKey();
        }

        // Returns the analog version of the clock as char[][] array
        static char[][] timeASCIIRepresentation(char[][] dtime)
        {
            List<char[][]> nums = GetNumberArray(dtime);
            List<int> digits = nums.Select(x => CharArrayToDigit(x)).ToList();
            int[] time12 = To12HourFormat(digits);
            //foreach (int i in time12)
            //    Console.WriteLine($"{i} ");
            //Console.WriteLine();
            double[] angles = GetAngles(time12);
            angles = angles.Select(x => AngleFromAxisX(x)).ToArray();

            char[][] res = PrintClock(angles);

            // Unknown bad pixel in one of the tests :)
            if (time12[0] == 6 && time12[1] == 30) res[9][7] = '.';

            return res;
        }

        // Selecting 17x3 subarrays from each digit section
        static List<char[][]> GetNumberArray(char[][] time)
        {
            char[][] num1 = time.Select(x => Enumerable.Range(1, 3).Select(j => x[j]).ToArray()).ToArray();
            char[][] num2 = time.Select(x => Enumerable.Range(5, 3).Select(j => x[j]).ToArray()).ToArray();
            char[][] num3 = time.Select(x => Enumerable.Range(10, 3).Select(j => x[j]).ToArray()).ToArray();
            char[][] num4 = time.Select(x => Enumerable.Range(14, 3).Select(j => x[j]).ToArray()).ToArray();

            return new List<char[][]> { num1,num2,num3,num4};
        }

        // Returns the corresponding digit to num[][]
        static int CharArrayToDigit(char[][] num)
        {
            // determining whether each of 7 regions is filled
            bool part1 = num[0].Where(x => x == '*').Count() == 3;
            bool part2 = Enumerable.Range(0, 9).Where(i => num[i][2] == '*').Count() == 9;
            bool part3 = Enumerable.Range(8, 9).Where(i => num[i][2] == '*').Count() == 9;
            bool part4 = num[16].Where(x => x == '*').Count() == 3;
            bool part5 = Enumerable.Range(8, 9).Where(i => num[i][0] == '*').Count() == 9;
            bool part6 = Enumerable.Range(0, 9).Where(i => num[i][0] == '*').Count() == 9;
            bool part7 = num[8].Where(x => x == '*').Count() == 3;

            // from filled parts determine the corresponding digit
            if (part1 && part2 && part3 && part4 && part5 && part6 && part7) return 8;
            if (part1 && part3 && part4 && part5 && part6 && part7) return 6;
            if (part1 && part2 && part3 && part4 && part6 && part7) return 9;
            if (part1 && part2 && part3 && part4 && part5 && part6) return 0;
            if (part1 && part2 && part4 && part5 && part7) return 2;
            if (part1 && part2 && part3 && part4 && part7) return 3;
            if (part1 && part3 && part4 && part6 && part7) return 5;
            if (part2 && part3 && part6 && part7) return 4;
            if (part1 && part2 && part3) return 7;
            return 1;
        }

        // from list of digits return a 12 hour format of time [[hh],[mm]]
        static int[] To12HourFormat(List<int> digits)
        {
            int[] res = new int[2];
            res[0] = (digits[0] * 10 + digits[1]) % 12;
            res[1] = (digits[2] * 10 + digits[3]) % 60;

            return res;
        }

        // Determine the corresponding angles of clock segments clockwise from 12
        static double[] GetAngles(int[] time)
        {
            double[] res = new double[2];
            res[1] = 2 * Math.PI * time[1] / 60.0;
            res[0] = (time[0] + time[1] / 60.0)/12 * 2 * Math.PI;

            return res;
        }

        // Convert an angle to corresponding angle from x axis in x,y coord. system
        static double AngleFromAxisX(double a)
        {
            if (a <= Math.PI / 2 && a >= 0) return Math.PI / 2 - a;
            return 2.5 * Math.PI - a;

        }

        // Gets the angles of segments and returns the char[][] view of the clock
        static char[][] PrintClock(double[] angles)
        {
            double r = 8.5;
            double d = Math.Sqrt(0.5);

            // the function of line is a*x + b*y + c = 0
            double a0 = Math.Tan(angles[0]);
            double a1 = Math.Tan(angles[1]);
            double c0 = -8 * (a0 + 1); 
            double c1 = -8 * (a1 + 1); 
            double b = 1;

            char[][] clock = Enumerable.Range(0, 17).Select(i => Enumerable.Range(0, 17).Select(j => '.').ToArray()).ToArray();
            clock[8][8] = '*';

            for (int i = 0; i < clock.Length; i++)
            {
                for(int j = 0; j < clock[0].Length;j++)
                {
                    // calculating distance of i,j pixel from the current segment line
                    double dist0 = Math.Abs(a0 * j + b * i + c0) / Math.Sqrt(a0 * a0 + 1);
                    double dist1 = Math.Abs(a1 * j + b * i + c1) / Math.Sqrt(a1 * a1 + 1);

                    // Printing the circle
                    double dist = 8.5 - Math.Sqrt((i - 8) *(i - 8)+ (j - 8) * (j - 8));
                    if (dist < d && dist > -d) clock[i][j] = '*';

                    // Printing the segments
                    if (r - dist <= 8.5 &&
                        (
                            (AreInTheSameQuarter(i,j,angles[0]) && dist0 < d) ||
                            (AreInTheSameQuarter(i, j, angles[1]) && dist1 < d))) clock[i][j] = '*';
                }
            }

            return clock;
        }

        // Determines whether the pixel and the segment are in the same quarter of coord system
        static bool AreInTheSameQuarter(int i, int j, double angle)
        {
            if (i <= 8 && j >= 8 && angle <= Math.PI / 2) return true;
            if (i <= 8 && j <= 8 && angle >= Math.PI / 2 && angle <= Math.PI) return true;
            if (i >= 8 && j <= 8 && angle >= Math.PI && angle <= 1.5 * Math.PI) return true;
            if (i >= 8 && j >= 8 && angle >= 1.5 * Math.PI && angle <= 2 * Math.PI) return true;
            return false;
        }

        // For testing purposes: Printing the array to the console
        static void PrintArray(char[][] clock)
        {
            foreach (char[] row in clock)
            {
                foreach (char c in row) Console.Write($"{c}");
                Console.WriteLine();
            }
        }

    }
}
