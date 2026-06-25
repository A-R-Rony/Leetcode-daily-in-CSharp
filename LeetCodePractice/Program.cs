using System.ComponentModel.Design;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;

namespace LeetCodePractice;


public class Solution
{
    public int CountMajoritySubarrays(int[] nums, int target)
    {
        int an = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            int cn = 0, sz = 0;
            for(int j = i;j >= 0;j--)
            {
                sz++;
                if (nums[j] == target)
                {
                    cn++;
                }
                if(cn + cn > sz)
                {
                    an++;
                }
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
        string[] words = ["abcd", "def", "xyz"];
        int[] weights = [10, 6, 8, 7, 7, 8];
        string s = "z*#";
        int result = solution.ZigZagArrays(3,8,14);
        Console.WriteLine(string.Join(", ", result));
        Console.ReadLine();
    }
}
