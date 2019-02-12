using System;
using System.Collections.Generic;

// While exploring the ruins of a golden lost city, you discovered an ancient manuscript
// containing series of strange symbols. Thanks to your profound knowledge of dead languages,
// you realized that the text was written in one of the dialects of Befunge-93.
// Looks like the prophecy was true: you are the one who can find the answer to the
// Ultimate Question of Life! Of course you brought your futuristic laptop with you,
// so now you just need a function that will run the encrypted message and make you
// the all-knowing human being.
// Befunge-93 is a stack-based programming language, the programs for which are arranged
// in a two-dimensional torus grid.The program execution sequence starts at the top left corner
// and proceeds to the right until the first direction instruction is met
// (which can appear in the very first cell). The torus adjective means that the program
// never leaves the grid: when it encounters a border, it simply goes to the next command
// at the opposite side of the grid.
//
// You need to write a function that will be able to execute the given Befunge-93 program.
// Unfortunately your laptop, futuristic that it is, can't handle more than 105 instructions
// and will probably catch on fire if you try to execute more, so the function should exit
// after 105 commands. The good news is, the prophesy said that the answer to the
// Ultimate Question of Life contains no more than 100 symbols, so the function should return
// the program output once it contains 100 symbols.
// The dialect of Befunge-93 in the manuscript consists of the following commands:
//      direction instructions:
//          >: start moving right
//          <: start moving left
//          v: start moving down
//          ^: start moving up
//          #: bridge; skip next cell
//      conditional instructions:
//          _: pop a value; move right if value = 0, left otherwise
//          |: pop a value; move down if value = 0, up otherwise
//      math operators:
//          +: addition; pop a, pop b, then push a + b
//          -: subtraction; pop a, pop b, then push b - a
//          *: multiplication; pop a, pop b, then push a* b
//          /: integer division; pop a, pop b, then push b / a
//          %: modulo operation; pop a, pop b, then push b % a
//      logical operators:
//          !: logical NOT; pop a value, if the value = 0, push 1, otherwise push 0
//          `: greater than; pop a and b, then push 1 if b > a, otherwise 0
//      stack instructions:
//          :: duplicate value on top of the stack
//          \: swap the top stack value with the second to the top
//          $: pop value from the stack and discard it
//      output instructions:
//          .: pop value and output it as an integer followed by a space
//          ,: pop value and output it as ASCII character
//      digits 0-9: push the encountered number on the stack
//      ": start string mode; push each character's ASCII value all the way up to the next "
//       (whitespace character): empty instruction; does nothing
//      @: end program; the program output should be returned then
//      If the stack is empty and it is necessary to pop a value, no exception is raised;instead, 0 is produced.
//
// Example:
//          For
//          program = [
//              "               v",
//              "v  ,,,,,"Hello"<",
//              ">48*,          v",
//              ""!dlroW",,,,,,v>",
//              "25*,@         > "
//          ]
//          the output should be befunge93(program) = "Hello World!\n".
//          Note, that in the tests tab you will see a \ as an escape symbol before each ".
//          Here is how the program is executed:
//          the program starts executing at the top left corner, doing nothing according to the
//          command until it meets the v command, which makes the instructions direct it downward;
//          the<makes it go left;
//          the " starts the string mode; "Hello" is pushed backwards on the stack;
//          six , symbols produce the "Hello" word, emptying the stack;
//          since the v symbol is encountered, the third line starts executing;
//          4 and 8 are pushed on the stack; the* operator pops them, multiplies and puts
//              the result (4 * 8 = 32) back on the stack;
//          the , operator produces the character with the ASCII value of 32, which is a whitespace character;
//          all the empty (' ') instructions are then executed, until the v command is encountered;
//              then, the fourth line starts to execute;
//          the > command forces instructions to the right to execute; since there is a border to the right,
//              the leftmost instruction in the fourth line is executed next;
//          another string " mode starts, which pushes "World!" backwards on the stack;
//          next, the , commands output the "World!" string;
//          the v command moves command execution to the next line;
//          the > command moves command execution to the very beginning of the fifth line;
//          2 * 5 = 10 is pushed on the stack, and produced as a character \n;
//          finally, @ finishes the program execution.

namespace befunge93
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] test = new string[] {
                "vv    <>v *<",
                "9>:1-:|$>\\:|",
                ">^    >^@.$<"
            };

            Console.WriteLine(befunge93(test));
            Console.ReadKey();
        }

        static string befunge93(string[] program)
        {
            Stack<string> st = new Stack<string>(0);
            int i = 0, j = 0;
            char direction = '>';
            int counter = 0;
            List<string> res = new List<string>(0);

            while(program[i][j] != '@' && counter < 1000000)
            {
                switch (program[i][j])
                {
                    case '>':
                    case '<':
                    case 'v':
                    case '^':
                    case '#':
                        DirInstructions(program, program[i][j], ref direction, ref i, ref j);
                        break;
                    case '_':
                    case '|':
                        CondInstructions(program, program[i][j],st,ref direction,ref i, ref j);
                        break;
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '%':
                    case '`':
                        MathInstructions(program, st,program[i][j],direction,ref i, ref j);
                        break;
                    case '!':
                        LogicInstructions(program, st, direction, ref i, ref j);
                        break;
                    case ':':
                    case '\\':
                    case '$':
                        StackInstructions(program, st,program[i][j],direction,ref i, ref j);
                        break;
                    case '.':
                    case ',':
                        res.Add(OutputInstructions(program, st,program[i][j],direction,ref i, ref j));
                        break;
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        st.Push($"{program[i][j]}");
                        MoveNext(program, direction, ref i, ref j);
                        break;
                    case '\"':
                        StartString(program, st, direction, ref i, ref j);
                        break;
                    case ' ':
                        MoveNext(program,direction, ref i, ref j);
                        break;
                }
                counter++;

            }

            string output = string.Concat(res);

            return (output.Length <= 100 ? output : output.Substring(0,100));
        }

        static void StartString(string[] str, Stack<string> st,char direction, ref int i, ref int j)
        {
            MoveNext(str, direction, ref i, ref j);

            while (str[i][j] != '\"')
            {                
                st.Push(((int)str[i][j]).ToString());
                MoveNext(str,direction, ref i, ref j);
            }

            MoveNext(str,direction, ref i, ref j);
        }

        static string OutputInstructions(string[] program,Stack<string> st, char instr, char direction, ref int i, ref int j)
        {
            string a = st.Pop();
            MoveNext(program,direction, ref i, ref j);
            return instr == '.' ? $"{a} " : (int.TryParse(a,out int aNew)? $"{(char)aNew}" : a );           
        }

        static void StackInstructions(string[] program, Stack<string> st, char instr, char direction, ref int i, ref int j)
        {
            string a = SafePop(st);

            switch (instr)
            {
                case ':':
                    st.Push(a);
                    st.Push(a);
                    break;
                case '\\':
                    string b = SafePop(st);
                    st.Push(a);
                    st.Push(b);
                    break;
                default: break;
            }

            MoveNext(program,direction, ref i, ref j);
        }

        static void LogicInstructions(string[] program, Stack<string> st, char direction, ref int i, ref int j)
        {
            string a = SafePop(st);
            st.Push(a == "0" ? "1" : "0");
            MoveNext(program, direction, ref i, ref j);
        }

        static void MathInstructions(string[] program, Stack<string> st,char instr, char direction, ref int i, ref int j)
        {
            int a = int.Parse($"{SafePop(st)}");
            int b = int.Parse($"{SafePop(st)}");

            switch (instr)
            {
                case '+':
                    st.Push((b + a).ToString());
                    break;
                case '-':
                    st.Push((b - a).ToString());
                    break;
                case '*':
                    st.Push((b * a).ToString());
                    break;
                case '/':
                    st.Push((b / a).ToString());
                    break;
                case '%':
                    st.Push((b % a).ToString());
                    break;
                default:
                    st.Push(b > a ? "1" : "0");
                    break;
            }

            MoveNext(program, direction, ref i, ref j);
        }

        static void CondInstructions(string[] program, char instr, Stack<string> st, ref char direction, ref int i, ref int j)
        {
            string a = st.Pop();
            direction = instr == '_' ? (a == "0" ? '>' : '<') : (a == "0" ? 'v' : '^');
            MoveNext(program, direction, ref i, ref j);
        }

        static void DirInstructions(string[] program, char instruction,ref char direction, ref int i, ref int j)
        {
            if (instruction == '#') MoveNext(program,direction, ref i, ref j);
            else direction = instruction;
            MoveNext(program,direction, ref i, ref j);
        }

        static void MoveNext(string[] pr, char direction, ref int i, ref int j)
        {
            int iMax = pr.Length;
            int jMax = pr[0].Length;

            switch (direction)
            {
                case '>':
                    j = ++j % jMax;
                    break;

                case '<':
                    j = (jMax + --j) % jMax;
                    break;

                case 'v':
                    i = ++i % iMax;
                    break;

                default:
                    i = (iMax + --i) % iMax;
                    break;
            }

            //Console.WriteLine($"{i} {j}");
        }

        static string SafePop(Stack<string> st)
        {
            try
            {
                return st.Pop();
            }
            catch
            {
                return "0";
            }
        }
    }
}
