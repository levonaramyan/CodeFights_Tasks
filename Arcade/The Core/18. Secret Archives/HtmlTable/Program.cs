using System;
using System.Xml;

// HTML tables allow web developers to arrange data into rows and columns of cells.
// They are created using the <table> tag. Its content consists of one or more rows denoted
// by the <tr> tag. Further, the content of each row comprises one or more cells denoted
// by the <td> tag, and content within the <td> tags is what site visitors see in the table.
// For this task assume that tags have no attributes in contrast to real world HTML.
// Some tables contain the<th> tag.This tag defines header cells, which shouldn't be counted as regular cells.
// You are given a rectangular HTML table.Extract the content of the cell with coordinates (row, column).
// If you are not familiar with HTML, check out this note.
// Example
//          For table = "<table><tr><td>1</td><td>TWO</td></tr><tr><td>three</td><td>FoUr4</td></tr></table>",
//          row = 0, and column = 1, the output should be
//          htmlTable(table, row, column) = "TWO".
////////////////////////////
//          < table >
//           < tr >
//            < td > 1 </ td >
//            < td > TWO </ td >
//           </ tr >
//           < tr >
//            < td > three </ td >
//            < td > FoUr4 </ td >
//           </ tr >
//          </ table >
//          corresponds to:
//          1	TWO
//          three   FoUr4
/////////////////////////////////////////
//          For table = "<table><tr><td>1</td><td>TWO</td></tr></table>", row = 1, and column = 0,
//          the output should be
//          htmlTable(table, row, column) = "No such cell".
/////////////////////////////////////////
//          < table >
//           < tr >
//            < td > 1 </ td >
//            < td > TWO </ td >
//           </ tr >
//          </ table >
//          corresponds to:          
//          1	TWO

namespace HtmlTable
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing test values
            string testHtml = "<table><tr><td>1</td><td>TWO</td></tr></table>";
            int row = 1;
            int col = 0;

            // Testing and printing the result
            Console.WriteLine(htmlTable(testHtml, row, col));

            Console.ReadKey();
        }

        // The Solution, using XPath node selection of XMLDocument
        // Similar could be obtained with HtmlAgilityPack
        static string htmlTable2(string table, int row, int column)
        {
            try
            {
                XmlDocument code = new XmlDocument();
                code.LoadXml(table);
                return code.SelectSingleNode($"table/tr[{row + 1}]/td[{column + 1}]").InnerText;
            }
            catch
            {
                return "No such cell";
            }
        }

        // The solution using IndexOf method of string
        static string htmlTable(string table, int row, int column)
        {
            try
            {
                table = GetElemWithIndex(table, "<tr>", "</tr>", row);
                table = GetElemWithIndex(table, "<td>", "/td", column);

                return table;
            }
            catch
            {
                return "No such cell";
            }
        }

        // The method finds the inner text of n-th element which opens and closes with given strings
        static string GetElemWithIndex(string table, string open, string close, int n)
        {
            int end = 0;
            for (int i = 0; i <= n; i++)
                end = table.IndexOf(close, end + 1);
            table = table.Substring(0, end - 1);
            int start = table.LastIndexOf(open);
            table = table.Substring(start + open.Length);

            return table;
        }
    }
}
