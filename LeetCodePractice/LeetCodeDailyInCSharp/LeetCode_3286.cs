namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_3286
{
    public class Solution
    {
        int[] dx = [1, -1, 0, 0];
        int[] dy = [0, 0, -1, 1];
        int[,,] vis;
        int n, m;
        bool isValid(int x, int y)
        {
            return (x >= 0 && x < n && y >= 0 && y < m);
        }
        bool Dfs(int x, int y, IList<IList<int>> grid, int h)
        {
            if (x == n - 1 && y == m - 1)
            {
                if (grid[x][y] == 1) return (h >= 2);
                return (h >= 1);
            }
            vis[x, y, h] = 1;
            bool ok = false;

            for (int i = 0; i < 4; i++)
            {
                int tx = x + dx[i];
                int ty = y + dy[i];
                if (!isValid(tx, ty)) continue;
                int nh = h - (grid[x][y] == 1 ? 1 : 0);
                if (nh < 1) continue;

                if (vis[tx, ty, nh] != 0) continue;


                ok |= Dfs(tx, ty, grid, nh);
            }
            return ok;

        }
        public bool FindSafeWalk(IList<IList<int>> grid, int health)
        {
            n = grid.Count();
            m = grid[0].Count();

            vis = new int[n, m, n + m + 1];
            return Dfs(0, 0, grid, health);
        }
    }
}
