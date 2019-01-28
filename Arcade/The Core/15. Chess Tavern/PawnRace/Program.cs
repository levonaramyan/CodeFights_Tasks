using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
