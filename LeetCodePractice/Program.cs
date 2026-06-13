using System.ComponentModel.Design;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;

namespace LeetCodePractice;

public class Solution
{
    public string MapWordWeights(string[] words, int[] weights)
    {
        string an = default;
        foreach(var word in words)
        {
            int sm = 0;
            for(int i =0;i < word.Length; i++)
            {
                sm += weights[word[i] - 'a'];
                sm %= 26;
            }
            char c = (char)((25 - sm) + 'a');
            an += (c);
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

        string result = solution.MapWordWeights(words,weights);
        Console.WriteLine(string.Join(", ", result));
        Console.ReadLine();
    }
}
