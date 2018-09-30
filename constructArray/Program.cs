using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// PROBLEM: Given an integer size, return an array containing each integer from 1 to size in the following order:
//          1, size, 2, (size - 1), 3, (size - 2), 4, ...

namespace constructArray
{
    class Program
    {
        static void Main(string[] args)
        {
            // initializing a test size and printing the result of the test
            int testSize = 7;
            int[] testArr = new int[testSize];
            testArr = ConstructArray(testSize);

            foreach (int i in testArr) Console.Write($"{i} ");
            Console.ReadKey();

        }

        // The method returns an array with length = size, and elements with mentioned order
        static int[] ConstructArray(int size)
        {

            // initializing variables
            int[] resArray = new int[size]; // will be the array that we are looking for           
            int index = 0; // the index, where a value will be added 
            int addVal = 1;  // add val will be added in resArray[index]

            // Adding values at even indexes
            do
            {
                resArray[index] = addVal++;
                index += 2;
            
            } while (index < size);

            // deciding the new index, from where to go back
            if (size % 2 == 0)
            {
                index = size - 1;
            }
            else index = size - 2;

            // Adding values at odd indexes
            if (size != 1)
            {
                do
                {
                    resArray[index] = ++addVal - 1;
                    index -= 2;
            
                } while (index >= 0);
            }

            // returning the resArray
            return resArray;
        }
    }
}
