using System;

// John has always had trouble remembering chess game positions. To help himself with remembering,
// he decided to store game positions in strings. He came up with the following position notation:
//    - The notation is built for the current game position row by row from top to bottom,
//          with '/' separating each row notation;
//    - Within each row, the contents of each square are described from the leftmost column to the rightmost;
//    - Each piece is identified by a single letter taken from the standard English names
//          ('P' = pawn, 'N' = knight, 'B' = bishop, 'R' = rook, 'Q' = queen, 'K' = king);
//    - White pieces are designated using upper-case letters("PNBRQK") while black pieces
//          use lowercase("pnbrqk");
//    - Empty squares are noted using digits 1 through 8 (the number of empty squares from the last piece);
//    - Empty lines are noted as "8".
// For example, for the initial position(shown in the picture below) the notation will look like this:
// https://codefightsuserpics.s3.amazonaws.com/tasks/chessNotation/img/initial.jpg?_tm=1490625686736
// "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR"
//
// After the white pawn moves from e2 to e4, the notation will be as follows:
// "rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR"
//
// John has written down some positions using his notation, and now he wants to rotate
// the board 90 degrees clockwise and see what notation for the new board would look like.
// Help him with this task.
// Example:
//          For notation = "rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR", the output should be
//          chessNotation(notation) = "RP4pr/NP4pn/BP4pb/QP4pq/K2P2pk/BP4pb/NP4pn/RP4pr".
//          The notation corresponds to the initial position with one move made (white pawn from e2 to e4).
//          After rotating the board, it will look like this:
//          https://codefightsuserpics.s3.amazonaws.com/tasks/chessNotation/img/example.jpg?_tm=1490625686887
//          So, the notation of the new position is "RP4pr/NP4pn/BP4pb/QP4pq/K2P2pk/BP4pb/NP4pn/RP4pr".

namespace ChessNotation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            string test = "rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR";
            Console.WriteLine(chessNotation(test));
            Console.ReadKey();
        }

        // Returns the notation of clockwise returned chess table
        static string chessNotation(string notation)
        {
            char[][] matrix = GetChessMatrix(notation);
            //PrintMatrix(matrix); // printing the view of chess table before rotation
            matrix = RotateMatrix(matrix);
            //PrintMatrix(matrix); // printing the view of chess table after rotation
            string res = "";
            for (int i = 0; i < 8; i++)
                res += (i < 7) ? $"{ConvertRowToString(matrix[i])}/" : ConvertRowToString(matrix[i]);

            return res;
        }

        // Converting each block of line notation into a char array of each square of the line
        static char[] ConvertToChessRow(string raw)
        {
            char[] res = new char[8];
            int index = 0;
            foreach (char a in raw)
            {
                if (!char.IsDigit(a)) res[index++] = a;
                else for (int i = 0; i < int.Parse($"{a}"); i++)
                        res[index++] = '1';
            }

            return res;
        }

        // converting a char array of the line into a notation of the line
        static string ConvertRowToString(char[] c)
        {
            string res = string.Concat(c);
            for (int i = 8; i > 0; i--)
            {
                string s = new string('1', i);
                res = res.Replace(s, $"{i}");
            }

            return res;
        }

        // Returns a matrix of a chess table from notation
        static char[][] GetChessMatrix(string notation)
        {
            char[][] res = new char[8][];

            string[] rows = notation.Split('/');
            for (int i = 0; i < 8; i++)
                res[i] = ConvertToChessRow(rows[i]);

            return res;
        }

        // Rotates the matrix 90 degrees clockwise
        static char[][] RotateMatrix(char[][] c)
        {
            char[][] res = new char[8][];
            for (int i = 0; i < 8; i++)
                res[i] = new char[8];

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    res[j][7 - i] = c[i][j];

            return res;
        }

        // Prints the matrix in the console
        static void PrintMatrix(char[][] c)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                    Console.Write(c[i][j]);
                Console.WriteLine();
            }
        }
    }
}
