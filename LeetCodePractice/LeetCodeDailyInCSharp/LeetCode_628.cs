namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_628
{
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
}
