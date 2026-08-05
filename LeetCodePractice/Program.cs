namespace LeetCodePractice;

public class Solution
{
    List<int>[] g;
    int[] vis;
    void Dfs(int nd)
    {
        vis[nd] = 1;
        foreach (var child in g[nd])
        {
            if (vis[child] == 1) continue;
            Dfs(child);
        }
    }
    public IList<int> RemainingMethods(int n, int k, int[][] invocations)
    {
        vis = new int[n + 1];
        HashSet<int> an = new();

        for (int i = 0; i < n; i++) vis[i] = 0;

        g = new List<int>[n + 1];
        for (int i = 0; i < n; i++)
        {
            g[i] = new();
        }
        foreach (var invocation in invocations)
        {
            g[invocation[0]].Add(invocation[1]);
        }

        Dfs(k);
        foreach (var e in invocations)
        {
            int u = e[0], v = e[1];
            if (vis[u] == 0 && vis[v] == 1)
            {
                return Enumerable.Range(0, n).ToList();
            }
        }

        List<int> ans = new();
        for (int i = 0; i < n; i++)
        {
            if (vis[i] == 0)
                ans.Add(i);
        }
        return ans;
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[][] edges = [[0, 1], [1, 2], [2, 3]];
        int[] nums = [1, 2, 3, -9];
        var result = solution.RemainingMethods(4, 3, edges);
        Console.WriteLine(string.Join(", ", result));

        ///Summary
        ///Practice C#
        ///



        Console.ReadLine();
    }
}
