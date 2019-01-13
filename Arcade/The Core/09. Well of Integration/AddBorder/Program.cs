using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a rectangular matrix of characters, add a border of asterisks(*) to it.
// Example:
//          For
//          picture = ["abc",
//                     "ded"]
//          the output should be
//          addBorder(picture) = ["*****",
//                                "*abc*",
//                                "*ded*",
//                                "*****"]

namespace AddBorder
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string[] addBorder(string[] picture)
        {
            string[] newStr = new String[picture.Length + 2];
            for (int i = 0; i < picture.Length; i++)
            {
                picture[i] = $"*{picture[i]}*";
                newStr[i + 1] = picture[i];
            }

            int strLen = picture[0].Length;
            string line = new String('*', strLen);
            newStr[0] = line;
            newStr[newStr.Length - 1] = line;

            return newStr;

        }
    }
}
