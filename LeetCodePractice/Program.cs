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
internal class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        string[] words = ["abcd", "def", "xyz"];
        int[] weights = [5, 3, 12, 14, 1, 2, 3, 2, 10, 6, 6, 9, 7, 8, 7, 10, 8, 9, 6, 9, 9, 8, 3, 7, 7, 2];

        ListNode head = new ListNode();
        int result = solution.PairSum(head);
        Console.WriteLine(string.Join(", ", result));
        Console.ReadLine();
    }
}
