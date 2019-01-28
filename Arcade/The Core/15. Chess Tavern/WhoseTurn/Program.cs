using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoseTurn
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static bool whoseTurn(string p)
        {
            string w1 = p.Substring(0, 2);
            string w2 = p.Substring(3, 2);
            string b1 = p.Substring(6, 2);
            string b2 = p.Substring(9);
            return (IsInWhite(w1) == IsInWhite(w2)) == (IsInWhite(b1) == IsInWhite(b2));

        }

        static bool IsInWhite(string s)
        {
            return ((int)s[0] - (int)'a' + 1) % 2 == int.Parse($"{s[1]}") % 2;
        }

    }
}
