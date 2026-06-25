using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_3737
{
    public class Solution
    {
        public int CountMajoritySubarrays(int[] nums, int target)
        {
            int an = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int cn = 0, sz = 0;
                for (int j = i; j >= 0; j--)
                {
                    sz++;
                    if (nums[j] == target)
                    {
                        cn++;
                    }
                    if (cn + cn > sz)
                    {
                        an++;
                    }
                }
            }
            return an;
        }
    }
}
