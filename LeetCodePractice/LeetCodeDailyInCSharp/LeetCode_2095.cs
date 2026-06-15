using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_2095
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode DeleteMiddle(ListNode head)
        {
            if (head.next == null)
            {
                return null;
            }

            ListNode prev = head;
            ListNode middle = head;
            ListNode temp = head;
            int sz = 1;
            while (temp.next != null)
            {
                sz++;
                if (sz % 2 == 0)
                {
                    prev = middle;
                    middle = prev.next;
                }
                temp = temp.next;
            }
            prev.next = middle.next;
            return head;
        }
    }
}
