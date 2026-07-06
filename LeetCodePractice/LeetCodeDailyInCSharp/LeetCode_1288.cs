namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_1288
{
    public class Solution
    {
        public int RemoveCoveredIntervals(int[][] intervals)
        {
            int n = intervals.Length;
            int an = 0;

            for (int i = 0; i < n; i++)
            {
                bool ok = false;
                for (int j = 0; j < n; j++)
                {
                    if (j == i) continue;
                    var a = intervals[i];
                    var b = intervals[j];

                    if (b[0] <= a[0] && a[1] <= b[1])
                    {
                        ok = true;
                    }
                }
                if (!ok)
                {
                    an++;
                }
            }
            return an;
        }
    }
}
