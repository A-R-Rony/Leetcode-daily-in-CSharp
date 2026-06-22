using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_1189
{
    public class Solution
    {
        public int MaxNumberOfBalloons(string text)
        {
            Dictionary<char, int> cnt = new Dictionary<char, int>();
            foreach (var c in text)
            {
                if (cnt.ContainsKey(c)) cnt[c]++;
                else cnt[c] = 1;
            }
            string t = "balloon";
            int mn = new[]
            {
           cnt.GetValueOrDefault('a',0),
           cnt.GetValueOrDefault('b',0),
           cnt.GetValueOrDefault('n',0),
           cnt.GetValueOrDefault('l',0)/2,
           cnt.GetValueOrDefault('o',0)/2
        }.Min();

            return mn;
        }
    }
}
