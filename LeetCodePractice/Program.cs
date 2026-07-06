using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;

namespace LeetCodePractice;

public class Solution
{
    public int RemoveCoveredIntervals(int[][] intervals)
    {
        int n = intervals.Length;
        int an = 0;

        for(int i = 0;i < n; i++)
        {
            bool ok = false;
            for(int j = 0;j < n;j++)
            {
                if (j == i) continue;
                var a = intervals[i];
                var b = intervals[j];

                if (b[0] <= a[0] && a[1] <= b[1])
                {
                    ok = true;
                }
            } 
            if(!ok)
            {
                an++;
            }
        }
        return an;
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        int[] nums = [73, 98, 9];
        int[][] edges = [[1, 4], [2, 3]];
        bool[] online = [true, true, true, false, true];


        string s = "z*#";
        int result = solution.RemoveCoveredIntervals(edges);
        Console.WriteLine(string.Join(", ", result));
        Console.ReadLine();
    }
}
