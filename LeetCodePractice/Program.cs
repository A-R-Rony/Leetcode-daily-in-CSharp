using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;

namespace LeetCodePractice;

public class Dsu
{
    int[] Parent;
    int N;
    public Dsu(int n)
    {
        N = n;
        Parent = new int[N+1];
        for (int i = 0; i <= N; i++)
        {
            Parent[i] = i;
        }
    }

    public int Find(int u)
    {
        if (Parent[u] == u) return u;
        return Parent[u] = Find(Parent[u]);
    }
    public void Union(int u, int v)
    {
        Parent[v] = u;
    }
}
public class Solution
{
    int[] Nums;
    int N, MaxDiff;
    List<int>[] G;
    int[] Parents;
    int UpperBound(int x)
    {
        int l = 0, r = N - 1, an = (x >= Nums[N - 1] ? N : -1);
        while (l <= r)
        {
            int md = l + (r - l) / 2;
            if (Nums[md] <= x)
            {
                an = md;
                l = md + 1;
            }
            else
            {
                r = md - 1;
            }
        }
        return an;
    }
    public bool[] PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries)
    {
        this.N = n;
        this.Nums = nums;
        this.MaxDiff = maxDiff;
        G = new List<int>[n + 1];
        Parents = new int[n + 1];

        for (int i = 0; i <= n; i++)
        {
            Parents[i] = i;
        }

        for (int i = 0; i <= n; i++)
        {
            G[i] = new List<int>();
        }

        Dsu dsu = new Dsu(N);

        for (int i = 0; i < n; i++)
        {
            int ub = UpperBound(nums[i] + maxDiff);

            int pi = dsu.Find(i);
            int pub = dsu.Find(ub);

            if (pi != pub)
            {
                dsu.Union(pi, pub);
            }
        }

        int m = queries.Length;
        bool[] an = new bool[m];

        for (int i = 0; i < m; i++)
        {
            int u = queries[i][0];
            int v = queries[i][1];

            if (dsu.Find(u) == dsu.Find(v)) an[i] = true;
            else an[i] = false;
        }
        return an;

    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        int[] nums = [2, 5, 6, 8];
        int[][] edges = [[0, 1], [0, 2], [1, 3], [2, 3]];
        bool[] online = [true, true, true, false, true];


        string s = "z*#";
        bool[] result = solution.PathExistenceQueries(4, nums, 2, edges);
        Console.WriteLine(string.Join(", ", result));
        Console.ReadLine();
    }
}
