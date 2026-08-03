namespace LeetCodePractice;

public class Solution
{
    int n;
    int[,] mem;
    int f(int i, int st, int[] a)
    {
        if (i >= n)
        {
            return 0;
        }
        if (mem[i, st] != -1) return mem[i, st];
        int d = (st == 1 ? 1 : -1);

        int an = (st == 1 ? int.MinValue : int.MaxValue);
        an = (st == 1 ? int.Max(an, a[i] + f(i + 1, st ^ 1, a)) : int.Min(an, d * a[i] + f(i + 1, st ^ 1, a)));
        if (i + 1 < n)
            an = (st == 1 ? int.Max(an, a[i] + a[i + 1] + f(i + 2, st ^ 1, a)) : int.Min(an, d * (a[i] + a[i + 1]) + f(i + 2, st ^ 1, a)));
        if (i + 2 < n)
            an = (st == 1 ? int.Max(an, a[i] + a[i + 1] + a[i + 2] + f(i + 3, st ^ 1, a)) : int.Min(an, d * (a[i] + a[i + 1] + a[i + 2]) + f(i + 3, st ^ 1, a)));
        return mem[i, st] = an;
    }
    public string StoneGameIII(int[] stoneValue)
    {
        n = stoneValue.Length;
        mem = new int[n + 1, 2];
        for (int i = 0; i < n; i++)
        {
            mem[i, 0] = mem[i, 1] = -1;
        }
        int an = f(0, 1, stoneValue);
        if (an > 0) return "Alice";
        else if (an < 0) return "Bob";
        return "Tie";
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[][] edges = [[0, 3], [0, 2], [1, 3], [2, 3]];
        int[] nums = [1, 2, 3, -9];
        var result = solution.StoneGameIII(nums);
        Console.WriteLine(string.Join(", ", result));

        ///Summary
        ///Practice C#
        ///



        Console.ReadLine();
    }
}
