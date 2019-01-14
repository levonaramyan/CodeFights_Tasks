using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphanumericLess
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static bool alphanumericLess(string s1, string s2)
        {
            bool tokenIsShorter = false;
            bool equalityIsChecked = false;
            bool isLess = true;
            bool chekingIsBreaked = false;
            string[] s1Tok = GetTokens(s1);
            string[] s2Tok = GetTokens(s2);
            int s1Len = s1Tok.Length;
            int s2Len = s2Tok.Length;
            bool firstIsShorter = s1Len < s2Len;
            bool secondIsShorter = s1Len > s2Len;
            int minToks = firstIsShorter ? s1Len : s2Len;

            for (int i = 0; i < minToks; i++)
            {
                if (FirstIsLess(s1Tok[i], s2Tok[i]))
                {
                    isLess = true;
                    chekingIsBreaked = true;
                    break;
                }
                else if (FirstIsLess(s2Tok[i], s1Tok[i]))
                {
                    isLess = false;
                    chekingIsBreaked = true;
                    break;
                }
                else
                {
                    if (!equalityIsChecked)
                    {
                        if (s1Tok[i].Length > s2Tok[i].Length)
                        {
                            tokenIsShorter = true;
                            equalityIsChecked = true;
                        }
                        else if ((s1Tok[i].Length < s2Tok[i].Length))
                        {
                            tokenIsShorter = false;
                            equalityIsChecked = true;
                        }
                    }
                }
            }

            if (chekingIsBreaked) return isLess;
            if (firstIsShorter) return true;
            if (secondIsShorter) return false;
            if (equalityIsChecked) return tokenIsShorter;
            return false;


        }

        static string[] GetTokens(string s)
        {
            bool isLetter = char.IsLetter(s[0]);
            int count = 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (char.IsLetter(s[i])) count++;
                else if (isLetter) count++;
                isLetter = char.IsLetter(s[i]);
            }

            string[] tokens = new string[count];
            int index = 0;
            string tempTok = "";

            while (s.Length > 0)
            {
                if (char.IsLetter(s[0]))
                {
                    tokens[index] = $"{s[0]}";
                    tempTok = "";
                }
                else
                {
                    int i = 0;
                    while (i < s.Length && char.IsDigit(s[i]))
                    {
                        tokens[index] += $"{s[i]}";
                        i++;
                    }
                }

                int tokLen = tokens[index].Length;
                s = tokLen < s.Length ? s.Substring(tokLen) : "";
                index++;
            }

            return tokens;
        }

        static bool FirstIsLess(string s1, string s2)
        {
            if (char.IsDigit(s1[0]) && !char.IsDigit(s2[0])) return true;
            if (char.IsLetter(s1[0]) && char.IsLetter(s2[0])) return s1[0] < s2[0];
            if (char.IsDigit(s1[0]) && char.IsDigit(s2[0])) return StrNumFirstIsLess(s1, s2);
            return false;
        }

        static bool StrNumFirstIsLess(string s1, string s2)
        {
            bool isLess = false;
            while (s1.Length > 1 && s1[0] == '0') s1 = s1.Substring(1);
            while (s2.Length > 1 && s2[0] == '0') s2 = s2.Substring(1);

            if (s1.Length < s2.Length) return true;
            else if (s2.Length < s1.Length) return false;
            else
            {
                int len = s1.Length;
                for (int i = 0; i < len; i++)
                {
                    if (s1[i] < s2[i])
                    {
                        isLess = true;
                        break;
                    }
                    if (s2[i] < s1[i]) break;
                }
            }
            return isLess;
        }
    }
}
