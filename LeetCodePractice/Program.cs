namespace LeetCodePractice;


public class Solution
{
    public int UniqueXorTriplets(int[] nums)
    {
        int n = nums.Length;
        Dictionary<int, int> cnt = new Dictionary<int, int>();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (cnt.ContainsKey((nums[i] ^ nums[j]))) continue;
                cnt[(nums[i] ^ nums[j])] = 1;
            }
        }
        int an = 0;
        for (int i = 0; i <= 3000; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int xr = (nums[j] ^ i);
                if (cnt.ContainsKey(xr))
                {
                    an++;
                    
                    break;
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
        int[][] edges = [[0, 3], [0, 2], [1, 3], [2, 3]];
        int[] nums = [6, 7, 8, 9];
        int result = solution.UniqueXorTriplets(nums);
        Console.WriteLine(string.Join(", ", result));

        Console.ReadLine();
    }
}
