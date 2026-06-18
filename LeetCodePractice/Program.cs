using System.ComponentModel.Design;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;

namespace LeetCodePractice;



public class Solution
{
    public double AngleClock(int hour, int minutes)
    {
        double H = hour * 30;
        double M = (5.5) * minutes;
        return Math.Min(Math.Abs(H - M), 360 - Math.Abs(H - M));
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        string[] words = ["abcd", "def", "xyz"];
        int[] weights = [5, 3, 12, 14, 1, 2, 3, 2, 10, 6, 6, 9, 7, 8, 7, 10, 8, 9, 6, 9, 9, 8, 3, 7, 7, 2];
        string s = "z*#";
        double result = solution.AngleClock(12,30);
        Console.WriteLine(string.Join(", ", result));
        Console.ReadLine();
    }
}
