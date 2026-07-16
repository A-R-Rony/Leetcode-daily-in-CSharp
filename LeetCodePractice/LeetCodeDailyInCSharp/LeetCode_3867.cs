using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_3867
{
    public class Solution
    {
        public long GcdSum(int[] nums)
        {
            int n = nums.Length;
            int[] pre = new int[n];
            int[] mx = new int[n];

            for (int id = 0; id < n; id++)
            {
                mx[id] = int.Max((id - 1 >= 0 ? mx[id - 1] : 0), nums[id]);
                pre[id] = Gcd(mx[id], nums[id]);
            }
            Array.Sort(pre);
            long sm = 0;
            int i = 0, j = n - 1;
            while (i < j)
            {
                sm += Gcd(pre[i++], pre[j--]);
            }
            return sm;
        }
        public int Gcd(int a, int b)
        {
            if (b == 0) return a;
            return Gcd(b, a % b);
        }
    }
}
