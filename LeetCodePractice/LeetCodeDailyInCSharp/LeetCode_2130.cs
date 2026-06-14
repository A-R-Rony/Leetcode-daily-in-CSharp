using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_2130
{
    public class Solution
    {
        public int PairSum(ListNode head)
        {
            List<int> an = new List<int>();
            int total = 0;
            ListNode tmp = head;
            while (tmp != null)
            {
                an.Add(tmp.val);
                tmp = tmp.next;
            }
            int sz = an.Count;
            int mx = 0;
            for (int i = 0; i < sz / 2; i++)
            {
                mx = int.Max(mx, an[i] + an[sz - i - 1]);
            }
            return mx;
        }
    }
}
