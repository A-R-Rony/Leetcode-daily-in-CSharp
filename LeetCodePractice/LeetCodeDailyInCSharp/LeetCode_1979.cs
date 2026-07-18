namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_1979
{
    public class Solution
    {
        public int FindGCD(int[] nums)
        {
            Array.Sort(nums);
            return Gcd(nums[0], nums[^1]);
        }
        int Gcd(int a, int b)
        {
            if (b == 0) return a;
            return Gcd(b, a % b);
        }
    }
}
