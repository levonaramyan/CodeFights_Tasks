using System;
using System.Globalization;

// During your most recent trip to Codelandia you decided to buy a brand new CodePlayer,
// a music player that (allegedly) can work with any possible media format. As it turns out,
// this isn't true: the player can't read lyrics written in the LRC format. It can, however,
// read the SubRip format, so now you want to translate all the lyrics you have from LRC to SubRip.
// Since you are a pro programmer(no noob would ever get to Codelandia!), you're happy
// to implement a function that, given lrcLyrics and songLength, returns the lyrics in SubRip format.
// Example:
//          For
//          lrcLyrics = ["[00:12.00] Happy birthday dear coder,",
//                       "[00:17.20] Happy birthday to you!"]
//          and songLength = "00:00:20", the output should be
//          lrc2subRip(lrcLyrics, songLength) = [
//            "1",
//            "00:00:12,000 --> 00:00:17,200",
//            "Happy birthday dear coder,",
//            "",
//            "2",
//            "00:00:17,200 --> 00:00:20,000",
//            "Happy birthday to you!"
//          ]

namespace LRCToSubrip
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string[] lrc2subRip(string[] lrcLyrics, string songLength)
        {
            int len = lrcLyrics.Length;
            string[] res = new string[4 * len - 1];

            for (int i = 0; i < len; i++)
            {
                res[4 * i] = $"{i + 1}";
                string time = lrcLyrics[i].Substring(1, 8);
                DateTime start = new DateTime() + TimeSpan.FromSeconds(ConvStrToSeconds(time));
                DateTime end = (i < len - 1) ?
                    new DateTime() + TimeSpan.FromSeconds(ConvStrToSeconds(lrcLyrics[i + 1].Substring(1, 8))) :
                    DateTime.ParseExact(songLength, "HH:mm:ss", CultureInfo.InvariantCulture);
                res[4 * i + 1] = $"{start.ToString("HH:mm:ss,fff")} --> {end.ToString("HH:mm:ss,fff")}";
                res[4 * i + 2] = lrcLyrics[i].Length > 11 ? lrcLyrics[i].Substring(11) : "";
                if (i < len - 1) res[4 * i + 3] = "";
            }

            return res;
        }

        static double ConvStrToSeconds(string t)
        {
            int m = int.Parse(t.Substring(0, 2));
            double s = double.Parse(t.Substring(3));
            return m * 60 + s;
        }
    }
}
