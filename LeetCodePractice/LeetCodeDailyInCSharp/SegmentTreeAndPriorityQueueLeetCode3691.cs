using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice.LeetCodeDailyInCSharp;

internal class SegmentTreeAndPriorityQueueLeetCode3691
{
    public class SegmentTree
    {
        public struct Node
        {
            public long suru, ses, mx, mn;
            public void Init(long l, long r, long[] a)
            {
                suru = l; ses = r;
                if (l == r)
                {
                    mx = mn = a[l];
                }
            }
        }
        private Node[] g;
        private long[] a;

        public SegmentTree(int maxN, long[] inputArray)
        {
            g = new Node[4 * maxN];
            a = inputArray;
        }
        public void Build(long cn, long l, long r)
        {
            g[cn].Init(l, r, a);

            if (l == r) return;
            long md = l + (r - l) / 2;

            Build(cn * 2, l, md);
            Build(cn * 2 + 1, md + 1, r);

            g[cn].mx = Math.Max(g[cn * 2].mx, g[cn * 2 + 1].mx);
            g[cn].mn = Math.Min(g[cn * 2].mn, g[cn * 2 + 1].mn);
        }
        public (long, long) Query(long cn, long l, long r)
        {
            long x = g[cn].suru;
            long y = g[cn].ses;

            if (y < l || x > r) return (0, long.MaxValue);

            if (l <= x && r >= y)
                return (g[cn].mx, g[cn].mn);

            var p = Query(cn * 2, l, r);
            var q = Query(cn * 2 + 1, l, r);
            return ((Math.Max(p.Item1, q.Item1)), (Math.Min(p.Item2, q.Item2)));
        }
    }
    public class Solution
    {
        public long MaxTotalValue(int[] nums, int k)
        {
            int n = nums.Length;
            long[] a = new long[n + 1];
            for (int i = 0; i < n; i++) a[i + 1] = nums[i];

            SegmentTree stre = new SegmentTree(n + 1, a);
            stre.Build(1, 1, n);

            var maxHeapComparer = Comparer<(long val, long left, long right)>.Create((x, y) => y.CompareTo(x));
            var pq = new PriorityQueue<(long val, long left, long right), (long val, long left, long right)>(maxHeapComparer);

            var val = stre.Query(1, 1, n);
            pq.Enqueue((val.Item1 - val.Item2, 1, n), (val.Item1 - val.Item2, 1, n));
            long ans = 0;

            while (k > 0)
            {
                k--;
                var current = pq.Dequeue();
                ans += current.val;
                var val1 = stre.Query(1, current.left + 1, current.right);
                var val2 = stre.Query(1, current.left, current.right - 1);

                pq.Enqueue((val1.Item1 - val1.Item2, current.left + 1, current.right), (val1.Item1 - val1.Item2, current.left + 1, current.right));
                pq.Enqueue((val2.Item1 - val2.Item2, current.left, current.right - 1), (val2.Item1 - val2.Item2, current.left, current.right - 1));
            }

            return ans;
        }
    }
}
