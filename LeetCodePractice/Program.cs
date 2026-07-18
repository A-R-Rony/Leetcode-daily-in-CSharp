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
    public int FindGCD(int[] nums)
    {
        Array.Sort(nums);
        return Gcd(nums[0], nums[^1]);
    }
    int Gcd(int a,int b)
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
