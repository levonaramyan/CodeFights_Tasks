using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// As a good secret agent, you know that you can't be communicating with other agents using a common alphabet
// or any kind of simple messaging system. Because of that, you and the other secret agents are using a
// small code alphabet to send minimal messages to each other, in order to coordinate your secret meetings.
// You've received an encoded message in the form of a string incomingMessage, which represents an inquiry
// from another secret agent, proposing a day, time, and location for your next secret meeting.
// Your task is to decode the message, and give a response indicating whether the meeting is possible or not.
// How to decipher the message:
//          This process can be quite complicated, so the following description would probably be tough
//          to follow for an average person, but the agency knows that you possess the exceptional skill
//          and patience to make it through easily!
//          Your alphabet consists of 20 symbols, and you can use the following key for encoding and decoding
//          (but don't tell anyone!)
//          "0" = "a"
//          "9" = "e"
//          "8" = "i"
//          "7" = "o"
//          "6" = "u"
//          "5" = "y"
//          "4" = "w"
//          "10" = "t"
//          "11" = "d"
//          "12" = "s"
//          "13" = "n"
//          "14" = "m"
//          "15" = "r"
//          "16" = "b"
//          "17" = "k"
//          "18" = "p"
//          "*" = "morning"
//          "@" = "afternoon"
//          "#" = "night"
//          "?" = "-"
// Each encoded message is made up of a series of these symbols, separated by "." characters.The decoded message
// should be in the form day-time-location.
// For an extra layer of security, the "_" symbol is used to augment the code of all the numbers that follow it.
// More specifically, the codes should all be increased by codeNumberDiff, from that point onward.
// These modifiers are cumulative, so the codes can be augmented more than once.
//
// Being an Agent means that you need to be cautious about your movements, so there are only a few combinations
// of days, times, and locations that will work:
//
// If the day is "today", you can only meet in the park (regardless of the time).
// If the day is "tomorrow", then you can either meet at the "bar" at "night", or in the "park" during the "afternoon".
// If the day is "twodays" (the day after tomorrow), then you can only meet at the "restaurant" in the "morning".
// No other combinations are possible.
// To answer the other agent, you must send an encrypted message with a "yes" or "no" (remember to send it encrypted).
// Return a 2-element array, containing the decrypted message and your encrypted response!

// Example: For incomingMessage = "10.7.11.0.5.?.#.?._.15.-1.14" and codeNumberDiff = 1,
//          the output should be["today-night-bar", "13.7"]
//          The first parts can be decoded using the key above("10.7.11.0.5" translates to "today" and "#"
//          translates to "night"), but since there's a "_" symbol in the last part, all of the following codes
//          should be augmented by 1 (since codeNumberDiff is 1). So the message goes from "15.-1.14" to "16.0.15",
//          which translates to "bar".
//          The answer for the message is "no", because for today you can only meet in the park(not the bar).
//          So after encrypting your response, the result is "13.7".

//          For incomingMessage = "10.4.7.11.0.5._.10.?.*.?._.11.5.8.6.-4.2.11.-4.9.6" and codeNumberDiff = 2,
//          the output should be["twodays-morning-restaurant", "5.9.12"]
//          There are two "_" symbols in the message, so after the first one appears, all codes should be
//          increased by 2; after the second one, all codes should be increased by 4.
//          Decrypting the message, it shows that the meeting will be in two days, in the morning at the restaurant,
//          which is a valid combination, so you answer with a encrypted "yes" ("5.9.12").

namespace SecretAgentsMeetingProposal
{
    class Program
    {
        static void Main(string[] args)
        {
            string inMess = "10.7.11.0.5.?.#.?._.15.-1.14";
            int diff = 1;
            string[] res = secretAgentsMeetingProposal(inMess, diff);

            foreach (string s in res) Console.WriteLine(s);
            Console.ReadKey();
        }

        // Returns the decoded message and encoded answer in string[] array
        static string[] secretAgentsMeetingProposal(string incomingMessage, int codeNumberDiff)
        {
            incomingMessage += ".";
            int und = incomingMessage.IndexOf("_");
            int[] add = new int[incomingMessage.Length];
            for (int j = 0; j < incomingMessage.Length; j++)
                add[j] = (j > 0 ? add[j - 1] : 0) + (incomingMessage[j] == '_' ? codeNumberDiff : 0);
            if (und < 0) und = incomingMessage.Length;
            string[] enc = new string[] { "0", "9", "8", "7", "6", "5", "4", "10", "11", "12", "13", "14", "15",
                                 "16", "17", "18", "*", "@", "#", "?", "_" };
            string[] dec = new string[]{"a","e","i","o","u","y","w","t","d","s","n","m","r","b","k","p",
                                "morning","afternoon","night","-",""};
            string[] dtl = new string[] { "", "", "" };
            int i = 0;
            int start = 0;
            bool last = false;
            
            // Getting each word in an encoded message
            while (!last)
            {
                int end = incomingMessage.IndexOf("?", start);
                if (end < 0) { end = incomingMessage.Length; last = true; }
                int pointer = incomingMessage.IndexOf(".", start);
                while (pointer < end)
                {
                    string s = incomingMessage.Substring(start, pointer - start);
                    int num;
                    if (int.TryParse(s, out num))
                    {
                        num += (start > und) ? add[start] : 0;
                        dtl[i] += dec[Array.IndexOf(enc, $"{num}")];
                    }
                    else dtl[i] += dec[Array.IndexOf(enc, s)];
                    start = pointer + 1;
                    pointer = incomingMessage.IndexOf(".", start);
                    if (pointer < 0) break;
                }
                start = end + 2;
                i++;
            }

            return (new string[] { $"{dtl[0]}-{dtl[1]}-{dtl[2]}", CheckMessage(dtl) });
        }

        // Validating the decoded message and returns the encoded answer
        static string CheckMessage(string[] s)
        {
            if (s[0] == "today") return (s[2] == "park" ? "5.9.12" : "13.7");
            else if (s[0] == "tomorrow")
                return ((s[1] == "night" && s[2] == "bar") || (s[1] == "afternoon" && s[2] == "park") ? "5.9.12" : "13.7");
            else return (s[1] == "morning" && s[2] == "restaurant" ? "5.9.12" : "13.7");
        }
    }
}
