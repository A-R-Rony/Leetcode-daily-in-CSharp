namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_3514
{
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
}
