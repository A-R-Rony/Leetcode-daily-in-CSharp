using System.ComponentModel.Design;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;

namespace LeetCodePractice;


public class Solution
{
    
    public int MaximumElementAfterDecrementingAndRearranging(int[] arr)
    {
        int n = arr.Length;
        Array.Sort(arr);
        int an = 1;
        Console.Error.WriteLine($"x = {an}");
        for (int i = 1;i < n;i++)
        {
            an = int.Min(an + 1, arr[i]);
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
