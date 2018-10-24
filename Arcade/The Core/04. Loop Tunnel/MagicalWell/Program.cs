using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You are standing at a magical well. It has two positive integers written on it: a and b.
// Each time you cast a magic marble into the well, it gives you a * b dollars and then
// both a and b increase by 1. You have n magic marbles. How much money will you make?

// Example:
//          For a = 1, b = 2, and n = 2, the output should be
//          magicalWell(a, b, n) = 8.

//          You will cast your first marble and get $2, after which the numbers will become 2 and 3.
//          When you cast your second marble, the well will give you $6. Overall, you'll make $8. So, the output is 8.

namespace MagicalWell
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(magicalWell(1, 2, 2));
            Console.ReadKey();
        }

        // Returns an amount of money you could make with n magic marbles.
        static int magicalWell(int a, int b, int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += a * b;
                a++;
                b++;
            }

            return sum;

        }
    }
}
