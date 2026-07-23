namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_3513
{
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
}
