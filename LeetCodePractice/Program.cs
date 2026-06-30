using System.ComponentModel.Design;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;

namespace LeetCodePractice;


public class Solution
{
    public int NumberOfSubstrings(string s)
    {
        int i = 0, j = 0;
        int n = s.Length;
        int a = 0, b = 0, c = 0;
        int an = 0;
        a = (s[i] == 'a' ? 1 : 0);
        b = (s[i] == 'b' ? 1 : 0);
        c = (s[i] == 'c' ? 1 : 0);

        while (j < n)
        {
            if (a > 0 && b > 0 && c > 0)
            {
                if (i < n)
                {
                    a -= (s[i] == 'a' ? 1 : 0);
                    b -= (s[i] == 'b' ? 1 : 0);
                    c -= (s[i] == 'c' ? 1 : 0);
                    i++;
                }
            }
            else
            {
                j++;
                if (j < n)
                {
                    a += (s[j] == 'a' ? 1 : 0);
                    b += (s[j] == 'b' ? 1 : 0);
                    c += (s[j] == 'c' ? 1 : 0);
                }
            }
            if (a > 0 && b > 0 && c > 0)
            {
                an += (n - j);
            }
        }
        return an;
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        int[] nums = [73, 98, 9];
        string s = "z*#";
        int result = solution.NumberOfSubstrings("abcabc");
        Console.WriteLine(string.Join(", ", result));
        Console.ReadLine();
    }
}
