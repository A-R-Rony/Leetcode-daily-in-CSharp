using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_1833
{
    public class Solution
    {
        public int MaxIceCream(int[] costs, int coins)
        {
            Array.Sort(costs);
            for (int i = 0; i < costs.Length; i++)
            {
                if (coins >= costs[i])
                {
                    coins -= costs[i];
                    continue;
                }
                else
                {
                    return i;
                }
            }
            return costs.Length;

        }
    }
}
