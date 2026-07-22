namespace LeetCodePractice.TemplatesInCSharp;

internal static class LowerBound
{
    public static int Lower_Bound<T>(List<T> list, T value) where T : IComparable<T>
    {
        int left = 0;
        int right = list.Count;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (list[mid].CompareTo(value) < 0) left = mid + 1;
            else right = mid;
        }
        return left;
    }
}
