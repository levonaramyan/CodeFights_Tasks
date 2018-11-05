using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrosswordFormation
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static int crosswordFormation(string[] words)
        {
            int t = 0;
            for (int i = 0; i < words.Length; i++)
                for (int j = 0; j < words.Length; j++)
                    for (int k = 0; k < words.Length; k++)
                        for (int l = 0; l < words.Length; l++)
                            if (i != j && i != k && i != l &&
                                j != k && j != l && k != l)
                                t += CheckingCrossword(words[i], words[j], words[k], words[l]);
            return t;

        }

        static int CheckingCrossword(string a, string b, string c, string d)
        {
            int count = 0;
            for (int a1 = 0; a1 < a.Length; a1++)
                for (int a2 = a1 + 2; a2 < a.Length; a2++)
                    for (int b1 = 0; b1 < b.Length; b1++)
                        for (int b2 = b1 + 2; b2 < b.Length; b2++)
                            for (int c1 = 0; c1 < c.Length; c1++)
                                for (int d1 = 0; d1 < d.Length; d1++)
                                {
                                    int c2 = c1 + (a2 - a1);
                                    int d2 = d1 + (b2 - b1);
                                    if (c2 < c.Length && d2 < d.Length)
                                    {
                                        if (a[a1] == b[b1] && a[a2] == d[d1]
                                           && c[c1] == b[b2] && c[c2] == d[d2]) count++;
                                    }
                                }
            return count;
        }
    }
}
