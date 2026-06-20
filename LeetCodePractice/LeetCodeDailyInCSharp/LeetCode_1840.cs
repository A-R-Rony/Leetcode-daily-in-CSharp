using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_1840
{
    public class Solution
    {
        public int MaxBuilding(int n, int[][] restrictions)
        {

            List<int[]> r = new List<int[]>();
            foreach (int[] res in restrictions)
            {
                r.Add(new int[] { res[0], res[1] });
            }

            r.Add(new int[] { 1, 0 });

            r = r.OrderBy(x => x[0]).ToList();

            if (r[r.Count - 1][0] != n)
            {
                r.Add(new int[] { n, n - 1 });
            }

            int m = r.Count;

            for (int i = 1; i < m; ++i)
            {
                int dist = r[i][0] - r[i - 1][0];
                r[i][1] = Math.Min(r[i][1], r[i - 1][1] + dist);
            }

            for (int i = m - 2; i >= 0; --i)
            {
                int dist = r[i + 1][0] - r[i][0];
                r[i][1] = Math.Min(r[i][1], r[i + 1][1] + dist);
            }

            int ans = 0;
            for (int i = 0; i < m - 1; ++i)
            {
                int dist = r[i + 1][0] - r[i][0];
                int best = (dist + r[i][1] + r[i + 1][1]) / 2;
                ans = Math.Max(ans, best);
            }

            return ans;
        }
    }
}
