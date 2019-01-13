using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimedReading
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int timedReading(int maxLength, string text)
        {
            int readed = 0;
            int wordlength = 0;
            int index = 0;
            foreach (char i in text)
            {
                if (wordlength > 0 && !(char.IsLetter(i)) && wordlength <= maxLength)
                    readed++;
                if (char.IsLetter(i)) wordlength++;
                else wordlength = 0;

                if (wordlength > 0 && wordlength <= maxLength && index == text.Length - 1)
                    readed++;
                index++;
            }

            return readed;

        }
    }
}
