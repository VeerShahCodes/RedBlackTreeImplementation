using RedBlackTreeImplementation;
namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void InsertTest()
        {
            RedBlackTree<int> redBlackTree = new RedBlackTree<int>();
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
            RedBlackTree<int> redBlackTree = new RedBlackTree<int>();
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
            RedBlackTree<int> redBlackTree = new RedBlackTree<int> ();
            redBlackTree.Add(1);
            redBlackTree.Add(3);
            redBlackTree.Add(4);
            redBlackTree.Add(5);

            int val = redBlackTree.Ceiling(2);
            int val1 = redBlackTree.Floor(2);
            ;
        }

    }
}