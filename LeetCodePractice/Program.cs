namespace LeetCodePractice;


public class Solution
{
    public int MaximumProduct(int[] nums)
    {
        int n = nums.Length;
        Array.Sort(nums);
        int an = nums[^1] * nums[^2] * nums[^3];
        an = int.Max(an, nums[0] * nums[1] * nums[^1]);
        return an;
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[][] edges = [[0, 3], [0, 2], [1, 3], [2, 3]];
        int[] nums = [6, 7, 8, 9];
        int result = solution.MaxProduct(123);
        Console.WriteLine(string.Join(", ", result));

        Console.ReadLine();
    }
}
