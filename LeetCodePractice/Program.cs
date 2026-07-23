namespace LeetCodePractice;


public class Solution
{
    public int UniqueXorTriplets(int[] nums)
    {
        int n = nums.Length;
        if (n <= 2) return n;
        int bit = (int)Math.Log2(n) + 1;
        return (1 << bit);
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[][] edges = [[0, 3], [0, 2], [1, 3], [2, 3]];
        int[] nums = [3, 1, 2];
        int result = solution.UniqueXorTriplets(nums);
        Console.WriteLine(string.Join(", ", result));

        Console.ReadLine();
    }
}
