using System.ComponentModel.Design;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;

namespace LeetCodePractice;


public class Solution
{
    public int NumOfStrings(string[] patterns, string word)
    {
        int an = 0;
        foreach(var p in patterns)
        {
            an += (word.Contains(p) ? 1 : 0);
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
        string s = "z*#";
        int result = solution.MaximumElementAfterDecrementingAndRearranging(nums);
        Console.WriteLine(string.Join(", ", result));
        Console.ReadLine();
    }
}
