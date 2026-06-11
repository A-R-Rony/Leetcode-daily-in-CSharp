using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class Dfs_Bigmod_Factorial_FermatLittleTheorme_LeetCode_3558
{
    public class Solution
    {
        public const int mod = (int)1e9 + 7;
        int[] depth = new int[100005];
        List<int>[] g = new List<int>[100005];
        long[] fact = new long[100005];

        void dfs(int nd, int p)
        {
            foreach (var child in g[nd])
            {
                if (child == p) continue;

                depth[child] = depth[nd] + 1;
                dfs(child, nd);
            }
        }
        long bigmod(long a, long n)
        {
            long ans = 1;
            while (n > 0)
            {
                if (n % 2 == 0)
                {
                    n /= 2;
                    a = (a * a) % mod;
                }
                else
                {
                    n--;
                    ans = (ans * a) % mod;
                }
            }
            return ans;
        }
        long calc(int n)
        {
            long ans = 0;
            for (int i = 1; i <= n; i += 2)
            {
                // n! / (i! * (n - i)!
                long num = fact[n];

                long denom = (fact[i] * fact[n - i]) % mod;

                long currentComb = (num * bigmod(denom, mod - 2)) % mod;

                ans = (ans + currentComb) % mod;
            }

            return ans;
        }
        void factorial()
        {
            fact[0] = 1;
            for (int i = 1; i < 100005; i++)
            {
                fact[i] = (fact[i - 1] * i) % mod;
            }
        }
        public long AssignEdgeWeights(int[][] edges)
        {
            factorial();
            int n = 100005;

            for (int i = 0; i < n; i++)
            {
                g[i] = new List<int>();
            }
            foreach (var edge in edges)
            {
                if (edge != null && (int)edge.Length >= 2)
                {
                    g[edge[0]].Add(edge[1]);
                    g[edge[1]].Add(edge[0]);
                }
            }
            dfs(1, 0);
            int maxDepth = depth.Max();

            return calc(maxDepth);
        }
    }

}
