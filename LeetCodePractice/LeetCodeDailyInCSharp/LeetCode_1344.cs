using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_1344
{
    public class Solution
    {
        public double AngleClock(int hour, int minutes)
        {
            double H = hour * 30;
            double M = (5.5) * minutes;
            return Math.Min(Math.Abs(H - M), 360 - Math.Abs(H - M));
        }
    }
}
