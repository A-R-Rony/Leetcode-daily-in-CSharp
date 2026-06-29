namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_1967
{
    public class Solution
    {
        public int NumOfStrings(string[] patterns, string word)
        {
            int an = 0;
            foreach (var p in patterns)
            {
                an += (word.Contains(p) ? 1 : 0);
            }
            return an;
        }
    }
}
