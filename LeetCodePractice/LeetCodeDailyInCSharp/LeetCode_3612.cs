using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_3612
{
    public class Solution
    {
        public string ProcessStr(string s)
        {
            string an = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLower(s[i]))
                {
                    an += s[i];
                    continue;
                }
                if (s[i] == '*' && an.Length > 0)
                {
                    an = an[..^1]; continue;
                }
                if (s[i] == '#') an += an;
                else an = new string(an.Reverse().ToArray());
            }

            return an;
        }
    }
}
