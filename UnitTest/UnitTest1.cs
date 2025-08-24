using RedBlackTreeImplementation;
using System.ComponentModel;
namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void InsertTest()
        {
            Comparer<int> comparer = Comparer<int>.Default;

            RedBlackTree<int> redBlackTree = new RedBlackTree<int>(comparer);
            Random random = new Random();
            for(int i = 0; i < 5; i++)
            {
                
                redBlackTree.Add(i);
            }

            ;
        }

        [Fact]
        public void RemoveTest()
        {
            Comparer<int> comparer = Comparer<int>.Default;

            RedBlackTree<int> redBlackTree = new RedBlackTree<int>(comparer);
            for(int i = 0; i < 100; i++)
            {
                redBlackTree.Add(i);
            }
            ;
            for(int i = 0; i < 100; i++)
            {
                redBlackTree.Remove(i);
            }
            ;
        }

        [Fact]
        public void FloorCeilingTest()
        {
            Comparer<int> comparer = Comparer<int>.Default;

            RedBlackTree<int> redBlackTree = new RedBlackTree<int>(comparer);
            redBlackTree.Add(1);
            redBlackTree.Add(3);
            redBlackTree.Add(4);
            redBlackTree.Add(5);

            int val = redBlackTree.Ceiling(2);
            int val1 = redBlackTree.Floor(2);
            ;
        }

        [Fact]
        public void UnionIntersectionTest()
        {
            Comparer<int> comparer = Comparer<int>.Default;
            SortedSetClass<int> set = new SortedSetClass<int>(comparer);
            SortedSetClass<int> set1 = new SortedSetClass<int>(comparer);
            set.Add(1); set.Add(2); set.Add(3);
            set1.Add(2); set1.Add(4);
            var set2 = set.Union(set1);
            var set3 = set.Intersection(set1);
            ;
        }

    }
}