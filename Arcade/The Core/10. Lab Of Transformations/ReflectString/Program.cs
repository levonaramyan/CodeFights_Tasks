using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectString
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string reflectString(string inputString)
        {
            string reflected = "";
            foreach (char i in inputString)
            {
                reflected += (char)('z' + 'a' - i);
            }
            return reflected;

        }
    }
}
