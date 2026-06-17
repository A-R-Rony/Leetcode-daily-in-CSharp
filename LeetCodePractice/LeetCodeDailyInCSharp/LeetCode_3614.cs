using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_3614
{
    public class Solution
    {
        public char ProcessStr(string s, long k)
        {
            long len = 0;
            foreach (var c in s)
            {
                if (c == '*')
                {
                    if (len > 0) len--;
                }
                else if (c == '#') len *= 2;
                else if (c == '%') continue;
                else len++;
            }
            if (k + 1 > len)
            {
                return '.';
            }
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '*') len++;
                else if (s[i] == '#')
                {
                    if (k + 1 > (len + 1) / 2) k -= len / 2;
                    len = (len + 1) / 2;
                }
                else if (s[i] == '%') k = len - k - 1;
                else
                {
                    if (k + 1 == len) return s[i];
                    else len--;
                }
            }
            return '.';
        }
    }
}
