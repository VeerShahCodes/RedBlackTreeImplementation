using SortedSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortedSet;
using System.Collections;
namespace RedBlackTreeImplementation
{
    public class SortedSetClass<T> : ISortedSet<T> where T : IComparable<T>
    {
        public RedBlackTree<T> tree;



        public IComparer<T> comparer;

        public int Count => count;
        private int count;
        IComparer<T> ISortedSet<T>.Comparer => comparer;

        public SortedSetClass(IComparer<T> comparer)
        {
            tree = new RedBlackTree<T>(comparer);
            this.comparer = comparer;
            count = 0;
        }
        public bool Add(T item)
        {
            return tree.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            tree.AddRange(items);
        }

        public T Ceiling(T item)
        {
            return tree.Ceiling(item);
        }

        public void Clear()
        {
            tree.Clear();
        }

        public bool Contains(T item)
        {
            return tree.Contains(item);
        }

        public T Floor(T item)
        {
            return tree.Floor(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return tree.InOrderTraversal().GetEnumerator();
        }

        public ISortedSet<T> Intersection(ISortedSet<T> other)
        {
            RedBlackTree<T> set = new RedBlackTree<T>(comparer);
            foreach (var item in other)
            {
                if (tree.Contains(item))
                {
                    set.Add(item);
                }
            }
            return set;
        }

        public T Max()
        {
            return tree.Max();
        }

        public T Min()
        {
            return tree.Min();
        }

        public bool Remove(T item)
        {
            return tree.Remove(item);
        }

        public ISortedSet<T> Union(ISortedSet<T> other)
        {
            SortedSetClass<T> set = new SortedSetClass<T>(comparer);

            foreach (var item in other)
            {
                set.Add(item);
            }
            foreach (var item in tree)
            {
                if (!set.Contains(item))
                {
                    set.Add(item);
                }
            }

            return set;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return tree.InOrderTraversal().GetEnumerator();
        }
    }
}
