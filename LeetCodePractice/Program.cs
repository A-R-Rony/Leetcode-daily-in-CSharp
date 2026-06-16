using System.ComponentModel.Design;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;

namespace LeetCodePractice;



public class Solution
{
    public string ProcessStr(string s)
    {
        string an = "";
        for(int i = 0;i < s.Length;i++)
        {
            if (char.IsLower(s[i]))
            { 
                an += s[i];
                continue;
            }
            if (s[i] == '*' && an.Length > 0)
            {
                an = an[..^1];continue;
            }
            if (s[i] == '#') an += an;
            else an = new string(an.Reverse().ToArray());
        }
        
         return an;
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
        string result = solution.ProcessStr(s);
        Console.WriteLine(string.Join(", ", result));
        Console.ReadLine();
    }
}
