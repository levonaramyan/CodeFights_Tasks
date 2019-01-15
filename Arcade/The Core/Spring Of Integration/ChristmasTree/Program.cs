using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasTree
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string[] christmasTree(int levelNum, int levelHeight)
        {
            int len = 3 + levelNum * levelHeight + levelNum;
            string[] tree = new string[3 + levelNum * levelHeight + levelNum];
            tree[0] = new string(' ', levelHeight + levelNum) + "*";
            tree[1] = tree[0];
            tree[2] = new String(' ', levelHeight + levelNum - 1) + "***";
            int j = 0;
            for (int i = 0; i < levelNum; i++)
                for (j = 0; j < levelHeight; j++)
                    tree[3 + i * levelHeight + j] = new string(' ', levelNum - 1 - i + levelHeight - 1 - j) + new string('*', 5 + 2 * (j + i));
            string foot = new string('*', levelHeight + 1 - levelHeight % 2);
            foot = new string(' ', (tree[2 + levelHeight * levelNum].Length - foot.Length) / 2) + foot;
            for (int i = 0; i < levelNum; i++)
                tree[3 + levelHeight * levelNum + i] = foot;

            return tree;

        }
    }
}
