using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You have a rectangular white board with some black cells. The black cells create
// a connected black figure, i.e. it is possible to get from any black cell to any other
// one through connected adjacent (sharing a common side) black cells.
// Find the perimeter of the black figure assuming that a single cell has unit length.
// It's guaranteed that there is at least one black cell on the table.
// Example:
//          For
//          matrix = [[false, true,  true ],
//                    [true,  true,  false],
//                    [true,  false, false]]
//          the output should be
//          polygonPerimeter(matrix) = 12.
//          https://codefightsuserpics.s3.amazonaws.com/tasks/polygonPerimeter/img/example1.png?_tm=1530813421164
//
//          For
//          matrix = [[true, true, true],
//                    [true, false, true],
//                    [true, true, true]]
//          the output should be
//          polygonPerimeter(matrix) = 16.
//          https://codefightsuserpics.s3.amazonaws.com/tasks/polygonPerimeter/img/example2.png?_tm=1530813421519


namespace PolygonPerimeter
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int polygonPerimeter(bool[][] matrix)
        {
            int perim = 0;
            int r = matrix.Length;
            int c = matrix[0].Length;

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (matrix[i][j])
                    {
                        perim += 4;
                        for (int k = -1; k <= 1; k += 2)
                        {
                            if ((i + k) < r && (i + k) >= 0 && matrix[i + k][j]) perim--;
                            if ((j + k) < c && (j + k) >= 0 && matrix[i][j + k]) perim--;
                        }
                    }


                }
            }

            return perim;

        }

    }
}
