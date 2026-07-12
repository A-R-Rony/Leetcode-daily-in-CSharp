using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_1331
{
    public class Solution
    {
        public int[] ArrayRankTransform(int[] arr)
        {
            Dictionary<int, int> pos = new Dictionary<int, int>();
            int[] b = (int[])arr.Clone();

            Array.Sort(b);
            int cnt = 1;


            for (int i = 0; i < arr.Length; i++)
            {
                if (pos.ContainsKey(b[i])) continue;
                pos[b[i]] = cnt++;
            }
            int[] an = new int[b.Length];
            for (int i = 0; i < b.Length; i++)
            {
                an[i] = pos[arr[i]];
            }
            return an;
        }
    }
}
