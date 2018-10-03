using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// An email address such as "John.Smith@example.com" is made up of a local part ("John.Smith"),
// an "@" symbol, then a domain part ("example.com").
// The domain name part of an email address may only consist of letters, digits, hyphens and dots.
// The local part, however, also allows a lot of different special characters.Here you can
// look at several examples of correct and incorrect email addresses.
// PROBLEM: Given a valid email address, find its domain part.

namespace findEmailDomain
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(findEmailDomain("bla@bla@yuhuuu.com"));
            Console.ReadKey();
        }

        static string findEmailDomain(string address)
        {
            string domain = address; // will be the domain

            // iteratively take each next to '@' part of the adress, until no more '@' will be found
            while (domain.Contains('@'))
            {
                int atPos = domain.IndexOf('@');
                domain = domain.Substring(atPos + 1);
            }

            return domain;
        }
    }
}
