namespace LeetCodePractice;

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
        return mem[i,j] = an;

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
internal class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[][] edges = [[0, 3], [0, 2], [1, 3], [2, 3]];
        int[] nums = [7, 7, 12, 16, 41, 48, 41, 48, 11, 9, 34, 2, 44, 30, 27, 12, 11, 39, 31, 8, 23, 11, 47, 25, 15, 23, 4, 17, 11, 50, 16, 50, 38, 34, 48, 27, 16, 24, 22, 48, 50, 10, 26, 27, 9, 43, 13, 42, 46, 24];
        bool result = solution.StoneGame(nums);
        Console.WriteLine(string.Join(", ", result));

        ///Summary
        ///Practice C#
        ///



        Console.ReadLine();
    }
}
