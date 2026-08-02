namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_877
{

    public class Solution
    {
        int n;
        int[,] mem;
        int f(int i, int j, int st, int[] piles)
        {
            if (i > j || i == n || j == -1) return 0;

            int d = (st == 0 ? -1 : 1);
            int an = 0;
            if (mem[i, j] != -1) return mem[i, j];

            if (st == 1)
            {
                an = f(i + 1, j, st ^ 1, piles) + piles[i];
                an = int.Max(an, piles[j] + f(i, j - 1, st ^ 1, piles));
            }
            else
            {
                an = -piles[i] + f(i + 1, j, st ^ 1, piles);
                an = int.Min(an, piles[j] + f(i, j - 1, st ^ 1, piles));
            }
            return mem[i, j] = an;

        }
        public bool StoneGame(int[] piles)
        {
            n = piles.Length;
            mem = new int[n + 1, n + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mem[i, j] = -1;
                }
            }
            return (f(0, n - 1, 1, piles) > 0 ? true : false);

        }
    }
}
