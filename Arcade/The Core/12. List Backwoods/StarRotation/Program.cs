using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarRotation
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[][] starRotation(int[][] matrix, int width, int[] center, int t)
        {
            int[][] star = new int[width][];

            for (int i = 0; i < width; i++)
                star[i] = new int[width];

            for (int i = center[0] - (width - 1) / 2; i <= center[0] + (width - 1) / 2; i++)
                for (int j = center[1] - (width - 1) / 2; j <= center[1] + (width - 1) / 2; j++)
                    star[i - (center[0] - (width - 1) / 2)][j - (center[1] - (width - 1) / 2)] = matrix[i][j];

            star = RotStar(star, t);

            for (int i = center[0] - (width - 1) / 2; i <= center[0] + (width - 1) / 2; i++)
                for (int j = center[1] - (width - 1) / 2; j <= center[1] + (width - 1) / 2; j++)
                    matrix[i][j] = star[i - (center[0] - (width - 1) / 2)][j - (center[1] - (width - 1) / 2)];


            return matrix;
        }

        static int[][] RotStar(int[][] s, int t)
        {
            int l = s.Length;
            int r = (l - 1) / 2;
            int[][] diags = new int[8][];

            for (int i = 0; i < 8; i++)
                diags[i] = new int[r];

            for (int i = 0; i < r; i++)
            {
                diags[t % 8][i] = s[i][i];
                diags[(1 + t) % 8][i] = s[i][r];
                diags[(2 + t) % 8][i] = s[i][l - 1 - i];
                diags[(3 + t) % 8][i] = s[r][l - 1 - i];
                diags[(4 + t) % 8][i] = s[l - 1 - i][l - 1 - i];
                diags[(5 + t) % 8][i] = s[l - 1 - i][r];
                diags[(6 + t) % 8][i] = s[l - 1 - i][i];
                diags[(7 + t) % 8][i] = s[r][i];
            }

            for (int i = 0; i < r; i++)
            {
                s[i][i] = diags[0][i];
                s[i][r] = diags[1][i];
                s[i][l - 1 - i] = diags[2][i];
                s[r][l - 1 - i] = diags[3][i];
                s[l - 1 - i][l - 1 - i] = diags[4][i];
                s[l - 1 - i][r] = diags[5][i];
                s[l - 1 - i][i] = diags[6][i];
                s[r][i] = diags[7][i];
            }

            return s;
        }
    }
}
