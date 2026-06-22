using System.ComponentModel.Design;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;

namespace LeetCodePractice;



public class Solution
{
    public int MaxNumberOfBalloons(string text)
    {
        Dictionary<char, int> cnt = new Dictionary<char, int>();
        foreach (var c in text)
        {
            if (cnt.ContainsKey(c)) cnt[c]++;
            else cnt[c] = 1;
        }
        string t = "balloon";
        int mn = new[]
        {
           cnt.GetValueOrDefault('a',0),
           cnt.GetValueOrDefault('b',0),
           cnt.GetValueOrDefault('n',0),
           cnt.GetValueOrDefault('l',0)/2,
           cnt.GetValueOrDefault('o',0)/2
        }.Min();
        
        return mn;
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
        int result = solution.MaxNumberOfBalloons("nlaebolko");
        Console.WriteLine(string.Join(", ", result));
        Console.ReadLine();
    }
}
