using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
