using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given two version strings composed of several non-negative decimal fields separated by periods("."),
// both strings contain equal number of numeric fields.Return true if the first version is higher
// than the second version and false otherwise.
// The syntax follows the regular semver ordering rules:
// 1.0.5 < 1.1.0 < 1.1.5 < 1.1.10 < 1.2.0 < 1.2.2 < 1.2.10 < 1.10.2 < 2.0.0 < 10.0.0
// There are no leading zeros in any of the numeric fields, i.e.you do not have to handle inputs
// like 100.020.003 (it would instead be given as 100.20.3).
// Example:
//          For ver1 = "1.2.2" and ver2 = "1.2.0", the output should be
//          higherVersion(ver1, ver2) = true;
//          For ver1 = "1.0.5" and ver2 = "1.1.0", the output should be
//          higherVersion(ver1, ver2) = false.

namespace HigherVersion
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static bool higherVersion(string ver1, string ver2)
        {
            bool isHigher = true;
            int num1 = 0;
            int num2 = 0;
            while (isHigher && ver1.Length > 0)
            {
                num1 = (ver1.Contains('.')) ? int.Parse(ver1.Remove(ver1.IndexOf('.'))) : int.Parse(ver1);
                num2 = (ver2.Contains('.')) ? int.Parse(ver2.Remove(ver2.IndexOf('.'))) : int.Parse(ver2);
                if (num1 > num2) break;
                if (num2 > num1) isHigher = false;
                ver1 = (ver1.Contains('.')) ? ver1.Substring(ver1.IndexOf('.') + 1) : "";
                ver2 = (ver2.Contains('.')) ? ver2.Substring(ver2.IndexOf('.') + 1) : "";
            }
            if (num1 == num2 && isHigher) isHigher = false;
            return isHigher;
        }
    }
}
