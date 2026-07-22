namespace LeetCodePractice;

public class Solution
{
    public class SegmentTree
    {
        public struct Node
        {
            public int suru, ses, mx, mn;
            public void Init(int l, int r, int[] a)
            {
                suru = l; ses = r;
                if (l == r) mx = a[l];
            }
        }
        private Node[] g;
        private int[] a;

        public SegmentTree(int maxN, int[] inputArray)
        {
            g = new Node[4 * maxN];
            a = inputArray;
        }
        public void Build(int cn, int l, int r)
        {
            g[cn].Init(l, r, a);
            if (l == r) return;

            int md = l + (r - l) / 2;
            Build(cn * 2, l, md);
            Build(cn * 2 + 1, md + 1, r);
            g[cn].mx = Math.Max(g[cn * 2].mx, g[cn * 2 + 1].mx);
        }
        public int Query(int cn, int l, int r)
        {
            int x = g[cn].suru;
            int y = g[cn].ses;
            if (y < l || x > r) return 0;
            if (l <= x && r >= y) return g[cn].mx;

            return Math.Max(Query(cn * 2, l, r), Query(cn * 2 + 1, l, r));
        }
    }

    public IList<int> MaxActiveSectionsAfterTrade(string s, int[][] queries)
    {
        int n = s.Length;
        int j = 0;
        List<int> zeros = new List<int>();
        List<int> ipos = new List<int>();
        List<int> epos = new List<int>();
        int cnt1 = 0;

        foreach (char c in s)
            cnt1 += (c == '1' ? 1 : 0);

        while (j < n)
        {
            int start = j;
            while (j < n && s[start] == s[j]) j++;

            if (s[start] == '0')
            {
                zeros.Add(j - start);
                ipos.Add(start);
                epos.Add(j - 1);
            }
        }

        List<int> segArray = new List<int>();
        List<int> ans = new List<int>();

        int q = queries.Length;
        if (zeros.Count < 2)
        {
            while (q-- > 0) ans.Add(cnt1);
            return ans;
        }

        segArray.Add(0); // 1 based indexing
        for (int i = 0; i + 1 < zeros.Count; i++)
            segArray.Add(zeros[i] + zeros[i + 1]);

        SegmentTree segTree = new SegmentTree(segArray.Count + 1, segArray.ToArray());
        segTree.Build(1, 1, segArray.Count - 1);

        q = 0;
        while (q < queries.Length)
        {
            int l = queries[q][0];
            int r = queries[q][1];

            // First and last zero-runs that intersect [l, r].
            int lb_l = LowerBound(epos, l);
            int lb_r = UpperBound(ipos, r) - 1;

            if (lb_l >= lb_r)
            {
                ans.Add(cnt1);
                q++;
                continue;
            }

            int leftCandidate = Math.Min(epos[lb_l], r) - Math.Max(ipos[lb_l], l) + 1
                              + Math.Min(epos[lb_l + 1], r) - Math.Max(ipos[lb_l + 1], l) + 1;
            int rightCandidate = Math.Min(epos[lb_r - 1], r) - Math.Max(ipos[lb_r - 1], l) + 1
                               + Math.Min(epos[lb_r], r) - Math.Max(ipos[lb_r], l) + 1;

            int best = Math.Max(leftCandidate, rightCandidate);

            // All candidates between the two boundaries are fully covered.
            if (lb_l + 1 <= lb_r - 2)
                best = Math.Max(best, segTree.Query(1, lb_l + 2, lb_r - 1));

            ans.Add(cnt1 + best);
            q++;
        }

        return ans;
    }

    public static int LowerBound<T>(List<T> list, T value) where T : IComparable<T>
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

    public static int UpperBound<T>(List<T> list, T value) where T : IComparable<T>
    {
        int left = 0;
        int right = list.Count;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (list[mid].CompareTo(value) <= 0) left = mid + 1;
            else right = mid;
        }
        return left;
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[][] edges = [[0, 3], [0, 2], [1, 3], [2, 3]];
        IList<int> result = solution.MaxActiveSectionsAfterTrade("0100", edges);
        Console.WriteLine(string.Join(", ", result));

        Console.ReadLine();
    }
}
