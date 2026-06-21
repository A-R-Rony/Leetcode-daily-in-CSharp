using System.ComponentModel.Design;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;

namespace LeetCodePractice;



public class Solution
{
    public int MaxIceCream(int[] costs, int coins)
    {
        Array.Sort(costs);
        for(int i = 0;i < costs.Length; i++)
        {
            if(coins >= costs[i])
            {
                coins -= costs[i];
                continue;
            }
            else
            {
                return i;
            }
        }
        return costs.Length;

    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        string[] words = ["abcd", "def", "xyz"];
        int[] weights = [10, 6, 8, 7, 7, 8];
        string s = "z*#";
        int result = solution.MaxIceCream(weights,5);
        Console.WriteLine(string.Join(", ", result));
        Console.ReadLine();
    }
}
