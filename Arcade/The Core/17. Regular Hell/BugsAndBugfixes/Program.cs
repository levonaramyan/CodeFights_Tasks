﻿using System;
using System.Text.RegularExpressions;

// Implement the missing code, denoted by ellipses. You may not modify the pre-existing code.
// In most role-playing games, die rolls required by the system are given in the form AdX.
// A and X are positive integers, separated by the letter 'd', which stands for die or dice.
// A is the number of times the die should be rolled(usually omitted if 1).
// X is the number of faces on the die.
// To this basic notation, an additive modifier can be appended that yields expressions
// in the form AdX+B or AdX-B.B is a number added to the sum of the rolls (or subtracted from it).
// So, 1d20-10 would indicate a single roll of a 20-sided die with 10 being subtracted from the result.
// You're reading the rules of a famous Bugs and Bugfixes role-playing game involving dice.
// What is the maximum number of points you can get, assuming that you roll the dice
// according to each formula present within rules?
// It is guaranteed that all the formulas that appear in rules are correct
// (i.e. A and X are always positive in a formula-like substring), and any two substrings
// that may be formulas do not overlap.
// Example:
//          For rules = "Roll d6-3 and 4d4+3 to pick a weapon, and finish the boss with 3d7!",
//          the output should be
//          bugsAndBugfixes(rules) = 43.
//          There are three formulas in the rules.
//          d6-3 indicates a single roll of a 6-sided die, with 3 subtracted from the result.
//          The maximum number that is possible to get is thus 6 - 3 = 3.
//          4d4 + 3 stands for 4 rolls of a 4 - sided die, with 3 added to the result.
//          It is possible to get 4 * 4 + 3 = 19 points.
//          3d7 means 3 rolls of a 7 - sided die.The maximum number to obtain with it is 3 * 7 = 21.

namespace BugsAndBugfixes
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int bugsAndBugfixes(string rules)
        {
            Regex regex = new Regex(@"(\d*)d(\d+)([+-]\d+)*");
            MatchCollection formulas = regex.Matches(rules);

            int res = 0;
            foreach (Match match in formulas)
            {
                GroupCollection formula = match.Groups;
                int rolls = String.IsNullOrEmpty(formula[1].Value) ?
                  1 : Int32.Parse(formula[1].Value);
                int dieType = Int32.Parse(formula[2].Value);
                int formulaMax = rolls * dieType;

                if (!String.IsNullOrEmpty(formula[3].Value))
                {
                    if (formula[3].Value[0] == '-')
                    {
                        formulaMax -= Int32.Parse(formula[3].Value.Substring(1));
                    }
                    else
                    {
                        formulaMax += Int32.Parse(formula[3].Value.Substring(1));
                    }
                }
                res += formulaMax;
            }
            return res;
        }
    }
}
