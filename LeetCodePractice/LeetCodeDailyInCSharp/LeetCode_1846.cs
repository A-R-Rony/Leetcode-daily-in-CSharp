namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_1846
{
    public class Solution
    {

        public int MaximumElementAfterDecrementingAndRearranging(int[] arr)
        {
            int n = arr.Length;
            Array.Sort(arr);
            int an = 1;
            Console.Error.WriteLine($"x = {an}");
            for (int i = 1; i < n; i++)
            {
                an = int.Min(an + 1, arr[i]);
            }
            return an;
        }
    }
}
