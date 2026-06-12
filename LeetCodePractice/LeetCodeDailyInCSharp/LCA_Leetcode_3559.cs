using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LCA_Leetcode_3559
{
    public class Solution
    {
        public const int mod = (int)1e9 + 7;
        int[][] up;
        int[] depth;
        List<int>[] g;

        void dfs(int nd, int p)
        {
            foreach (var child in g[nd])
            {
                if (child == p) continue;

                up[child][0] = nd;
                for (int log = 1; log < 20; log++)
                {
                    int ancestor = up[child][log - 1];
                    up[child][log] = up[ancestor][log - 1];
                }

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
            if (n == 0) return 0;
            return bigmod(2, n - 1);
        }

        int get_lca(int x, int y)
        {
            if (depth[x] < depth[y]) (x, y) = (y, x);

            int k = depth[x] - depth[y];
            for (int log = 19; log >= 0; log--)
            {
                if ((k & (1 << log)) != 0)
                {
                    x = up[x][log];
                }
            }
            if (x == y) return x;

            for (int log = 19; log >= 0; log--)
            {
                if (up[x][log] != up[y][log])
                {
                    x = up[x][log];
                    y = up[y][log];
                }
            }
            return up[x][0];
        }

        public int[] AssignEdgeWeights(int[][] edges, int[][] queries)
        {

            int n = edges.Length + 2;


            up = new int[n][];
            depth = new int[n];
            g = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                up[i] = new int[20];
                g[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                if (edge != null && edge.Length >= 2)
                {
                    g[edge[0]].Add(edge[1]);
                    g[edge[1]].Add(edge[0]);
                }
            }

            dfs(1, 0);

            int[] an = new int[queries.Length];

            for (int i = 0; i < queries.Length; i++)
            {
                var query = queries[i];
                int lca = get_lca(query[0], query[1]);
                int dis = depth[query[0]] + depth[query[1]] - 2 * depth[lca];
                an[i] = (int)calc(dis);
            }

            return an;
        }
    }
}
