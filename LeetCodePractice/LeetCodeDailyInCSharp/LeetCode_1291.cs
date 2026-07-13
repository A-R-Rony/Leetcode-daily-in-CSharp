namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class LeetCode_1291
{
    public class Solution
    {
        int f(int x, int i, int num)
        {
            if (i == 0)
            {
                return num;
            }

            return f(x + 1, i - 1, (num * 10) + x);
        }
        public IList<int> SequentialDigits(int low, int high)
        {
            List<int> l = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    if ((9 - j) + 1 >= i)
                    {
                        l.Add(f(j, i, 0));
                    }
                }
            }

            return l.Where(x => x >= low && x <= high).ToList();
        }
    }
}
