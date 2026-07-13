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
    int f(int x, int i, int num)
    {
        if (i == 0)
        {
            return num;
        }

        return f(x + 1, i - 1, (num * 10) + x);
    }
    public IList<int> SequentialDigits(int low, int high)
    {
        List<int> l = new List<int>();
        for (int i = 1; i <= 10; i++)
        {
            for (int j = 1; j <= 9; j++)
            {
                if ((9 - j) + 1 >= i)
                {
                    l.Add(f(j, i, 0));
                }
            }
        }

        return l.Where(x => x >= low && x <= high).ToList()       
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
        IList<int> result = solution.SequentialDigits(10,100);
        Console.WriteLine(string.Join(", ", result));
        Console.ReadLine();
    }
}
