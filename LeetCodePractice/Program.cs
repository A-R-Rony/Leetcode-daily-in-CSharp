using System.ComponentModel.Design;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;

namespace LeetCodePractice;

 
  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
  }

public class Solution
{
    public ListNode DeleteMiddle(ListNode head)
    {
        if(head.next == null)
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
internal class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        string[] words = ["abcd", "def", "xyz"];
        int[] weights = [5, 3, 12, 14, 1, 2, 3, 2, 10, 6, 6, 9, 7, 8, 7, 10, 8, 9, 6, 9, 9, 8, 3, 7, 7, 2];

        ListNode head = new ListNode();
        ListNode result = solution.DeleteMiddle(head);
        Console.WriteLine(string.Join(", ", result));
        Console.ReadLine();
    }
}
