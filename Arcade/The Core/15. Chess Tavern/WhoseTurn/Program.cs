using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Imagine a standard chess board with only two white and two black knights placed in their
// standard starting positions: the white knights on b1 and g1; the black knights on b8 and g8.
// https://codefightsuserpics.s3.amazonaws.com/tasks/whoseTurn/img/initial_pos.png?_tm=1530820966293
// There are two players: one plays for white, the other for black.During each move,
// the player picks one of his knights and moves it to an unoccupied square according
// to standard chess rules.Thus, a knight on d5 can move to any of the following squares:
// b6, c7, e7, f6, f4, e3, c3, and b4, as long as it is not occupied by either a friendly or an enemy knight.
// https://codefightsuserpics.s3.amazonaws.com/tasks/whoseTurn/img/knight.jpg?_tm=1530820966615
// The players take turns in making moves, starting with the white player.
// Given the configuration p of the knights after an unspecified number of moves, determine whose turn it is.
// Example:
//          For p = "b1;g1;b8;g8", the output should be
//          whoseTurn(p) = true.
//          The configuration corresponds to the initial state of the game. Thus, it's white's turn.

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
