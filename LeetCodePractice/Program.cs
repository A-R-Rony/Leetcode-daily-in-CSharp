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
internal class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        int[] nums = [37, 12, 28, 9, 100, 56, 80, 5, 12];
        int[][] edges = [[0, 1], [0, 2], [1, 2], [3, 4], [3, 5]];
        bool[] online = [true, true, true, false, true];


        string s = "z*#";
        int[] result = solution.ArrayRankTransform(nums);
        Console.WriteLine(string.Join(", ", result));
        Console.ReadLine();
    }
}
