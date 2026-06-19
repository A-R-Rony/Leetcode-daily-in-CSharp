using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_1732
{
    public class Solution
    {
        public int LargestAltitude(int[] gain)
        {
            int mx = 0;
            int last = 0;
            foreach (var g in gain)
            {
                last += g;
                mx = int.Max(last, mx);
            }
            return mx;
        }
    }
}
