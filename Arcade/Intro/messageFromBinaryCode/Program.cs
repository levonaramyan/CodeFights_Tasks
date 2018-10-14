using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You are taking part in an Escape Room challenge designed specifically for programmers.
// In your efforts to find a clue, you've found a binary code written on the wall behind a vase,
// and realized that it must be an encrypted message. After some thought, your first guess is
// that each consecutive 8 bits of the code stand for the character with the corresponding extended ASCII code.

// PROBLEM: Assuming that your hunch is correct, decode the message.

// Example:
// For code = "010010000110010101101100011011000110111100100001", the output should be
// messageFromBinaryCode(code) = "Hello!".

// The first 8 characters of the code are 01001000, which is 72 in the binary numeral system.
// 72 stands for H in the ASCII-table, so the first letter is H.
// Other letters can be obtained in the same manner.

namespace messageFromBinaryCode
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(messageFromBinaryCode("010010000110010101101100011011000110111100100001"));
            Console.ReadKey();

        }

        // The method decods a binary string code and returns it as an ASCII message
        static string messageFromBinaryCode(string code)
        {
            int decLen = code.Length / 8; // the number of containing bytes
            string message = "";

            // taking the bytes one by one from string, and after converting to char, recunstruct the message
            for (int i = 0; i < decLen; i++)
            {
                string byteString = code.Substring(i * 8 , 8);
                message = $"{message}{ByteToAscii(BinaryToByte(byteString))}";
            }
            return message;
        }

        // The method takes an 8bit binary representation of a byte from string and returns the number
        static byte BinaryToByte (string bin)
        {
            byte num = 0;
            byte binParam = 1;
            for (int i = 0; i < 8; i++)
            {
                num += (byte)(Convert.ToByte($"{bin[7 - i]}")*binParam);
                binParam *= 2;
            }

            return num;
        }

        // The method takes a byte and returns corresponding ASCII char
        static char ByteToAscii (byte a)
        {
            byte[] b = new byte[1] { a };
            char c = (Encoding.ASCII.GetChars(b))[0];
            return c;
        }

    }
}
