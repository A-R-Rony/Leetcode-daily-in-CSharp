using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.Intrinsics.X86;

namespace LeetCodePractice;

public class Solution
{
    public long GcdSum(int[] nums)
    {
        int n = nums.Length;
        int[] pre = new int[n];
        int[] mx = new int[n];

        for (int id = 0; id < n; id++)
        {
            mx[id] = int.Max((id-1 >= 0 ? mx[id - 1] : 0), nums[id]);
            pre[id] = Gcd(mx[id], nums[id]);
        }
        Array.Sort(pre);
        long sm = 0;
        int i = 0, j = n - 1;
        while(i < j)
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
internal class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        int[] nums = [10, 5, 7];
        int[][] edges = [[0, 1], [0, 2], [1, 2], [3, 4], [3, 5]];
        bool[] online = [true, true, true, false, true];


        string s = "z*#";
        long result = solution.GcdSum(nums);
        Console.WriteLine(string.Join(", ", result));
        Console.ReadLine();
    }
}
