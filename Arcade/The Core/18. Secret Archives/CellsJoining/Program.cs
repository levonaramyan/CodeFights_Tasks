using System;

// You are writing a spreadsheet application for an ancient operating system.
// The system runs on a computer so old that it can only display ASCII graphics.
// Currently you are stuck with implementing the cells joining algorithm.
// You are given a table in ASCII graphics, where the following characters
// are used for borders: +, -, |. The rows can have different heights and the columns
// can have different widths.Each cell has an area greater than 1 (excluding the borders)
// and can contain any ASCII characters excluding +, - and |.
// The algorithm you want to implement should merge the cells within a given rectangular part
// of the table into a single cell by removing the borders between them
// (i.e.replace them with space characters (' ') and replace redundant +s with correct border symbols).
// The cells to join are represented by the coordinates of the cells at the extreme bottom-left
// and top-right of the area.
// Example:
//          For
//          table = ["+----+--+-----+----+",
//                 "|abcd|56|!@#$%|qwer|",
//                 "|1234|78|^&=()|tyui|",
//                 "+----+--+-----+----+",
//                 "|zxcv|90|77777|stop|",
//                 "+----+--+-----+----+",
//                "|asdf|~~|ghjkl|100$|",
//                 "+----+--+-----+----+"]
//          and coords = [[2, 0], [1, 1]], the output should be
//          cellsJoining(table, coords) = ["+----+--+-----+----+",
//                                         "|abcd|56|!@#$%|qwer|",
//                                         "|1234|78|^&=()|tyui|",
//                                         "+----+--+-----+----+",
//                                         "|zxcv 90|77777|stop|",
//                                         "|       +-----+----+",
//                                         "|asdf ~~|ghjkl|100$|",
//                                         "+-------+-----+----+"]

namespace CellsJoining
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing test values
            string[] table = new string[]
            {
                "+-----+-----+--------+-----------+--------+",
                "|fwdaw|dddd |42      |pretty long|table   |",
                "+-----+-----+--------+-----------+--------+",
                "|is   |long |ffffffff|ff         |border  |",
                "+-----+-----+--------+-----------+--------+",
                "|     |     |        |           |        |",
                "|     |     |        |           |        |",
                "+-----+-----+--------+-----------+--------+",
                "|empty|cells|are     |best       |there is|",
                "+-----+-----+--------+-----------+--------+"
            };
            int[][] coords = new int[2][];
            coords[0] = new int[] { 3, 0 };
            coords[1] = new int[] { 1, 3 };

            // testing and printing the result
            string[] merged = cellsJoining(table, coords);
            foreach (string row in merged) Console.WriteLine(row);
            Console.ReadKey();
        }

        // Returns a new table, where the mentioned cells were merged
        static string[] cellsJoining(string[] table, int[][] coords)
        {
            int[][] range = GetMtrixRange(table, coords);

            for (int i = range[0][0]; i <= range[0][1]; i++)
            {
                char[] row = table[i].ToCharArray();
                for (int j = range[1][0]; j <= range[1][1]; j++)
                    if (table[i][j] == '+' || table[i][j] == '-' || table[i][j] == '|')
                        row[j] = ' ';
                table[i] = new string(row);
            }

            table = CorrectTheBorder(table, range);

            return table;
        }

        // getting the index range[[i_min,i_max],[j_min,j_max]] of merging cells symbols in matrix
        static int[][] GetMtrixRange(string[] table, int[][] coords)
        {
            int[][] range = new int[2][];
            range[0] = new int[2];
            range[1] = new int[2];
            int row = -1;
            int col = -1;

            for (int i = 0; i < table.Length; i++)
            {
                if (table[i][0] == '+') row++;
                if (row == coords[1][0] && range[0][0] == 0) range[0][0] = i + 1;
                if (row - 1 == coords[0][0] && range[0][1] == 0) range[0][1] = i - 1;
            }

            int index = -1;
            for (int i = 0; i <= coords[1][1] + 2; i++)
            {
                string s = table[0];                
                index = s.IndexOf('+', index + 1);
                col++;
                if (col == coords[0][1] && range[1][0] == 0) range[1][0] = index + 1;
                if (col - 1 == coords[1][1] && range[1][1] == 0) range[1][1] = index - 1;
            }

            return range;
        }

        // Correcting the borders, after merging the symbols from range[][]
        static string[] CorrectTheBorder (string[] table, int[][] range)
        {
            if (range[0][0] == 1) table[0] = table[0].Substring(0, range[1][0]) +
                    new string('-', range[1][1] - range[1][0] + 1) +
                    table[0].Substring(range[1][1] + 1);

            int l = table.Length - 1;
            if (range[0][1] == l-1) table[l] = table[l].Substring(0, range[1][0]) +
                    new string('-', range[1][1] - range[1][0] + 1) +
                    table[l].Substring(range[1][1] + 1);

            if (range[1][0] == 1)
                for (int i = range[0][0]; i <= range[0][1]; i++)
                    table[i] = '|'+table[i].Substring(1);

            if (range[1][1] == table[0].Length - 2)
                for (int i = range[0][0]; i <= range[0][1]; i++)
                    table[i] = table[i].Substring(0,table[0].Length - 1) + '|';

            return table;
        }
    }
}
