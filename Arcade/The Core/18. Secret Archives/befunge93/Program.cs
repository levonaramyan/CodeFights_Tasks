using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
