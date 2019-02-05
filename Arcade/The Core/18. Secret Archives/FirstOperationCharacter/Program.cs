using System;
using System.Linq;

// Given a string which represents a valid arithmetic expression, find the index of the character
// in the given expression corresponding to the arithmetic operation which needs to be computed first.
// Note that several operations of the same type with equal priority are computed from left to right.
// See the explanation of the third example for more details about the operations priority in this problem.
// Example:
//          For expr = "(2 + 2) * 2", the output should be
//          firstOperationCharacter(expr) = 3.
//          There are two operations in the expression: + and*. The result of + should be computed first,
//          since it is enclosed in parentheses.Thus, the output is the index of the '+' sign, which is 3.
//
//          For expr = "2 + 2 * 2", the output should be
//          firstOperationCharacter(expr) = 6.
//          There are two operations in the given expression: + and*. Since there are no parentheses,
//          * should be computed first as it has higher priority. The answer is the position of '*',
//          which is 6.
//
//          For expr = "((2 + 2) * 2) * 3 + (2 + (2 * 2))", the output should be
//          firstOperationCharacter(expr) = 28.
//          There are two operations which are enclosed in two parentheses: + at the position 4,
//          and* at the position 28. Since* has higher priority than +, the answer is 28.

namespace FirstOperationCharacter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(firstOperationCharacter("2 + 3 * 45 * 56 + 198 + 10938 * 102938 + 5"));
            Console.ReadKey();
        }

        // Returns the index of the highest priority operator
        static int firstOperationCharacter(string expr)
        {
            int len = expr.Length;
            int[] significance = new int[len];
            int[] oper = new int[len];
            int[] operSignif = new int[len];

            // significance[i]: determining the priority level of each index, with respect to brackets
            // oper[i]: 0 if not an operator, 1 if it is '+','-', and 2 if it is '*','/'
            // operSignif[i]: significance level of the position of operators, with respect to brackets
            //                for non-operator indexes it is 0
            for (int i = 0; i < len; i++)
            {
                significance[i] = (i > 0 ? significance[i - 1] : 0) + ((expr[i] == '(') ? 1 : (expr[i] == ')') ? -1 : 0);
                oper[i] = (expr[i] == '-' || expr[i] == '+') ? 1 : ((expr[i] == '*' || expr[i] == '/')? 2 : 0);
                operSignif[i] = (oper[i] > 0 ? 1 : 0) * significance[i];
            }

            int maxSignif = operSignif.Max(); // the max priority according to brackets

            // filtering out only the operator indexes with maxSignif
            // adding also the priority levels (1 or 2) between different types of operators
            for (int i = 0; i < len; i++)
                operSignif[i] = (operSignif[i] == maxSignif) ? operSignif[i] + oper[i] : 0;

            maxSignif = operSignif.Max(); // determining the max priority operators

            return Array.IndexOf(operSignif, maxSignif); // returning the first index with maxSignif
        }
    }
}
