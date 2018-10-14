using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addBorder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given a rectangular matrix of characters, add a border of asterisks(*) to it.

            // defining a test matrix of characters
            string[] picture = new string[3] { "abc","ded", "cha"};

            // getting a new matrix with * border and printing in console
            string[] newPic =  addBorder(picture);     
            foreach (string i in newPic) Console.WriteLine(i);

            // Delay
            Console.ReadKey();            
        }

        // The method takes the matrix picture[] and returns a new matrix that contains border with * symbol
        static string[] addBorder(string[] picture)
        {
            // Defining variables
            int pictLen = picture.Length; // the height of the matrix
            int elemLen = picture[0].Length; // the length of the matrix
            string border = ""; // the horizontal border with "*"-s
            string[] newPic = new string[pictLen + 2]; //new matrix, which will contain the borders

            // making the horizonthal border
            for (int i = 0; i < elemLen + 2; i++)
            {
                border += "*";
            }

            // adding the horizonthal border to the newPic matrix
            newPic[0] = border;
            newPic[newPic.Length - 1] = border;

            // adding the vertical borders and adding to newPic matrix
            for (int i = 0; i < pictLen; i++)
            {
                newPic[i + 1] = "*" + picture[i] + "*";
            }

            return newPic; // returning the bordered matrix
        }
    }
}
