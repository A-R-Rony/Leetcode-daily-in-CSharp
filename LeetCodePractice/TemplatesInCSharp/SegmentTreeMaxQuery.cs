namespace LeetCodePractice.TemplatesInCSharp;

internal class SegmentTreeMaxQuery
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

}
