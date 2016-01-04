using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf_MysteriousPresent
{
    class Program
    {
        static void Main(string[] args)
        {
            args = Console.ReadLine().Split(' ');
            int size = Convert.ToInt32(args[0]);
            int p0 = Convert.ToInt32(args[1]);
            int p1 = Convert.ToInt32(args[2]);

            int[] a0 = new int[size];
            int[] a1 = new int[size];
            SortedDictionary<int, List<int>> dict = new SortedDictionary<int, List<int>>();
            for (int i = 0; i < size; i++)
            {
                args = Console.ReadLine().Split(' ');
                int e0 = Convert.ToInt32(args[0]);
                int e1 = Convert.ToInt32(args[1]);
                if (e0 > p0 && e1 > p1)
                {
                    a0[i] = e0;
                    a1[i] = e1;
                    List<int> list;
                    if (!dict.TryGetValue(a0[i], out list))
                    {
                        dict.Add(a0[i], list = new List<int>());
                    }
                    list.Add(i);
                }
            }

            if (dict.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            comparer = new EnvelopeComparer(a1);
            List<EnvelopeSet> envelopeSetList = new List<EnvelopeSet>(dict.Values.Select(l => { return new EnvelopeSet(l); }));

            List<EnvelopeSet> result = new List<EnvelopeSet>();

            MysteriousPresent(result, envelopeSetList, 0);
            Console.WriteLine(best.Count());
            Console.WriteLine(string.Join(" ", best.Select(i => i + 1)));
        }

        private static int max = 0;
        private static IEnumerable<int> best = null;

        private static void MysteriousPresent(List<EnvelopeSet> result, List<EnvelopeSet> envelopeSetList, int i)
        {
            EnvelopeSet set;
            if (i >= envelopeSetList.Count)
            {
                if (result.Count > max)
                {
                    max = result.Count;

                    var list = new LinkedList<int>();
                    set = result[result.Count - 1];
                    while (set != null)
                    {
                        list.AddFirst(set._list[set.index]);
                        set = set.previous;
                    }

                    best = list;
                    return;
                }
                return;
            }

            set = envelopeSetList[i];
            if (result.Count == 0)
            {
                result.Add(set);
                MysteriousPresent(result, envelopeSetList, i + 1);
                return;
            }

            for (set.index = set._list.Count - 1; set.index >= 0; set.index--)
            {
                int p = 0;
                if ((p = result.BinarySearch(set)) >= 0)
                    continue;
                p = -(p + 1);

                if (p == result.Count)
                {
                    set.previous = result[p - 1];
                    result.Add(set.Copy());

                    if (result.Count > max)
                    {
                        max = result.Count;
                        var list = new LinkedList<int>();
                        var current = set;
                        while (current != null)
                        {
                            list.AddFirst(current._list[current.index]);
                            current = current.previous;
                        }
                        best = list;
                    }
                }
                else
                {
                    set.previous = p - 1 >= 0 ? result[p - 1] : null;
                    result[p] = set.Copy();
                }
            }
            MysteriousPresent(result, envelopeSetList, i + 1);
        }


        static EnvelopeComparer comparer;
        class EnvelopeSet : IComparable<EnvelopeSet>
        {
            public EnvelopeSet previous;
            public List<int> _list;
            public int index;
            public EnvelopeSet(List<int> list)
            {
                list.Sort(Program.comparer);
                this._list = list;
            }

            public int CompareTo(EnvelopeSet other)
            {
                return comparer.Compare(_list[index], other._list[other.index]);
            }

            internal EnvelopeSet Copy()
            {
                var copy = new EnvelopeSet(this._list);
                copy.index = this.index;
                copy.previous = this.previous;
                return copy;
            }
        }

        class EnvelopeComparer : IComparer<int>
        {
            private int[] _a1;
            public EnvelopeComparer(int[] a1)
            {
                this._a1 = a1;
            }

            public int Compare(int x, int y)
            {
                return _a1[x].CompareTo(_a1[y]);
            }
        }
    }
}
