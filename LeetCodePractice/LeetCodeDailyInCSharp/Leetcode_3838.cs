using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class Leetcode_3838
{
    public class Solution
    {
        public string MapWordWeights(string[] words, int[] weights)
        {
            string an = default;
            foreach (var word in words)
            {
                int sm = 0;
                for (int i = 0; i < word.Length; i++)
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
}
