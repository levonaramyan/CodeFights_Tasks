using System;
using System.Collections.Generic;
using System.Linq;

// Your task is to imitate a turn-based variation of the popular "Snake" game.
// https://codefightsuserpics.s3.amazonaws.com/tasks/snakeGame/img/snake.gif?_tm=1530813706942
// You are given the initial configuration of the board and a list of commands
// which the snake follows one-by-one.The game ends if one of the following happens:
//      the snake tries to eat its tail;
//      the snake tries to move out of the board;
//      it executes all the given commands.
// Output the board configuration after the game ends.
// Example:
//          snakeGame([['.', '.', '.', '.'],
//                     ['.', '.', '<', '*'],
//                     ['.', '.', '.', '*']],
//                    "FFFFFRFFRRLLF") = 
//                        [['.', '.', '.', '.'],
//                         ['X', 'X', 'X', '.'],
//                         ['.', '.', '.', '.']]
//
//          snakeGame([['.', '.', '^', '.', '.'],
//                     ['.', '.', '*', '*', '.'],
//                     ['.', '.', '.', '*', '*']],
//                    "RFRF") = 
//                        [['.', '.', 'X', 'X', '.'],
//                         ['.', '.', 'X', 'X', '.'],
//                         ['.', '.', '.', 'X', '.']]
//
//          snakeGame([['.', '.', '*', '>', '.'],
//                     ['.', '*', '*', '.', '.'],
//                     ['.', '.', '.', '.', '.']],
//                    "FRFFRFFRFLFF") = 
//                        [['.', '.', '.', '.', '.'],
//                         ['<', '*', '*', '.', '.'],
//                         ['.', '.', '*', '.', '.']]

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing test array
            string commands = "FRFFRFFRFLFF";
            char[][] gameBoard = new char[3][];
            gameBoard[0] = new char[] { '.', '.', '*', '>', '.' };
            gameBoard[1] = new char[] { '.', '*', '*', '.', '.' };
            gameBoard[2] = new char[] { '.', '.', '.', '.', '.' };

            // Printing the board at the beginning of the game
            foreach (var row in gameBoard)
            {
                foreach (char c in row) Console.Write($"{c} ");
                Console.WriteLine();
            }

            // Testing and printing the resulting state of the board
            char[][] res = snakeGame(gameBoard, commands);

            foreach (var row in res)
            {
                foreach (char c in row) Console.Write($"{c} ");
                Console.WriteLine();
            }

            Console.ReadKey();

        }

        // Returns the final state of the board after implementing the commands
        static char[][] snakeGame(char[][] gameBoard, string commands)
        {
            List<int[]> path = GetWholeSnake(gameBoard); // getting the snake
            int snLen = path.Count; // the length of snake
            int[] head = new int[] { path[snLen - 1][0], path[snLen - 1][1] };// head position
            bool isTerminated = false; // will be true if the game is terminated
            int headDir = GetHeadOrientation(gameBoard[head[0]][head[1]]); // heads orientation index

            // foreach command, moveNext or rotate
            foreach (char c in commands)
            {
                if (c == 'F')
                {
                    head = MoveNext(head, headDir);
                    if (IsFinished(gameBoard, path, snLen, head))
                    {
                        isTerminated = true;
                        break;
                    }
                    path.Add(new int[] { head[0],head[1]});
                }
                else
                {
                    headDir = RotateHead(c, headDir);
                }
            }

            char[][] res = PrintResult(gameBoard, path, snLen, headDir, isTerminated);
            return res;
        }

        // Gets all the cells of the snake, from tail to head order
        static List<int[]> GetWholeSnake(char[][] g)
        {
            int colMax = g[0].Length;
            int rowMax = g.Length;
            List<int[]> sn = new List<int[]>(0);
            int[] head = new int[2];

            for (int i = 0; i < rowMax; i++)
                for (int j = 0; j < colMax; j++)
                {
                    if (g[i][j] == '*') sn.Add(new int[] { i, j });
                    if ("<>^v".Contains(g[i][j])) head = new int[] { i, j };
                }

            return ConstructSnake(sn, head, g[head[0]][head[1]]);
        }

        // constructs a snake from tail to head order
        static List<int[]> ConstructSnake(List<int[]> body, int[] head, char dir)
        {
            List<int[]> snake = new List<int[]>(0);
            snake.Add(head);

            // get the neighboring to head cell of the snake and add it to snake, at the beginning
            if (body.Count > 0)
                switch (dir)
                {
                    case '>':
                        snake.Insert(0, new int[] { head[0], head[1] - 1 });
                        body = body.Where(x => x[0] != head[0] || x[1] != head[1] - 1).ToList();
                        break;
                    case '<':
                        snake.Insert(0, new int[] { head[0], head[1] + 1 });
                        body = body.Where(x => x[0] != head[0] || x[1] != head[1] + 1).ToList();
                        break;
                    case '^':
                        snake.Insert(0, new int[] { head[0] + 1, head[1] });
                        body = body.Where(x => x[0] != head[0] + 1 || x[1] != head[1]).ToList();
                        break;
                    case 'v':
                        snake.Insert(0, new int[] { head[0] - 1, head[1] });
                        body = body.Where(x => x[0] != head[0] - 1 || x[1] != head[1]).ToList();
                        break;
                }

            // find the neighboring cell of the beginning cell of determined snake (before that),
            // remove the found cell from body and add it at the beginning of snake
            // do it until no more cells are available in body
            while (body.Count > 0)
            {
                for (int i = 0; i < body.Count; i++)
                {
                    if (AreNeighbors(body[i], snake[0]))
                    {
                        snake.Insert(0, body[i]);
                        body.RemoveAt(i);
                        break;
                    }
                }
            }

            return snake;
        }

        // Checking if the given two cells are neighbors
        static bool AreNeighbors(int[] a, int[] b)
        {
            return (a[0] - b[0]) * (a[0] - b[0]) + (a[1] - b[1]) * (a[1] - b[1]) == 1;
        }

        // Checking if for the given position of the board, the game is finished,
        // before the end of commands, i.e. snake is out of board or it bytes itself
        static bool IsFinished(char[][] g, List<int[]> path, int len, int[] pos)
        {
            // true, if it is out of board range
            if (pos[0] < 0 || pos[0] >= g.Length || pos[1] < 0 || pos[1] >= g[0].Length)
                return true;

            // true, if it bytes itself
            for (int i = path.Count - len; i < path.Count; i++)
            {
                if (pos[0] == path[i][0] && pos[1] == path[i][1])
                    return true;
            }

            return false;
        }

        // returns a new direction index after implementing the rotation
        static int RotateHead(char rotation, int dir)
        {
            if (rotation == 'R') return ((dir + 1) % 4);
            if (rotation == 'L') return ((4 + dir - 1) % 4);
            return dir;
        }

        // Returns the index of head orientation from its char representation
        static int GetHeadOrientation(char c)
        {
            if (c == '^') return 0;
            if (c == '>') return 1;
            if (c == 'v') return 2;
            return 3;
        }

        // Returns the char of head orientation from its numerical representation
        static char GetOrientationChar(int i)
        {
            if (i == 0) return '^';
            if (i == 1) return '>';
            if (i == 2) return 'v';
            return '<';
        }

        // Returns a new position, after implementing 1 step move to given direction
        static int[] MoveNext(int[] p, int dir)
        {
            switch (dir)
            {
                case 0: p[0]--;break;
                case 2: p[0]++;break;
                case 1: p[1]++;break;
                case 3: p[1]--;break;
            }

            return p;
        }

        // Prints the resulting state of the board
        static char[][] PrintResult(char[][] g, List<int[]> path, int snLen, int headDir,bool isTerminated)
        {
            char[][] res = new char[g.Length][];
            for (int i = 0; i < g.Length; i++)
                res[i] = Enumerable.Range(0, g[0].Length).Select(x => '.').ToArray();

            if (isTerminated) // if terminated then snake is XXXX-like
            {
                for (int i = path.Count - snLen; i < path.Count; i++)
                    res[path[i][0]][path[i][1]] = 'X';
            }
            else // else the snake is ***>-like
            {
                for (int i = path.Count - snLen; i < path.Count - 1; i++)
                    res[path[i][0]][path[i][1]] = '*';
                res[path[path.Count - 1][0]][path[path.Count - 1][1]] = GetOrientationChar(headDir);
            }

            return res;
        }
    }
}
