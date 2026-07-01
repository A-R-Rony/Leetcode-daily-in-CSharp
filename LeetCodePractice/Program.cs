using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;

namespace LeetCodePractice;


public class Solution
{
    int n, m;
    int[,] cellSafeNess;
    int[] dx = [1, -1, 0, 0];
    int[] dy = [0, 0, -1, 1];
    int[,] vis;
    bool isValid(int x, int y, IList<IList<int>> grid)
    {
        if (x >= 0 && x < n && y >= 0 && y < n && grid[x][y] == 0 && cellSafeNess[x, y] == 0) return true;
        return false;
    }
    void Bfs(IList<IList<int>> grid)
    {
        cellSafeNess = new int[n, m];
        Queue<(int, int, int)> q = new Queue<(int, int, int)>();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] == 1)
                {
                    cellSafeNess[i, j] = 1;
                    q.Enqueue((0, i, j));
                }
            }
        }

        while (q.Count() > 0)
        {
            var (dis, x, y) = q.Dequeue();
            for (int i = 0; i < 4; i++)
            {
                int tx = dx[i] + x;
                int ty = dy[i] + y;
                if (!isValid(tx, ty, grid)) continue;
                cellSafeNess[tx, ty] = cellSafeNess[x, y] + 1;
                q.Enqueue((cellSafeNess[tx, ty], tx, ty));
            }
        }

    }
    bool Dfs(int x, int y, int md)
    {
        if (cellSafeNess[x, y] < md) return false;
        if (x == n - 1 && y == m - 1)
        {
            return true;
        }

        bool ok = false;
        vis[x, y] = 1;

        for (int i = 0; i < 4; i++)
        {
            int tx = x + dx[i];
            int ty = y + dy[i];
            if (tx >= 0 && tx < n && ty >= 0 && ty < m)
            {
                if (vis[tx, ty] == 1) continue;

                ok |= Dfs(tx, ty, md);
            }
        }
        return ok;
    }
    void ClearVisisted()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++) vis[i, j] = 0;
        }
    }
    bool Chk(int md)
    {
        return Dfs(0, 0, md);
    }
    int Bs()
    {
        int l = 0, r = int.Max(n, m);
        int an = 0;
        while (l <= r)
        {
            int md = l + (r - l) / 2;
            ClearVisisted();
            bool ok = Chk(md);

            if (ok)
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
    public int MaximumSafenessFactor(IList<IList<int>> grid)
    {
        n = grid.Count();
        m = grid[0].Count();
        vis = new int[n, m];

        Bfs(grid);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                // 1. Use Write (not WriteLine) to keep elements on the same row
                Console.Write(cellSafeNess[i, j] + " ");
            }
            // 2. Move to the next line only when a row is completely finished
            Console.WriteLine();
        }
        return Bs() - 1;

    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        int[] nums = [73, 98, 9];
        IList<IList<int>> grid = new List<IList<int>>()
{
    new List<int> { 0, 0, 0, 1 },
    new List<int> { 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0 },
    new List<int> { 1, 0, 0, 0 }
};
        string s = "z*#";
        int result = solution.MaximumSafenessFactor(grid);
        Console.WriteLine(string.Join(", ", result));
        Console.ReadLine();
    }
}
