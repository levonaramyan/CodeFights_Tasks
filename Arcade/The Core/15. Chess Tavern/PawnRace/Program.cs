using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Pawn race is a game for two people, played on an ordinary 8 × 8 chessboard.
// The first player has a white pawn, the second one - a black pawn. Initially
// the pawns are placed somewhere on the board so that the 1st and the 8th rows are not occupied.
// Players take turns to make a move.
// White pawn moves upwards, black one moves downwards.The following moves are allowed:
//      one-cell move on the same vertical in the allowed direction;
//      two-cell move on the same vertical in the allowed direction, if the pawn is standing
//      on the 2nd(for the white pawn) or the 7th(for the black pawn) row.Note that even with the
//      two-cell move a pawn can't jump over the opponent's pawn;
//      capture move one cell forward in the allowed direction and one cell to the left or to the right.
// https://codefightsuserpics.s3.amazonaws.com/tasks/pawnRace/img/move_types.png?_tm=1530802148779
// The purpose of the game is to reach the the 1st row(for the black pawn) or the 8th row(for the white one),
// or to capture the opponent's pawn.
// Given the initial positions and whose turn it is, determine who will win
// or declare it a draw(i.e.it is impossible for any player to win). Assume that the players play optimally.
// Example:
//          For white = "e2", black = "e7", and toMove = 'w', the output should be
//          pawnRace(white, black, toMove) = "draw";
//
//          For white = "e3", black = "d7", and toMove = 'b', the output should be
//          pawnRace(white, black, toMove) = "black";
//          
//          For white = "a7", black = "h2", and toMove = 'w', the output should be
//          pawnRace(white, black, toMove) = "white".

namespace PawnRace
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string pawnRace(string white, string black, char toMove)
        {
            char winner = 'd';
            char op = (toMove == 'b') ? 'w' : 'b';
            if (toMove == 'b')
            {
                string temp = white;
                white = changeColor(black);
                black = changeColor(temp);
            }

            if (Math.Abs(white[0] - black[0]) > 1 || white[1] >= black[1])
            {
                int thr1 = '8' - (white[1] == '2' ? 1 : 0);
                int thr2 = '1' + (black[1] == '7' ? 1 : 0);
                winner = (thr1 - white[1] <= black[1] - thr2) ? toMove : op;
            }

            else if (white[0] == black[0]) winner = 'd';
            else// if (Math.Abs(white[0] - black[0]) == 1)
            {
                if (white[1] != '2' && black[1] != '7') winner = ((black[1] - white[1]) % 2 == 1) ? toMove : op;
                else if (black[1] != '7') winner = (black[1] != '4') ? winner = toMove : op;
                else if (white[1] != '2') winner = (white[1] != '6' && white[1] != '4') ? op : toMove;
                else winner = op;
            }

            return (winner == 'd' ? "draw" : (winner == 'b' ? "black" : "white"));
        }

        string changeColor(string pos)
        {
            return $"{pos[0]}{'9' - pos[1]}";
        }
    }
}
