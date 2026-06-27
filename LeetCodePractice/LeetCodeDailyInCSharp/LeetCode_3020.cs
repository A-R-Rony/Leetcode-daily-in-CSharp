using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice.LeetCodeDailyInCSharp;

public class LeetCode_3020
{
    public class Solution
    {
        const int MAXN = (int)1e9;
        public int MaximumLength(int[] nums)
        {
            Dictionary<int, int> cnt = new Dictionary<int, int>();
            int an = nums.Count(x => x == 1);

            foreach (var num in nums)
            {
                if (!cnt.ContainsKey(num)) cnt[num] = 1;
                else cnt[num]++;
            }
            foreach (var num in nums)
            {
                if (num == 1) continue;
                int temp = num;
                int rs = 0;
                List<int> l = new List<int>();

                while (temp <= MAXN)
                {
                    if (!cnt.ContainsKey(temp)) break;
                    l.Add(temp);

                    if (MAXN / temp >= temp)
                    {
                        temp *= temp;
                    }
                    else
                    {
                        break;
                    }
                }

                //Console.WriteLine(string.Join(", ", l));
                l.Sort();

                for (int i = 0; i < l.Count; i++)
                {
                    if (cnt[l[i]] >= 2)
                    {
                        rs += 2;
                    }
                    else
                    {
                        rs += 1;
                        break;
                    }
                }
                if (rs % 2 == 0) rs--;
                //Console.WriteLine($"rs: {rs}");
                an = int.Max(an, rs);
            }
            if (an % 2 == 0) an--;
            return an;
        }
    }
}
