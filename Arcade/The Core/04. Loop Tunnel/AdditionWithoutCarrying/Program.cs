using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// A little boy is studying arithmetics. He has just learned how to add two integers, written one below another,
// column by column. But he always forgets about the important part - carrying.

// PROBLEM: Given two integers, find the result which the little boy will get.

// Note: the boy used this site as the source of knowledge, feel free to check it out too if you are not familiar
// with column addition.

// Example
//          For param1 = 456 and param2 = 1734, the output should be
//          additionWithoutCarrying(param1, param2) = 1180.
//
//             456
//            1734
//          + ____
//            1180
//          The little boy goes from right to left:

//          6 + 4 = 10 but the little boy forgets about 1 and just writes down 0 in the last column
//          5 + 3 = 8
//          4 + 7 = 11 but the little boy forgets about the leading 1 and just writes down 1 under 4 and 7.
//          There is no digit in the first number corresponding to the leading digit of the second one,
//          so the little boy imagines that 0 is written before 456. Thus, he gets 0 + 1 = 1.

namespace AdditionWithoutCarrying
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(additionWithoutCarrying(456,1734));
            Console.ReadKey();
        }

        // Returns the result of addition, without carrying 1-s 
        static int additionWithoutCarrying(int param1, int param2)
        {
            string sum = "";
            while (param1 != 0 || param2 != 0)
            {
                sum = $"{(param1 % 10 + param2 % 10) % 10}{sum}";
                param1 /= 10;
                param2 /= 10;
            }

            return sum.Length == 0 ? 0 : Convert.ToInt32(sum);
        }
    }
}
